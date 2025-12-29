using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database.Context;
using Database.Model;

namespace Business.Services
{
    public class ProductService
    {
        public IMSContext context = new();
        public Result AddProduct(Product product)
        {
            context.Product.Add(product);
            return Result.DBcommit(context, "Product added successfully");
        }
        public Result DeleteProduct(Product product)
        {
            context.Product.Remove(product);
            return Result.DBcommit(context, "Product deleted successfully");
        }
        public Result UpdateProduct(Product product)
        {
            context.Product.Update(product);
            return Result.DBcommit(context, "Product updated successfully");
        }
        public Result GetAllProduct()
        {
            var products = context.Product.ToList();
            return new Result(true, "Products retrieved successfully", products);
        }
        public Result GetProduct(int id)
        {
            var product = context.Product.Find(id);
            if (product == null)
            {
                return new Result(false, "Product not found");
            }
            return new Result(true, "Product retrieved successfully", product);
        }
    }
}
