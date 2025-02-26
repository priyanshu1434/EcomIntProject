using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EcomIntProject.Models;

namespace EcomIntProject.Controllers
{
    internal class OrderController
    {
            EcomContext orderContext = new EcomContext();


        // Fetching Data
        public List<Order> readAllData()
        {
            return orderContext.Orders.ToList();
        }



        // Fetching specific entity Data
        public Order getData(int id)
        {
            return orderContext.Orders.FirstOrDefault(e => e.OrderId == id);
        }

        //Creating new Data
        public void createData(Order newEntity)
        {
            orderContext.Orders.Add(newEntity);
            orderContext.SaveChanges();
            Console.WriteLine($"\n\nEntity with ID ({newEntity.OrderId}) has been created");
        }

        // Deleting specific Data
        public void delData(int id)
        {
            var entity = orderContext.Orders.Find(id);
            if (entity != null)
            {
                orderContext.Orders.Remove(entity);
                orderContext.SaveChanges();
                Console.WriteLine($"\n\nEntity with ID ({id}) has been deleted");
            }
            else
            {
                Console.WriteLine("\n\nEntity Not Found!!");
            }
        }
    }
}
