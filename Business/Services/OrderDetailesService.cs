using System.Linq;
using Database.Context;
using Database.Model;

namespace Business.Services
{
    public class OrderDetailesService(IMSContext context)
    {
        private readonly IMSContext _context = context;

        public Result AddOrderDetails(OrderDetails orderDetails)
        {
            _context.OrderDetails.Add(orderDetails);
            return Result.DBcommit(_context, "OrderDetails added successfully");
        }

        public Result UpdateOrderDetails(OrderDetails orderDetails)
        {
            _context.OrderDetails.Update(orderDetails);
            return Result.DBcommit(_context, "OrderDetails updated successfully");
        }

        public Result DeleteOrderDetails(OrderDetails orderDetails)
        {
            _context.OrderDetails.Remove(orderDetails);
            return Result.DBcommit(_context, "OrderDetails deleted successfully");
        }

        public Result GetAllOrderDetails()
        {
            var orderDetails = _context.OrderDetails.ToList();
            return new Result(true, "OrderDetails retrieved successfully", orderDetails);
        }

       
        public Result GetOrderDetails(int O_Id)
        {
            var orderDetails = _context.OrderDetails.Find(O_Id);

            if (orderDetails == null)
                return new Result(false, "OrderDetails not found");

            return new Result(true, "OrderDetails retrieved successfully", orderDetails);
        }
    }
}

