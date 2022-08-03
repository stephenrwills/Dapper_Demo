using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapper_Demo
{
    public interface IProductRepository
    {
        public IEnumerable<Product> GetAllProducts();
        public void CreateProduct(string newName, double newPrice, int newCategoryID);
        public void UpdateProductName(int newProductID, string newUpdatedName);

        public void DeleteProduct(int productID);


    }
}
