using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using SchedulingSystem.Auth;
using SchedulingSystem.Controllers.Resources;
using SchedulingSystem.Core;
using SchedulingSystem.Core.Models;

namespace SchedulingSystem.Controllers
{
    public class AuthController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IConfiguration configuration;
        private readonly IJwtFactory jwtFactory;
        private readonly IUnitOfWork unitOfWork;
        private readonly JwtIssuerOptions jwtOptions;
        public AuthController(
                            UserManager<AppUser> userManager,
                            RoleManager<IdentityRole> roleManager,
                            IConfiguration configuration,
                            IJwtFactory jwtFactory,
                            IOptions<JwtIssuerOptions> jwtOptions,
                            IUnitOfWork unitOfWork)
        {
            this.jwtOptions = jwtOptions.Value;
            this.jwtFactory = jwtFactory;
            this.unitOfWork = unitOfWork;
            this.configuration = configuration;
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        [HttpGet("/roles")]
        public async Task<IActionResult> GetRoles()
        {
            return Ok(await roleManager.Roles
                .Select(r => new 
                {
                    r.Id,
                    r.Name,
                    r.NormalizedName
                })
                .ToListAsync());
        }

        [HttpPost]
        [Route("/login")]
        public async Task<IActionResult> Login([FromBody] LoginResource resource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var identity = await GetClaimsIdentity(resource.Username, resource.Password);
            if (identity == null)
            {
                return BadRequest(Errors.AddErrorToModelState("login_failure", "Invalid username or password.", ModelState));
            }

            var jwt = await Tokens.GenerateJwt(identity, jwtFactory, resource.Username, jwtOptions, new JsonSerializerSettings { Formatting = Formatting.Indented });
            return new OkObjectResult(jwt);
        }

        [HttpPost]
        [Route("/register")]
        public async Task<IActionResult> Register([FromBody] RegisterResource resource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = new AppUser
            {
                FirstName = resource.FirstName,
                FatherName = resource.FatherName,
                GrandFatherName = resource.GrandFatherName,
                Email = resource.Email,
                UserName = resource.Email,
                DepartmentId = resource.DepartmentId,
                SecurityStamp = Guid.NewGuid().ToString()
            };
            var result = await userManager.CreateAsync(user, resource.Password);

            if (!result.Succeeded)
                return new BadRequestObjectResult(Errors.AddErrorsToModelState(result, ModelState));

            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(user, resource.Role);
                //await userManager.AddToRoleAsync(user, adminRole.Name);
                // var student = new IdentityRole("Student");
                // await roleManager.CreateAsync(student);
                // await roleManager.AddClaimAsync(student, new Claim("student", "true"));
                // Add to role
                // await userManager.AddToRoleAsync(user, "Customer");
            }
            return Ok(new { Id = user.Id, Username = user.UserName });
        }

        private async Task<ClaimsIdentity> GetClaimsIdentity(string userName, string password)
        {
            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password))
                return await Task.FromResult<ClaimsIdentity>(null);

            // get the user to verifty
            var userToVerify = await userManager.FindByNameAsync(userName);

            if (userToVerify == null) return await Task.FromResult<ClaimsIdentity>(null);

            // check the credentials
            if (await userManager.CheckPasswordAsync(userToVerify, password))
            {
                var roles = await userManager.GetRolesAsync(userToVerify);
                var claims = new List<Claim>();

                // var instructor = await unitOfWork.Instructors.GetInstructorWithDept(userToVerify.Id);
                // claims.Add(new Claim("dept", instructor.Department.Name));

                foreach (var role in roles)
                {
                    var r = await roleManager.FindByNameAsync(role);
                    var c = await roleManager.GetClaimsAsync(r);
                    claims.AddRange(c);
                }
                
                return await Task.FromResult(jwtFactory.GenerateClaimsIdentity(userName, userToVerify.Id, claims));
            }

            // Credentials are invalid, or account doesn't exist
            return await Task.FromResult<ClaimsIdentity>(null);
        }
    }
}