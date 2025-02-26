using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EcomIntProject.Models;
using Microsoft.EntityFrameworkCore;

namespace EcomIntProject.Controllers
{
    internal class CartItemController
    {
        EcomContext cartContext = new EcomContext();

        public List<CartItem> readAllData()
        {
            return cartContext.CartItems.ToList();
        }

        // Fetching specific entity Data
        public CartItem getData(int id)
        {
            return cartContext.CartItems.FirstOrDefault(e => e.CartItemId == id);
        }

        // Fetching CartDetails of a user using UserID
        public List<CartItem> getUserCartData(int id)
        {
            return cartContext.CartItems.Where(e => e.UserId == id).Include(e => e.Product).ToList();
        }

        // Creating new Data
        public void createData(CartItem newEntity)
        {
            cartContext.CartItems.Add(newEntity);
            cartContext.SaveChanges();
            Console.WriteLine($"\n\nEntity with ID ({newEntity.CartItemId}) has been created");
        }

        // Deleting specific Data
        public void delData(int id)
        {
            var entity = cartContext.Product.Find(id);
            if (entity != null)
            {
                cartContext.Product.Remove(entity);
                cartContext.SaveChanges();
                Console.WriteLine($"\n\nEntity with ID ({id}) has been deleted");
            }
            else
            {
                Console.WriteLine("\n\nEntity Not Found!!");
            }
        }
    }
}
