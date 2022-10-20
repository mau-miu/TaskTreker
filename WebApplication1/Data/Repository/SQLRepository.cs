using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Data.Repository
{
    public class SQLRepository : IRepository
    {
        private readonly DB _context;

        public SQLRepository(DB context)
        {
            _context = context;
        }

        public void AddTodo(string todoName)
        {   
            TodoItem newItem = new TodoItem()
            {
                Title = todoName,
                IsDone = false,
                
            };
            _context.TodoItems.Add(newItem);
            _context.SaveChanges();
        }

        void IRepository.AddDescription(string descriptionName)
        {
            TodoItem newDesc = new TodoItem()
            {
                Description = descriptionName
            };
            _context.TodoItems.Add(newDesc);
            _context.SaveChanges();
        }

        public void DeletedItem(int id)

        {
            var deletedItem = _context.TodoItems.Find(id);

            if(deletedItem!= null)
            {
                _context.TodoItems.Remove(deletedItem);
                _context.SaveChanges();
            }
        }

        public IEnumerable<TodoItem> GetAllItems()
        {
            return _context.TodoItems;
        }
        
        public void ValueChanged(TodoItem changedItem)
        {
            var item = _context.TodoItems.Attach(changedItem);
            item.State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            _context.SaveChanges();
         }


        //SubTask

        public IEnumerable<SubTask> GetSubTasks(int Id)
        {
            //var check = _context.TodoItems.Where(All => All.Id == Id).FirstOrDefault();
            var SubTasks = _context.SubTasks.Where(All=>All.TodoIthemId==Id);
            return SubTasks;
        }


        public void ValueChanged(SubTask changedSubTask)
        {
            var item = _context.SubTasks.Attach(changedSubTask);
            item.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        
            _context.SaveChanges();
        }


        public void AddSubTask(string subTask, int ToDoId, DateTime FinishDate, string People)
        {
            SubTask newSubTask = new SubTask()
            {
                Name = subTask,
                TodoIthemId = ToDoId,
                Finish = FinishDate,
                Worker = People
                
                //IsDone = false
            };

            _context.SubTasks.Add(newSubTask);
            _context.SaveChanges();
        }

        public void DeleteSubTask(int id)
        {
            var deletedSubTask = _context.SubTasks.Find(id);

            if(deletedSubTask != null)
            {
                _context.SubTasks.Remove(deletedSubTask);
                _context.SaveChanges();
            }
        }

        void IRepository.ChangeSubTaskFinishDate(int Id, DateTime FinishDate)
        {
            _context.SubTasks.Where(All=>All.Id==Id).FirstOrDefault().Finish = FinishDate;
        }

        void IRepository.ChangeSubTaskPeople(int Id, string People)
        {
            _context.SubTasks.Where(All => All.Id == Id).FirstOrDefault().Worker = People;
        }


        void IRepository.UpdateToDoDescription(int Id, string Description)
        {
            _context.TodoItems.Where(All=>All.Id==Id).FirstOrDefault().Description=Description;
            _context.SaveChanges();
        }

        void IRepository.UpdateToDoFinishDate(int Id, DateTime FinishDate)
        {
            _context.SubTasks.Where(All => All.Id == Id).FirstOrDefault().Finish = FinishDate;
            _context.SaveChanges();
        }
    }
}
