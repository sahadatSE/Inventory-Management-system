using System.Linq;
using Database.Context;
using Database.Model;

namespace Business.Services
{
    public class OrderService (IMSContext context)
    {
        private readonly IMSContext _context = context;

        public Result AddOrder(Order order)
        {
            _context.Order.Add(order);
            return Result.DBcommit(_context, "Order added successfully");
        }

        public Result UpdateOrder(Order order)
        {
            _context.Order.Update(order);
            return Result.DBcommit(_context, "Order updated successfully");
        }

        public Result DeleteOrder(Order order)
        {
            _context.Order.Remove(order);
            return Result.DBcommit(_context, "Order deleted successfully");
        }

        public Result GetOrder(int id)
        {
            var order = _context.Order.Find(id);
            if (order == null)
                return new Result(false, "Order not found");

            return new Result(true, "Order retrieved successfully", order);
        }

  
        public Result GetAllOrder()
        {
            var orders = _context.Order.ToList();
            return new Result(true, "Orders retrieved successfully", orders);
        }
    }
}
