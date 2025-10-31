using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab.Interface;

namespace Lab.Class
{
    public class Company
    {
        public string Name { get; set; }
        public List<IUserInfo> Employees { get; set; } = new List<IUserInfo>();
        public List<ProjectBoard> ProjectBoards { get; } = new List<ProjectBoard>();

        public Company(IUserInfo CEO)
        {
            throw new NotImplementedException();
        }

        public Company(IUserInfo CEO, string name) : this(CEO)
        {
            throw new NotImplementedException();
        }

        public void CreateProjectBoard(IUserInfo sessionUser, string name)
        {
            throw new NotImplementedException();
        }
        public void AddEmployee(IUserInfo sessionUser, IUserInfo newEmployee)
        {
            throw new NotImplementedException();
        }
        public void ChangeName(IUserInfo sessionUser, string name)
        {
            throw new NotImplementedException();
        }
        public void RemoveEmployee(IUserInfo sessionUser, IUserInfo employee)
        {
            throw new NotImplementedException();
        }
        public void RemoveProjectBoard(IUserInfo sessionUser, ProjectBoard projectBoard)
        {
            throw new NotImplementedException();
        }
    }
}
