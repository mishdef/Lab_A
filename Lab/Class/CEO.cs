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
            throw new NotImplementedException();
        }
        public CEO(string name)
        {
            throw new NotImplementedException();
        }

        public string GetInfo()
        {
            throw new NotImplementedException();
        }
    }
}
