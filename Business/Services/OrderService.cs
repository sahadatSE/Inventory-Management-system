using System.Linq;
using Database.Context;
using Database.Model;

namespace Business.Services
{
    public class OrderService
    {
        public IMSContext context = new();

        public Result AddOrder(Order order)
        {
            context.Order.Add(order);
            return Result.DBcommit(context, "Order added successfully");
        }

        public Result UpdateOrder(Order order)
        {
            context.Order.Update(order);
            return Result.DBcommit(context, "Order updated successfully");
        }

        public Result DeleteOrder(Order order)
        {
            context.Order.Remove(order);
            return Result.DBcommit(context, "Order deleted successfully");
        }

        public Result GetOrder(int id)
        {
            var order = context.Order.Find(id);
            if (order == null)
                return new Result(false, "Order not found");

            return new Result(true, "Order retrieved successfully", order);
        }

  
        public Result GetAllOrder()
        {
            var orders = context.Order.ToList();
            return new Result(true, "Orders retrieved successfully", orders);
        }
    }
}
