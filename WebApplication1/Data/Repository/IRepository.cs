using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Data.Repository
{
   public interface IRepository
    {
        IEnumerable<TodoItem> GetAllItems();
        void AddTodo(string todoName);
        void ValueChanged(TodoItem changedItem);
        void DeletedItem(int id);
    }
}
