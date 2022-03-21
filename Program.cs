using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.ComponentModel;
using System.Data;

namespace BestBuyBestProducts
{
    class Program
    {
        static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            string connString = config.GetConnectionString("DefaultConnection");
            IDbConnection conn = new MySqlConnection(connString);

           /* var repo = new DapperDepartmentRepository(conn);

            Console.WriteLine("Type The New Dept Name");

            var newDept = Console.ReadLine();

            repo.InsertDepartment(newDept);

            var depts = repo.GetAllDepts();

            foreach( var departments in depts)
            {
                Console.WriteLine($"{departments.Name},{departments.DepartmentID}");
            }
           */
            Console.WriteLine("=================================================");
         
            var repo2 = new DapperProductRepository(conn);

           Console.WriteLine("Name of  a new product");

            var newProductName = Console.ReadLine();

            Console.WriteLine("Enter Price");

            var price = double.Parse(Console.ReadLine());

            Console.WriteLine("Enter ID");

            var categoryID = int.Parse(Console.ReadLine());

            repo2.CreateProduct(newProductName, price, categoryID);
          
            

            var products = repo2.GetAllProducts();

            foreach(var pro in products)
            {
                Console.WriteLine($"{pro.Name}, {pro.Price}, {pro.CategoryID}");
            }
  

            Console.WriteLine("This Dapper updates");
            var repo3 = new DapperProductRepository(conn);
            // updating the name and product ID
            Console.WriteLine("Enter the ID you want to update");
            var id = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter the new name");
            var newName =  Console.ReadLine();

            repo3.UpdateProduct(id, newName); 
         
        }
    }
}