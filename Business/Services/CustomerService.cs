using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database.Context;
using Database.Model;

namespace Business.Services
{
    public class CustomerService
    {
        public IMSContext context = new();
        public Result AddCustomer(Product customer)
        {
            context.Customer.Add(customer);
            return Result.DBcommit(context, "Customer added successfully");
        }
        public Result DeleteCustomer(Product customer)
        {
            context.Customer.Remove(customer);
            return Result.DBcommit(context, "Customer deleted successfully");
        }
        public Result UpdateCustomer(Product customer)
        {
            context.Customer.Update(customer);
            return Result.DBcommit(context, "Customer updated successfully");
        }
        public Result GetAllCustomers()
        {
            var customers = context.Customer.ToList();
            return new Result(true, "Customers retrieved successfully", customers);
        }
        public Result GetCustomer(int id)
        {
            var customer = context.Customer.Find(id);
            if (customer == null)
            {
                return new Result(false, "Customer not found");
            }
            return new Result(true, "Customer retrieved successfully", customer);
        }
    }
}
