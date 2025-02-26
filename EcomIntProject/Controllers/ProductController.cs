using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EcomIntProject.Models;

namespace EcomIntProject.Controllers
{
    internal class ProductController
    {
        EcomContext classContext = new EcomContext();


        // Fetching Data
        public List<Product> readAllData()
        {
            return classContext.Product.ToList();
        }

        // Fetching specific entity Data
        public Product getData(int id)
        {
            return classContext.Product.FirstOrDefault(e => e.ProductId == id);
        }

        // Creating new Data
        public void createData(Product newEntity)
        {
            classContext.Product.Add(newEntity);
            classContext.SaveChanges();
            Console.WriteLine($"\n\nEntity with ID ({newEntity.ProductId}) has been created");
        }

        // Deleting specific Data
        public void delData(int id)
        {
            var entity = classContext.Product.Find(id);
            if (entity != null)
            {
                classContext.Product.Remove(entity);
                classContext.SaveChanges();
                Console.WriteLine($"\n\nEntity with ID ({id}) has been deleted");
            }
            else
            {
                Console.WriteLine("\n\nEntity Not Found!!");
            }
        }
    }
}
