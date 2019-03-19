using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using SchedulingSystem.Core.Models;

namespace SchedulingSystem.Controllers.Resources
{
    public class TimetableResource
    {
        public ScheduleResource Schedule { get; set; }
        public ScheduleConfigurationResource ScheduleConfiguration { get; set; }
    }
}