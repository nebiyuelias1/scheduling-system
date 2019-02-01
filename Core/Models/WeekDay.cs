using System.ComponentModel.DataAnnotations;


namespace SchedulingSystem.Core.Models
{
    public class WeekDay
    {
        public int Id { get; set; }

        [Required]
        [StringLength(15)]
        public string Name { get; set; }
        public int Number { get; set; }
    }
}