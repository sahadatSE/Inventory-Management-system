using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database.Context;
using Database.Model;

namespace Business.Services
{
    public class OrderDetailesService
    {
        public IMSContext context = new();
        public Result AddOrderDetails(OrderDetails orderDetails)
        {
            context.OrderDetails.Add(orderDetails);
            return Result.DBcommit(context, "OrderDetails added successfully");
        }
        public Result DeleteOrderDetails(OrderDetails orderDetails)
        {
            context.OrderDetails.Remove(orderDetails);
            return Result.DBcommit(context, "OrderDetails deleted successfully");
        }
        public Result UpdateOrderDetails(OrderDetails orderDetails)
        {
            context.OrderDetails.Update(orderDetails);
            return Result.DBcommit(context, "OrderDetails updated successfully");
        }
        public Result GetAllOrderDetails()
        {
            var orderDetails = context.OrderDetails.ToList();
            return new Result(true, "OrderDetails retrieved successfully", orderDetails);
        }



    }
}
