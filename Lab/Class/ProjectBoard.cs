﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab.Interface;
using Lab.Enum;

namespace Lab.Class
{
    public class ProjectBoard : IPrintable
    {
        public string Name { get; set; }
        public List<Task> Tasks { get; } = new List<Task>();

        public ProjectBoard()
        {
            Name = "ProjectBoard";
        }
        public ProjectBoard(string name)
        {
            Name = name;
        }

        public Task AddTask(IUserInfo sessionUser, string taskName)
        {
            if (PermissionService.CanInteractWithProjectBoard(sessionUser))
            {
                Tasks.Add(new Task(taskName));
                return Tasks.Last();
            }
            else
            {
                throw new Exception("Only CEO and ProjectManager can add task");
            }
        }
        public void RemoveTask(IUserInfo assignee, Task task)
        {
            if (PermissionService.CanInteractWithProjectBoard(assignee))
            {
                Tasks.Remove(task);
            }
            else
            {
                throw new Exception("Only CEO and ProjectManager can remove task");
            }
        }
        public void ChangeName(IUserInfo sessionUser, string name)
        {
            if (PermissionService.CanInteractWithProjectBoard(sessionUser))
            {
                Name = name;
            }
            else
            {
                throw new Exception("Only CEO and ProjectManager can change name");
            }
        }
        public string GetInfo()
        {
            return $"[Project Board] - {Name}. Tasks: {Tasks.Count}";
        }
    }
}
