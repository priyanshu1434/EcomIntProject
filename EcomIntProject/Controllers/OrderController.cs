using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EcomIntProject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace EcomIntProject.Controllers
{
    internal class OrderController
    {
            EcomContext orderContext = new EcomContext();


        // Fetching Data
        public List<Order> readAllOrderData()
        {
            return orderContext.Orders.ToList();
        }



        // Fetching specific entity Data
        public Order getOrderData(int id)
        {
            return orderContext.Orders.FirstOrDefault(e => e.OrderId == id);
        }

        public List<Order> getUserOrderData(int id)
        {
            return orderContext.Orders.Where(e => e.UserId == id).Include(e => e.Product).ToList();
        }

        //Creating new Data
        public void createOrderData(Order newEntity)
        {
            orderContext.Orders.Add(newEntity);
            orderContext.SaveChanges();
            Console.WriteLine($"\n\nEntity with ID ({newEntity.OrderId}) has been created");
        }

        // Deleting specific Data
        public void delOrderData(int id)
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
