using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using EcomIntProject.Models;


namespace Userdatabase
{
    public class UserController
    {
        private readonly Usercontext _context;

        public UserController()
        {
            _context = new Usercontext();
        }

        public void RegisterUser()
        {
            Console.WriteLine("Enter user id");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter user name");
            string name = Console.ReadLine();
            Console.WriteLine("Enter the email");
            string email = Console.ReadLine();
            Console.WriteLine("Enter the password");
            string password = Console.ReadLine();
            Console.WriteLine("Enter the shipping address");
            string address = Console.ReadLine();
            Console.WriteLine("Enter the phone number");
            string phoneNumber = Console.ReadLine();

            User userclass = new User
            {
                UserId = id,
                Name = name,
                Email = email,
                Password = password,
                ShippingAddress = address,
                PhoneNumber = phoneNumber,
            };
            var context = new ValidationContext(userclass, null, null);
            var results = new List<ValidationResult>();
            bool isValid = Validator.TryValidateObject(userclass, context, results, true);

            if (!isValid)
            {
                foreach (var validationResult in results)
                    Console.WriteLine(validationResult.ErrorMessage);
                return;
            }

            _context.Users.Add(userclass);
            _context.SaveChanges();
            Console.WriteLine("User registered successfully!");
        }

        public bool LoginUser()
        {
            Console.WriteLine("Enter email");
            string email = Console.ReadLine();
            Console.WriteLine("Enter password");
            string password = Console.ReadLine();

            var user = _context.Users.SingleOrDefault(u => u.Email == email && u.Password == password);
            if (user != null)
            {
                Console.WriteLine("Login successful!");
                return true;
            }
            else
            {
                Console.WriteLine("Invalid email or password.");
                return false;
            }
        }

        public void GetUserById(int id)
        {
            var user = _context.Users.Find(id);
            if (user != null)
            {
                Console.WriteLine($"ID: {user.Id}, Name: {user.Name}, Email: {user.Email}, Address: {user.ShippingAddress}, Phone Number: {user.PhoneNumber}");
            }
            else
            {
                Console.WriteLine("User not found.");
            }
        }

        public void UpdateUser(int id)
        {
            var user = _context.Users.Find(id);
            if (user != null)
            {
                Console.WriteLine("Enter new user name");
                user.Name = Console.ReadLine();
                Console.WriteLine("Enter new email");
                user.Email = Console.ReadLine();
                Console.WriteLine("Enter new password");
                user.Password = Console.ReadLine();
                Console.WriteLine("Enter new shipping address");
                user.ShippingAddress = Console.ReadLine();
                Console.WriteLine("Enter new phone number");
                user.PhoneNumber = Console.ReadLine();

                _context.SaveChanges();
                Console.WriteLine("User updated successfully!");
            }
            else
            {
                Console.WriteLine("User not found.");
            }
        }

        public void DeleteUser(int id)
        {
            var user = _context.Users.Find(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
                Console.WriteLine("User deleted successfully!");
            }
            else
            {
                Console.WriteLine("User not found.");
            }
        }
    }
}