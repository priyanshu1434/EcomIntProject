using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Userdatabase;

namespace EcomIntProject.Controllers
{
    internal class UserOperations
    {
        private readonly UserController _userController;

        public UserOperations()
        {
            _userController = new UserController();
        }

        public void Run()
        {
            while (true)
            {
                Console.WriteLine("Choose an option:");
                Console.WriteLine("1. Register User");
                Console.WriteLine("2. Login User");
                Console.WriteLine("3. Exit");

                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        _userController.RegisterUser();
                        break;
                    case 2:
                        if (_userController.LoginUser())
                        {
                            ManageUserOperations();
                        }
                        break;
                    case 3:
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        private void ManageUserOperations()
        {
            while (true)
            {
                Console.WriteLine("Choose an option:");
                Console.WriteLine("1. Get User by ID");
                Console.WriteLine("2. Update User");
                Console.WriteLine("3. Delete User");
                Console.WriteLine("4. Logout");

                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Enter user ID:");
                        int id = int.Parse(Console.ReadLine());
                        _userController.GetUserById(id);
                        break;
                    case 2:
                        Console.WriteLine("Enter user ID:");
                        id = int.Parse(Console.ReadLine());
                        _userController.UpdateUser(id);
                        break;
                    case 3:
                        Console.WriteLine("Enter user ID:");
                        id = int.Parse(Console.ReadLine());
                        _userController.DeleteUser(id);
                        break;
                    case 4:
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }
    }
}

