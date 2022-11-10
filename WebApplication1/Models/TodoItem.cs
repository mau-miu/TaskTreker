using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
   
    public class TodoItem
    {
       
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsDone { get; set; }
        public string Description { get; set; }
        public List<SubTask> SubTasks { get; set; } = new List<SubTask>();

        [ForeignKey("Status")]
        [Required]
        public int StatusId { get; set; }

        public string StatusName { get; set; }
    }

   
}
