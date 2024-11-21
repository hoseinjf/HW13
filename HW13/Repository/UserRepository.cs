using HW13.Context;
using HW13.Continer;
using HW13.Entity;
using HW13.Entity.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW13.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _appDbContext;
        public UserRepository()
        {
            _appDbContext = new AppDbContext();
        }
        public User Login(string username, string password)
        {
            var user = _appDbContext.Users.FirstOrDefault(user => user.Username == username 
            && user.Password==password && user.CheckRole==true);
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
            User user = new User()
            {
                Username = username,
                Password = password,
                Role = enumRole
            };
            _appDbContext.Users.Add(user);
            _appDbContext.SaveChanges();
        }
        public List<User> GetAll() 
        {
            return _appDbContext.Users.ToList();
        }
    }
}
