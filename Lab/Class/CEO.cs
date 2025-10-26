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
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public CEO()
        {
            Name = "CEO";
            Id = ++IUserInfo.id;
        }
        public CEO(string name)
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
