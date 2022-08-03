using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.IO;
using Dapper;

namespace Dapper_Demo
{
    public class DapperProductRepository : IProductRepository
    {
        private readonly IDbConnection _connection;

        public DapperProductRepository(IDbConnection connection)
        {
            _connection = connection;
        }



        public void CreateProduct(string newName, double newPrice, int newCategoryID)
        {
            _connection.Execute("INSERT INTO Products (Name, Price, CategoryID) VALUES (@name, @price, @categoryID;", new { name = newName, price = newPrice, categoryid = newCategoryID }); 
        }

        public void DeleteProduct(int productID)
        {
            _connection.Execute("DELETE FROM reviews WHERE ProductID = @productID;",
                new { productID = productID });

            _connection.Execute("DELETE FROM sales WHERE ProductID = @productID;",
               new { productID = productID });

            _connection.Execute("DELETE FROM products WHERE ProductID = @productID;",
               new { productID = productID });
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _connection.Query<Product>("SELECT * FROM products;");
        }

        public void UpdateProductName(int newProductID, string newUpdatedName)
        {
            _connection.Execute("UPDATE products SET Name = @updatedName WHERE ProductID = @productID;",
                new { updatedName = newUpdatedName, productID = newProductID });
        }
    }
}
