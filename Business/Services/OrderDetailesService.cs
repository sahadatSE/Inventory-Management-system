using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database.Context;

namespace Business.Services
{
    public class OrderDetailesService
    {
        public IMSContext = new();
            public Result AddOrderDetailes(OrderDetails orderDetails)
        {
            context.OrderDetails.Add(orderDetails);
            return Result.DBcommit(context, "OrderDetails added successfully");
        }
        public Result DeleteOrderDetailes(OrderDetails orderDetails)
        {
            context.OrderDetails.Remove(orderDetails);
            return Result.DBcommit(context, "OrderDetails deleted successfully");
        }
    }
}
