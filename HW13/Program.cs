
using HW13.Entity;
using HW13.Entity.Enum;
using HW13.Servise;

UserServise userServise = new UserServise();
BookServise bookServise = new BookServise();
bool runUser = true;
bool run = true;

do
{
    Console.WriteLine("1-Register");
    Console.WriteLine("2-Login");
    Console.WriteLine("3-Exit");
    var log = Console.ReadLine();
    if (log != null)
    {
        if (log == "1")
        {
            Console.Write("enter username: ");
            var username = Console.ReadLine();
            Console.Write("enter password: ");
            var password = Console.ReadLine();
            Console.Write("enter role: ");
            var role = (EnumRole)int.Parse(Console.ReadLine());
            userServise.Register(username, password, role);
            Console.WriteLine("register is okey");
        }
        else if (log == "2")
        {
            Console.Write("enter username: ");
            var username = Console.ReadLine();
            Console.Write("enter password: ");
            var password = Console.ReadLine();
            if (userServise.Login(username, password) != null)
            {
                InMemory.OnlineUser = userServise.Login(username, password);
                if (InMemory.OnlineUser.Role == EnumRole.Person)
                {
                    do
                    {
                        Console.WriteLine("1- Get book");
                        Console.WriteLine("2- back book");
                        Console.WriteLine("3- your books");
                        Console.WriteLine("4- show books");
                        Console.WriteLine("5- Logout");
                        Console.WriteLine("----------------------------");
                        Console.Write("enter option");
                        var input = Console.ReadLine();
                        switch (input)
                        {
                            case "1":
                                {
                                    Console.WriteLine("enter book id : ");
                                    int.TryParse(Console.ReadLine(), out int id);
                                    bookServise.Select(id, InMemory.OnlineUser.Id);
                                }
                                break;
                            case "2":
                                {
                                    Console.WriteLine("enter book id : ");
                                    int.TryParse(Console.ReadLine(), out int id);
                                    bookServise.Back(id, InMemory.OnlineUser.Id);
                                }
                                break;
                            case "3":
                                {
                                    bookServise.UserBook(InMemory.OnlineUser.Id);
                                }
                                break;
                            case "4":
                                {
                                    bookServise.BookBook(InMemory.OnlineUser.Id);
                                }
                                break;
                            case "5":
                                {
                                    InMemory.OnlineUser = null;
                                    runUser = false;
                                }
                                break;
                            default:
                                Console.WriteLine("just NO 1 to 5");
                                break;
                        }
                    } while (runUser);
                }
                else if (InMemory.OnlineUser.Role == EnumRole.Admin)
                {
                    Console.WriteLine("1-Show all book");
                    Console.WriteLine("2-Show all users");
                    var input = Console.ReadLine();
                    if (input == "1")
                    {
                        bookServise.ShowAll();
                    }
                    else if(input == "2")
                    {
                        userServise.GetAll();
                    }
                    else if(input == "3")
                    {
                        InMemory.OnlineUser = null;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("just NO 1 to 3");
                    }
                }
                else
                {
                    Console.WriteLine("Role is not true");
                }

            }
            else
            {
                Console.WriteLine("accunt is not confirmation");
            }
        }
        else if (log == "3")
        {
            run=false;
        }
        else
        {
            Console.WriteLine("just NO 1 to 3");
        }
    }
} while (run);
