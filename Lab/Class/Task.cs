using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab.Interface;
using Lab.Enum;

namespace Lab.Class
{
    public class Task : IPrintable
    {
        public string Name { get; set; }
        public TaskStat CurrentStatus { get; set; } = TaskStat.ToDo;
        public IUserInfo? Assignee { get; set; } = null;

        public Task()
        {
            throw new NotImplementedException();
        }
        public Task(string name) : this()
        {
            throw new NotImplementedException();
        }
        public Task(string name, IUserInfo assignee) : this(name)
        {
            throw new NotImplementedException();
        }

        public void AssignEmployee(IUserInfo sessionUser, IUserInfo assignee)
        {
            throw new NotImplementedException();
        }

        public void UnassignEmployee(IUserInfo assignee, IUserInfo sessionUser)
        {
            throw new NotImplementedException();
        }
        public void ChangeName(IUserInfo sessionUser, string name)
        {
            throw new NotImplementedException();
        }
        public void MoveTask(IUserInfo assaignee, TaskStat NewStatus)
        {
            throw new NotImplementedException();
        }

        public string GetInfo()
        {
            throw new NotImplementedException();
        }
    }
}