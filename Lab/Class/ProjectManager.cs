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
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public ProjectManager()
        {
            Name = "ProjectManager";
            Id = ++IUserInfo.id;
        }
        public ProjectManager(string name)
        {
            Name = name;
            Id = ++IUserInfo.id;
        }

        public string GetInfo()
        {
            throw new NotImplementedException();
        }
    }
}
