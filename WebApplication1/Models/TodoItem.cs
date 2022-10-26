using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public struct Status
    {
        public bool Appointed;
        public bool IsDoing;
        public bool IsDone;

        //public Status(bool appointed=true, bool isdoing=false, bool isdone = false)
        //{
        //    this.Appointed=appointed;
        //    this.IsDoing=isdoing;
        //    this.IsDone=isdone;
        //}
    }
    public class TodoItem
    {
       
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsDone { get; set; }
        public bool Appointed { get; set; }
        public bool Stoped { get; set; }
        public bool IsDoing { get; set; }
        public string Description { get; set; }
        public List<SubTask> SubTasks { get; set; } = new List<SubTask>(); 
    }

   
}
