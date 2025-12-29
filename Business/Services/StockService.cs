using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database.Context;
using Database.Model;

namespace Business.Services
{
    public class StockService
    {
        public IMSContext context = new();
        public Result AddStock (Stock stock)
        {
            context.Stock.Add(stock);
            return Result.DBcommit(context, "Stock added successfully");
        }
        public Result DeleteStock (Stock stock)
        {
             context.Stock.Remove(stock);
            return Result.DBcommit(context, "Stock deleted successfully");
        }
        public Result UpdateStock (Stock stock)
        {
            context.Stock.Update(stock);
            return Result.DBcommit(context, "Stock updated successfully");
        }
        public Result GetAllStocks()
        {
            var stocks = context.Stock.ToList();
            return new Result(true, "Stocks retrieved successfully", stocks);
        }
        public Result GetStock (int id)
        {
            var stock = context.Stock.Find(id);
            if (stock == null)
            {
                return new Result(false, "Stock not found");
            }
            return new Result(true, "Stock retrieved successfully", stock);
        }

    }
}
