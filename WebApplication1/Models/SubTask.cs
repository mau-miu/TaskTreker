using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class SubTask
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Start { get; set; } = DateTime.Now;
        public DateTime Finish { get; set; }
        public string Worker { get; set; } 
        public int TodoIthemId { get; set; }
        public TodoItem TodoItem { get; set; }
    }
}
