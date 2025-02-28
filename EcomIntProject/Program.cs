// See https://aka.ms/new-console-template for more information
// Read and print all data
using EcomIntProject.Controllers;
using EcomIntProject.Models;




ProductController product = new ProductController();
OrderController order     = new OrderController();


Console.WriteLine("List of all entities: ");
List<Product> data = product.readAllProductData();
foreach (Product entityClass in data)
{
    Console.WriteLine($"{entityClass.ProductId} | {entityClass.Name} | {entityClass.Description} | {entityClass.Price} | {entityClass.Category}");
}


Console.WriteLine("\n\nFetching entity with id");
var getDataofPerson = product.getProductData(102);
if (getDataofPerson != null)
{
    Console.WriteLine($"ID: {getDataofPerson.ProductId}, Name: {getDataofPerson.Name}, Description: {getDataofPerson.Description}");
}
else
{
    Console.WriteLine("Entity not found.");
}

Console.WriteLine("\n\nList of all orders: ");
List<Order> orderdata = order.readAllOrderData();
foreach (Order entityClass in orderdata)
{
    Console.WriteLine($"{entityClass.OrderId} | {entityClass.ProductId} | {entityClass.TotalPrice} | {entityClass.ShippingAddress} | {entityClass.OrderStatus} | {entityClass.PaymentStatus} | {entityClass.OrderDate}");
}

CartItemController cartItemController = new CartItemController();
Console.WriteLine("\n\nFetching CartItems of a specific User with Id: ");
List<CartItem> cartItems = cartItemController.getUserCartData(1001);
double totalCartPrice = 0;
foreach (CartItem cartItem in cartItems)
{
    totalCartPrice += cartItem.Product.Price * cartItem.Quantity;
    Console.WriteLine($"Product: {cartItem.Product.Name}, Description: {cartItem.Product.Description}, Total Price: {cartItem.Product.Price * cartItem.Quantity} Rs, Quantity: {cartItem.Quantity}");

}
Console.WriteLine($"Total Cart Price:  {totalCartPrice} Rs");

List<Order> orderItems = order.getUserOrderData(1001);
foreach (Order orderItem in orderItems)
{
    Console.WriteLine($" {orderItem.OrderId} | Product: {orderItem.Product.Name}, Description: {orderItem.Product.Description}, Total Price: {orderItem.TotalPrice} Rs, Shipping Address: {orderItem.ShippingAddress}, Order Status: {orderItem.OrderStatus}, Payment status: {orderItem.PaymentStatus}, Date: {orderItem.OrderDate}");

}