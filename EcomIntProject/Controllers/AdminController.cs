using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcomIntProject.Controllers
{
    public class AdminController
    {
        private readonly AdminContext _context;

        public AdminController()
        {
            _context = new AdminContext();
        }

        public void Login(AdminClass admin)
        {
            // Implement your login logic here
            Console.WriteLine("Login successful for Admin: " + admin.AdminName);
        }

        // Fetching Data
        public List<AdminClass> ReadAllData()
        {
            return _context.Admins.ToList();
        }

        // Fetching specific entity Data
        public AdminClass GetData(int id)
        {
            return _context.Admins.FirstOrDefault(e => e.AdminId == id);
        }

        // Creating new Data
        public void CreateData(AdminClass newEntity)
        {
            _context.Admins.Add(newEntity);
            _context.SaveChanges();
            Console.WriteLine($"\n\nEntity with ID ({newEntity.AdminId}) has been created");
        }

        // Deleting specific Data
        public void DeleteData(int id)
        {
            var entity = _context.Admins.Find(id);
            if (entity != null)
            {
                _context.Admins.Remove(entity);
                _context.SaveChanges();
                Console.WriteLine($"\n\nEntity with ID ({id}) has been deleted");
            }
            else
            {
                Console.WriteLine("\n\nEntity Not Found!!");
            }
        }
    }
}
