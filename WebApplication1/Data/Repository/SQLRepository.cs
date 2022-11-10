﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;
using Microsoft.EntityFrameworkCore;

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
                StatusId = 1,
                StatusName = _context.Statuses.Where(All => All.Id == 1).FirstOrDefault().Name,
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

        public IEnumerable<SubTask> GetSubTasks(int Id)
        {
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

        void IRepository.UpdateToDo(int Id, string todoName)
        {
            _context.TodoItems.Where(All => All.Id == Id).FirstOrDefault().Title = todoName;
            _context.SaveChanges();
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


        void IRepository.UpdateToDoPeople(int Id, string People)
        {
            _context.SubTasks.Where(All => All.Id == Id).FirstOrDefault().Worker = People;
            _context.SaveChanges();
        }


        object IRepository.CountTimeTask(int Id)
        {
            var Subtask= _context.SubTasks.Where(All => All.TodoIthemId == Id).ToList();
            long total=0;
            foreach(var i in Subtask)
            {
                total+=  i.Finish.Subtract(i.Start).Days;
                
            }
            return total+1;
        }

        object IRepository.CountTimeSubTask(int Id)
        {
            var Subtask = _context.SubTasks.Where(All => All.Id== Id).SingleOrDefault();
            long total = 0;
            
            total += Subtask.Finish.Subtract(Subtask.Start).Days;

            
            return total + 1;
        }

        public IEnumerable<Status> GetAllStatuses()
        {
            return _context.Statuses; 
        }

        public void ChangeStatus(TodoItem ithemchange)
        {
            var item=_context.TodoItems.Where(All=>All.Id== ithemchange.Id).FirstOrDefault();
            item.StatusId=ithemchange.StatusId;
            item.StatusName=_context.Statuses.Where(All=>All.Id==ithemchange.StatusId).FirstOrDefault().Name;

           
           _context.SaveChanges();

        }

        public Status FindById(int id) => _context.Statuses.ToList().Where(all => all.Id == id).FirstOrDefault();
        public bool TaskDate(int Id)
        {
            var Subtasks=_context.SubTasks.Where(All=>All.TodoIthemId==Id).ToList();
            var DateIsOk=true;
            foreach(var t in Subtasks)
            {
                if(t.Finish.AddDays(1)>DateTime.Now)
                    DateIsOk=false;
            }
            return DateIsOk;
        }

        public IEnumerable<Status> GetAvailableStatuses(TodoItem ithem)
        {
            var AvailableStatuses = new List<Status>();
            if (ithem.StatusId == 1)
            {
                return _context.Statuses.Where(All => All.Id == 2 || All.Id==1).ToList();
            }

            if (ithem.StatusId == 2 && TaskDate(ithem.Id))
            {
                return _context.Statuses.Where(All => All.Id == 3 || All.Id == 4).ToList();
            }

            if (ithem.StatusId == 3)
            {
                return _context.Statuses.Where(All => All.Id == 2 || All.Id == 4).ToList();
            }

            return new List<Status>();
        }
    }

}
