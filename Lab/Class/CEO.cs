using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab.Interface;

namespace Lab.Class
{
    public class CEO : IUserInfo, IPrintable
    {
        public string Name { get; set; }
        public string Email { get; set; }

        public CEO()
        {
            Name = "CEO";
        }
        public CEO(string name)
        {
            Name = name;
        }

        public string GetInfo()
        {
            return $"[CEO] - {Name}";
        }
    }
}
