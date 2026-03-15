using Business;
using Database.Context;
using Database.Model;
using Microsoft.EntityFrameworkCore;

namespace Business.Services
{
    public class OrderService(IMSContext context)
    {
        private readonly IMSContext _context = context;

        public Result AddOrder(Order order, List<OrderDetails> details)
        {
          
            foreach (var detail in details)
            {
                int available = _context.Stock
                    .Where(s => s.P_Id == detail.PId)
                    .Sum(s => s.Quantity_In) -
                    _context.Stock
                    .Where(s => s.P_Id == detail.PId)
                    .Sum(s => s.Quantity_Out);

                if (available < detail.Quantity)
                {
                    var product = _context.Product.Find(detail.PId);
                    return new Result(false, $"{product?.PName} এর stock পর্যাপ্ত নেই। Available: {available}");
                }
            }

            
            order.TotalAmount = details.Sum(d => d.TotalPrice);
            order.OrderDate = DateTime.UtcNow;
            order.OrderDetails = details;

            _context.Order.Add(order);
            return Result.DBcommit(_context, "Order placed successfully");
        }

        public Result GetAllOrders()
        {
            var orders = _context.Order
                .Include(o => o.User)
                .Include(o => o.OrderDetails)
                    .ThenInclude(d => d.Product)
                .OrderByDescending(o => o.OrderDate)
                .ToList();
            return new Result(true, "Orders retrieved successfully", orders);
        }

        public Result GetOrder(int id)
        {
            var order = _context.Order
                .Include(o => o.User)
                .Include(o => o.OrderDetails)
                    .ThenInclude(d => d.Product)
                .FirstOrDefault(o => o.OrderId == id);
            if (order == null)
                return new Result(false, "Order not found");
            return new Result(true, "Order retrieved successfully", order);
        }

        public Result UpdateStatus(int orderId, string status)
        {
            var order = _context.Order.Find(orderId);
            if (order == null)
                return new Result(false, "Order not found");
            order.OrderStatus = status;
            _context.Order.Update(order);
            return Result.DBcommit(_context, "Order status updated");
        }

        public Result DeleteOrder(int id)
        {
            var order = _context.Order
                .Include(o => o.OrderDetails)
                .FirstOrDefault(o => o.OrderId == id);
            if (order == null)
                return new Result(false, "Order not found");
            _context.OrderDetails.RemoveRange(order.OrderDetails);
            _context.Order.Remove(order);
            return Result.DBcommit(_context, "Order deleted successfully");
        }

        public Result GetAvailableProducts()
        {
            var products = _context.Product
                .Select(p => new
                {
                    Product = p,
                    Available = _context.Stock
                        .Where(s => s.P_Id == p.PId)
                        .Sum(s => (int?)s.Quantity_In - s.Quantity_Out) ?? 0,
                    Category = p.Category
                })
                .ToList()
                .Select(x =>
                {
                    x.Product.PQuantity = x.Available;
                    return x.Product;
                })
                .ToList();
            return new Result(true, "Products retrieved", products);
        }
    }
}