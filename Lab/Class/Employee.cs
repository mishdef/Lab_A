using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab.Interface;
using Lab.Enum;

namespace Lab.Class
{
    public class Employee : IUserInfo, IPrintable
    {
        public string Name { get; set; }
        public string Email { get; set; }

        public Employee()
        {
            Name = "Employee";
        }
        public Employee(string name)
        {
            Name = name;
        }

        public string GetInfo()
        {
            return $"[Employee] - {Name}";
        }
    }
}
