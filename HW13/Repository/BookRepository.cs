using HW13.Context;
using HW13.Continer;
using HW13.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW13.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly AppDbContext _appDbContext;
        public BookRepository()
        {
            _appDbContext=new AppDbContext();
        }
        public void Back(int id)
        {
            throw new NotImplementedException();
        }

        public List<Book> GetAll()
        {
            return _appDbContext.Books.ToList();
        }

        public Book Get(int id)
        {
            var book = _appDbContext.Books.FirstOrDefault(x=>x.Id==id);
            return book;
        }
    }
}
