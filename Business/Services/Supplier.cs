using System.Linq;
using Database.Context;
using Database.Model;

namespace Business.Services
{
    public class SupplierService
    {
        public IMSContext context = new();

        public Result AddSupplier(Supplier supplier)
        {
            context.Suppliers.Add(supplier);
            return Result.DBcommit(context, "Supplier added successfully");
        }

        public Result UpdateSupplier(Supplier supplier)
        {
            context.Suppliers.Update(supplier);
            return Result.DBcommit(context, "Supplier updated successfully");
        }

        public Result DeleteSupplier(Supplier supplier)
        {
            context.Suppliers.Remove(supplier);
            return Result.DBcommit(context, "Supplier deleted successfully");
        }

        public Result GetAllSupplier()
        {
            var suppliers = context.Suppliers.ToList();
            return new Result(true, "Suppliers retrieved successfully", suppliers);
        }

        public Result GetSupplier(string id)
        {
            var supplier = context.Suppliers.Find(id);

            if (supplier == null)
                return new Result(false, "Supplier not found");

            return new Result(true, "Supplier retrieved successfully", supplier);
        }
    }
}

