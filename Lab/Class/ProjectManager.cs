using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab.Interface;
using Lab.Enum;

namespace Lab.Class
{
    public class ProjectManager : IUserInfo, IPrintable
    {
        public string Name { get; set; }
        public string Email { get; set; }

        public ProjectManager()
        {
            throw new NotImplementedException();
        }
        public ProjectManager(string name)
        {
            throw new NotImplementedException();
        }

        public string GetInfo()
        {
            throw new NotImplementedException();
        }
    }
}
