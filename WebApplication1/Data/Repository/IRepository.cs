using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Data.Repository
{
   public interface IRepository
    {
        //Task
        IEnumerable<TodoItem> GetAllItems();

        void AddTodo(string todoName);

        void ValueChanged(TodoItem changedItem);

        void DeletedItem(int id);

        void AddDescription(string descriptionName);

        void UpdateToDoDescription(int Id, string description);

        //SubTask
        IEnumerable<SubTask> GetSubTasks(int Id);

        void AddSubTask(string subTask, int ToDoId, DateTime Finish);

        void ValueChanged(SubTask changedSubTask);

        void DeleteSubTask(int id);

        void ChangeSubTaskFinishDate(int Id, DateTime FinishDate);
    }
}
