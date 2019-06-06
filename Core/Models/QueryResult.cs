using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace SchedulingSystem.Core.Models
{
    public class QueryResult<T>
    {
        public int TotalItems { get; set; }
        public IEnumerable<T> Items { get; set; }
    }
}