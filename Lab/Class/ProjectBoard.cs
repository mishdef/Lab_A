using System;
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
            throw new NotImplementedException();
        }
        public ProjectBoard(string name)
        {
            throw new NotImplementedException();
        }

        public Task AddTask(IUserInfo sessionUser, string taskName)
        {
            throw new NotImplementedException();
        }

        public void RemoveTask(IUserInfo assignee, Task task)
        {
            throw new NotImplementedException();
        }

        public void ChangeName(IUserInfo sessionUser, string name)
        {
            throw new NotImplementedException();
        }
        public string GetInfo()
        {
            throw new NotImplementedException();
        }
    }
}
