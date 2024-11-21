using HW13.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW13.Continer
{
    public interface IBookRepository
    {
        List<Book> GetAll();
        Book Get(int id);
        void Back(int id);
    }
}
