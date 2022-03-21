using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestBuyBestProducts
{
    public class DapperProductRepository : IProductRepository
    {

        private readonly IDbConnection _connection;

        // This is a constructor
        public DapperProductRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public void CreateProduct(string name, double price, int categoryID)
        {
            _connection.Execute("INSERT INTO PRODUCTS (Name,Price, CategoryID) VALUES (@productName,@productPrice, @catID);",
                new {productName = name, productPrice = price, catID = categoryID });
        }

        public IEnumerable<Products> GetAllProducts()
        {
            return _connection.Query<Products>("SELECT * FROM Products").ToList();
        }
        public void UpdateProduct(int productID, string updatedName)
        {
            _connection.Execute("UPDATE products SET Name = @updatdeName WHERE ProductID = @productID;",
                new { updatedName = updatedName, productID = productID });
        }
        public void DeleteProduct(int productID)
        {
            _connection.Execute("DELETE FROM reviews WHERE ProductID = @productID;",
                new { productID = productID });
            _connection.Execute("DELETE FROM sales WHERE ProductID = @productID",
                new {productID = productID});
        }
    }
}
    