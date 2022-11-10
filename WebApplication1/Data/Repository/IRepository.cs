﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Data.Repository
{
   public interface IRepository
    {
        IEnumerable<TodoItem> GetAllItems();

        IEnumerable<Status> GetAvailableStatuses(TodoItem ithem);

        void AddTodo(string todoName);

        void ValueChanged(TodoItem changedItem);

        void DeletedItem(int id);

        void AddDescription(string descriptionName);

        void UpdateToDoDescription(int Id, string description);

        void UpdateToDo(int Id, string todoName);

        object CountTimeTask(int Id);

        object CountTimeSubTask(int Id);

        void UpdateToDoFinishDate(int Id, DateTime FinishDate);

        void UpdateToDoPeople(int Id, string People);

        IEnumerable<SubTask> GetSubTasks(int Id);

        void AddSubTask(string subTask, int ToDoId, DateTime Finish, string Worker); 

        void ValueChanged(SubTask changedSubTask);

        void DeleteSubTask(int id);

        void ChangeSubTaskFinishDate(int Id, DateTime FinishDate); 

        void ChangeSubTaskPeople(int Id, string People);

        void ChangeStatus(TodoItem ithem);

    }
}
