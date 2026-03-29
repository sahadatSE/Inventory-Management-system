using Database.Context;
using Database.Model;
using Microsoft.EntityFrameworkCore;

namespace Business.Services
{
    public class StockService(IMSContext context)
    {
        private readonly IMSContext _context = context;

        public Result AddStock(Stock stock)
        {
            stock.EntryDate = DateTime.UtcNow;
            _context.Stock.Add(stock);
            return Result.DBcommit(_context, "Stock added successfully");
        }

        public Result UpdateStock(Stock stock)
        {
            var existing = _context.Stock.Find(stock.Stock_Id);
            if (existing == null)
                return new Result(false, "Stock not found");

            existing.Quantity_In = stock.Quantity_In;
            existing.Quantity_Out = stock.Quantity_Out;
            existing.Price = stock.Price;
            existing.Category = stock.Category;
            existing.P_Id = stock.P_Id;
            existing.UserName = stock.UserName;
            existing.EntryDate = DateTime.UtcNow;

            _context.Stock.Update(existing);
            return Result.DBcommit(_context, "Stock updated successfully");
        }

        public Result DeleteStock(Stock stock)
        {
            _context.Stock.Remove(stock);
            return Result.DBcommit(_context, "Stock deleted successfully");
        }

        public Result DeleteStock(int id)
        {
            var stock = _context.Stock.Find(id);
            if (stock == null)
                return new Result(false, "Stock not found");

            _context.Stock.Remove(stock);
            return Result.DBcommit(_context, "Stock deleted successfully");
        }

        public Result GetAllStocks()
        {
            var stocks = _context.Stock
                .Include(s => s.Product)
                .ToList();
            return new Result(true, "Stocks retrieved successfully", stocks);
        }

        public Result GetStock(int id)
        {
            var stock = _context.Stock
                .Include(s => s.Product)
                .FirstOrDefault(s => s.Stock_Id == id);
            if (stock == null)
                return new Result(false, "Stock not found");
            return new Result(true, "Stock retrieved successfully", stock);
        }

        public Result GetAvailableStocks()
        {
            var available = _context.Stock
                .Include(s => s.Product)
                .Where(s => s.Product != null)
                .GroupBy(s => new { s.P_Id, s.Category }) 
                .Select(g => new Stock
                {
                    P_Id = g.Key.P_Id,
                    Quantity_In = g.Sum(s => s.Quantity_In),
                    Quantity_Out = g.Sum(s => s.Quantity_Out),
                    Category = g.Key.Category,         
                    Product = g.First().Product
                })
                .ToList();
            return new Result(true, "Available stocks retrieved", available);
        }
    }
}