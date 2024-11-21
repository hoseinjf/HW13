using HW13.Continer;
using HW13.Entity;
using HW13.Entity.Enum;
using HW13.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW13.Servise
{
    public class UserServise
    {
        private readonly IUserRepository _userRepository;
        public UserServise()
        {
            _userRepository = new UserRepository();
        }
        public User Login(string username, string password)
        {
            var user=_userRepository.Login(username, password);
            if (user != null)
            {
                return user;
            }
            else
            {
                return null;
            }
        }
        public void Register(string username, string password, EnumRole enumRole) 
        {
            _userRepository.Register(username, password, enumRole);
        }
        public void GetAll()
        {
            foreach (var item in _userRepository.GetAll())
            {
                Console.WriteLine($"ID:{item.Id} - username:{item.Username}" +
                    $" - role:{item.Role}");
            }
        }


    }
}
