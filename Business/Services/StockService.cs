using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database.Context;
using Database.Model;

namespace Business.Services
{
    public class StockService(IMSContext context)
    {
        private readonly IMSContext _context = context;

        public Result AddStock(Stock stock)
        {
            stock.Available_Stock = stock.Quantity_In - stock.Quantity_Out;
            stock.EntryDate = DateTime.UtcNow; 
            _context.Stock.Add(stock);
            return Result.DBcommit(_context, "Stock added successfully");
        }

        public Result DeleteStock(Stock stock)
        {
            _context.Stock.Remove(stock);
            return Result.DBcommit(_context, "Stock deleted successfully");
        }

        public Result UpdateStock(Stock stock)
        {
            stock.Available_Stock = stock.Quantity_In - stock.Quantity_Out;
            stock.EntryDate = DateTime.UtcNow; 
            _context.Stock.Update(stock);
            return Result.DBcommit(_context, "Stock updated successfully");
        }

        public Result GetAllStocks()
        {
            var stocks = _context.Stock.ToList();
            return new Result(true, "Stocks retrieved successfully", stocks);
        }

        public Result GetStock(int id)
        {
            var stock = _context.Stock.Find(id);
            if (stock == null)
                return new Result(false, "Stock not found");
            return new Result(true, "Stock retrieved successfully", stock);
        }

        public Result GetAvailableStocks()
        {
            var available = _context.Stock
                .GroupBy(s => s.P_Name.ToLower().Trim())
                .Select(g => new Stock
                {
                    P_Name = g.First().P_Name,
                    P_Id = g.First().P_Id,
                    Quantity_In = g.Sum(s => s.Quantity_In),
                    Quantity_Out = g.Sum(s => s.Quantity_Out),
                    Available_Stock = g.Sum(s => s.Quantity_In) - g.Sum(s => s.Quantity_Out)
                })
                .ToList();
            return new Result(true, "Available stocks retrieved", available);
        }
    }
}