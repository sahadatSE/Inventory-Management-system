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
        public Result AddStock (Stock stock)
        {
            _context.Stock.Add(stock);
            return Result.DBcommit(_context, "Stock added successfully");
        }
        public Result DeleteStock (Stock stock)
        {
            _context.Stock.Remove(stock);
            return Result.DBcommit(_context, "Stock deleted successfully");
        }
        public Result UpdateStock (Stock stock)
        {
            _context.Stock.Update(stock);
            return Result.DBcommit(_context, "Stock updated successfully");
        }
        public Result GetAllStocks()
        {
            var stocks = _context.Stock.ToList();
            return new Result(true, "Stocks retrieved successfully", stocks);
        }
        public Result GetStock (int id)
        {
            var stock = _context.Stock.Find(id);
            if (stock == null)
            {
                return new Result(false, "Stock not found");
            }
            return new Result(true, "Stock retrieved successfully", stock);
        }

    }
}
