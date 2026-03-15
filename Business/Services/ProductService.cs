using Database.Context;
using Database.Model;

namespace Business.Services
{
    public class ProductService(IMSContext context)
    {
        private readonly IMSContext _context = context;

        public Result AddProduct(Product product)
        {
            bool exists = _context.Product.Any(p => p.PName == product.PName);
            if (exists)
                return new Result(false, "Product already exists");

            _context.Product.Add(product);
            return Result.DBcommit(_context, "Product added successfully");
        }

        public Result UpdateProduct(Product product)
        {
            var existing = _context.Product.Find(product.PId);
            if (existing == null)
                return new Result(false, "Product not found");

            bool exists = _context.Product.Any(p => p.PName == product.PName && p.PId != product.PId);
            if (exists)
                return new Result(false, "Product name already exists");

            existing.PName = product.PName;
            existing.Category = product.Category;

            _context.Product.Update(existing);
            return Result.DBcommit(_context, "Product updated successfully");
        }

        public Result DeleteProduct(Product product)
        {
            _context.Product.Remove(product);
            return Result.DBcommit(_context, "Product deleted successfully");
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
                return new Result(false, "Product not found");
            return new Result(true, "Product retrieved successfully", product);
        }

        public Result GetByCategory(string category)
        {
            var products = _context.Product
                .Where(p => p.Category == category)
                .ToList();
            return new Result(true, "Products retrieved successfully", products);
        }
    }
}