using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW13.Config
{
    public static class DbConfig
    {
        public static String ConnectionString { get; set; }
        static DbConfig()
        {
            ConnectionString = @"Server=DESKTOP-1MKPIBC;Database=LibrarySystem;Integrated Security=True;TrustServerCertificate=True;";
        }
    }
}
