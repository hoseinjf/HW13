using HW13.Entity.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW13.Entity
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Username { get; set; }
        [Required]
        [MaxLength(50)]
        public string Password { get; set; }
        public bool CheckRole { get; set; } = false;
        public List<Book> Books { get; set; }=new List<Book>();
        public EnumRole Role { get; set; }

    }
}
