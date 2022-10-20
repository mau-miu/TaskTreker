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


        void UpdateToDoFinishDate(int Id, DateTime FinishDate);

        //SubTask
        IEnumerable<SubTask> GetSubTasks(int Id);

        void AddSubTask(string subTask, int ToDoId, DateTime Finish, string Worker); 

        void ValueChanged(SubTask changedSubTask);

        void DeleteSubTask(int id);

        void ChangeSubTaskFinishDate(int Id, DateTime FinishDate); //

        void ChangeSubTaskPeople(int Id, string People);
    }
}
