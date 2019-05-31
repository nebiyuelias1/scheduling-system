using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace SchedulingSystem.Core.Models
{
    public class Instructor
    {
        public int Id { get; set; }

        public Department Department { get; set; }

        public int DepartmentId { get; set; }

        public bool IsActive { get; private set; }
        
        public AppUser User { get; set; }
        
        public string UserId { get; set; }

        public Instructor()
        {
            IsActive = true;
        }

        public void MakeInactive()
        {
            if (this.IsActive)
                this.IsActive = false;
        }
    }
}