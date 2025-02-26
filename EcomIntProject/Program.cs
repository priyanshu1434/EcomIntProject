// See https://aka.ms/new-console-template for more information
// Read and print all data
using EcomIntProject.Controllers;
using EcomIntProject.Models;

ProductController product = new ProductController();

Console.WriteLine("List of all entities: ");
List<Product> data = product.readAllData();
foreach (Product entityClass in data)
{
    Console.WriteLine($"{entityClass.ProductId} | {entityClass.Name} | {entityClass.Description} | {entityClass.Price} | {entityClass.Category}");
}


Console.WriteLine("\n\nFetching entity with id");
var getDataofPerson = product.getData(102);
if (getDataofPerson != null)
{
    Console.WriteLine($"ID: {getDataofPerson.ProductId}, Name: {getDataofPerson.Name}, Description: {getDataofPerson.Description}");
}
else
{
    Console.WriteLine("Entity not found.");
}