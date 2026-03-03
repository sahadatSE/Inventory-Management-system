using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database.Context;
using Database.Model;

namespace Business.Services
{
    public class DiscountService(IMSContext context)
    {
        private readonly IMSContext _context = context;  
        public Result AddDiscount(Discount discount)
        {
            _context.Discount.Add(discount);
            return Result.DBcommit(_context, "Discount added successfully");
        }
        public Result DeleteDiscount(Discount discount)
        {
            _context.Discount.Remove(discount);
            return Result.DBcommit(_context, "Discount deleted successfully");
        }
        public Result UpdateDiscount(Discount discount)
        {
            _context.Discount.Update(discount);
            return Result.DBcommit(_context, "Discount updated successfully");
        }
        public Result GetAllDiscounts()
        {
            var discounts = _context.Discount.ToList();
            return new Result(true, "Discounts retrieved successfully", discounts);
        }
        public Result GetDiscount(int id)
        {
            var discount = _context.Discount.Find(id);
            if (discount == null)
            {
                return new Result(false, "Discount not found");
            }
            return new Result(true, "Discount retrieved successfully", discount);
        }

    }
}
