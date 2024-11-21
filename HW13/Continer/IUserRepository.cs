using HW13.Entity;
using HW13.Entity.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW13.Continer
{
    public interface IUserRepository
    {
        void Register(string username, string password, EnumRole enumRole);
        User Login(string username, string password);
        List<User> GetAll();
    }
}
