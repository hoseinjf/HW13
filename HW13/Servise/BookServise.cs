using HW13.Continer;
using HW13.Entity;
using HW13.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW13.Servise
{
    public class BookServise
    {
        private readonly IBookRepository _bookRepository;
        public BookServise()
        {
            _bookRepository = new BookRepository();
        }
        public void ShowAll()
        {
            //چاپ کل کتاب های موجود
            foreach (var item in _bookRepository.GetAll())
            {
                Console.WriteLine($"ID:{item.Id} - Book Name:{item.Title} - " +
                    $"Author:{item.Author} - Description:{item.Description} - Status: {item.IsTrust}");
                Console.WriteLine("-----------------------------------------");
            }
        }
        public void Select(int id, int userId)
        {
            //چاپ کتاب های موجود
            foreach (var item in _bookRepository.GetAll())
            {
                if (item.IsTrust == false)
                {
                    Console.WriteLine($"ID:{item.Id} - Book Name:{item.Title} - " +
                    $"Author:{item.Author} - Description:{item.Description}");
                    Console.WriteLine("-----------------------------------------");
                }
            }
            //انتخاب کتاب مورد نظر
            var book = _bookRepository.Get(id);
            if (book != null)
            {
                if (book.IsTrust == false)
                {
                    book.IsTrust = true;
                    book.UserId = userId;
                    Console.WriteLine("Book Trust for you");
                }
                else
                {
                    Console.WriteLine("Book non-existent");
                }
            }
            else
            {
                Console.WriteLine("Book invalid");
            }
        }
        public void Back(int id, int userId)
        {
            //چاپ کتاب های کاربر
            foreach (var item in _bookRepository.GetAll())
            {
                if (item.UserId == userId)
                {
                    Console.WriteLine($"ID:{item.Id} - Book Name:{item.Title} - " +
                    $"Author:{item.Author} - Description:{item.Description}");
                    Console.WriteLine("-----------------------------------------");
                }
            }
            var book = _bookRepository.Get(id);
            if (book != null)
            {
                if (book.IsTrust == true)
                {
                    book.IsTrust = false;
                    book.UserId = 0;
                    Console.WriteLine("book is back libry");
                }
                else
                {
                    Console.WriteLine("Book non-existent");
                }
            }
            else
            {
                Console.WriteLine("Book invalid");
            }
        }
        public void UserBook(int userId)
        {
            //چاپ کتاب های کاربر
            foreach (var item in _bookRepository.GetAll())
            {
                if (item.UserId == userId)
                {
                    Console.WriteLine($"ID:{item.Id} - Book Name:{item.Title} - " +
                    $"Author:{item.Author} - Description:{item.Description}");
                    Console.WriteLine("-----------------------------------------");
                }
            }
        }

        public void BookBook(int userId) 
        {
            foreach (var item in _bookRepository.GetAll())
            {
                if (item.IsTrust == false)
                {
                    Console.WriteLine($"ID:{item.Id} - Book Name:{item.Title} - " +
                    $"Author:{item.Author} - Description:{item.Description}");
                    Console.WriteLine("-----------------------------------------");
                }
            }
        }

    }
}
