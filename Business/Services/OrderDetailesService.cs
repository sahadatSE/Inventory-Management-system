using Database.Context;
using Database.Model;
using Microsoft.EntityFrameworkCore;

namespace Business.Services
{
    public class OrderDetailsService(IMSContext context)
    {
        private readonly IMSContext _context = context;

        public Result AddOrderDetails(OrderDetails details)
        {
            _context.OrderDetails.Add(details);
            return Result.DBcommit(_context, "Order details added successfully");
        }

        public Result UpdateOrderDetails(OrderDetails details)
        {
            var existing = _context.OrderDetails.Find(details.OrderDetailsId);
            if (existing == null)
                return new Result(false, "Order details not found");

            existing.PId = details.PId;
            existing.Quantity = details.Quantity;
            existing.UnitPrice = details.UnitPrice;

            _context.OrderDetails.Update(existing);
            return Result.DBcommit(_context, "Order details updated successfully");
        }

        public Result DeleteOrderDetails(int id)
        {
            var details = _context.OrderDetails.Find(id);
            if (details == null)
                return new Result(false, "Order details not found");

            _context.OrderDetails.Remove(details);
            return Result.DBcommit(_context, "Order details deleted successfully");
        }

        public Result GetAllOrderDetails()
        {
            var details = _context.OrderDetails
                .Include(d => d.Product)
                .Include(d => d.Order)
                .ToList();
            return new Result(true, "Order details retrieved successfully", details);
        }

        public Result GetOrderDetails(int id)
        {
            var details = _context.OrderDetails
                .Include(d => d.Product)
                .Include(d => d.Order)
                .FirstOrDefault(d => d.OrderDetailsId == id);

            if (details == null)
                return new Result(false, "Order details not found");

            return new Result(true, "Order details retrieved successfully", details);
        }

        public Result GetByOrderId(int orderId)
        {
            var details = _context.OrderDetails
                .Include(d => d.Product)
                .Where(d => d.OrderId == orderId)
                .ToList();

            return new Result(true, "Order details retrieved successfully", details);
        }

        public Result GetByProductId(int productId)
        {
            var details = _context.OrderDetails
                .Include(d => d.Order)
                .Where(d => d.PId == productId)
                .ToList();

            return new Result(true, "Order details retrieved successfully", details);
        }
    }
}