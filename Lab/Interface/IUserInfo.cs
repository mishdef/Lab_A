using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Interface
{
    public interface IUserInfo
    {
        static int id = 0;

        int Id { get; set; }
        string Name { get; set; }
        string Email { get; set; }
    }
}
