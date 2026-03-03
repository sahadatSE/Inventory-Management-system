using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database.Context;
using Database.Model;

namespace Business.Services
{
    public class ProductService (IMSContext context)
    {
        private readonly IMSContext _context = context;
        public Result AddProduct(Product product)
        {
            _context.Product.Add(product);
            return Result.DBcommit(_context, "Product added successfully");
        }
        public Result DeleteProduct(Product product)
        {
            _context.Product.Remove(product);
            return Result.DBcommit(_context, "Product deleted successfully");
        }
        public Result UpdateProduct(Product product)
        {
            _context.Product.Update(product);
            return Result.DBcommit(_context, "Product updated successfully");
        }
        public Result GetAllProduct()
        {
            var products = _context.Product.ToList();
            return new Result(true, "Products retrieved successfully", products);
        }
        public Result GetProduct(int id)
        {
            var product = _context.Product.Find(id);
            if (product == null)
            {
                return new Result(false, "Product not found");
            }
            return new Result(true, "Product retrieved successfully", product);
        }
    }
}
