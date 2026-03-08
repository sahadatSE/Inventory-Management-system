using System.Linq;
using Database.Context;
using Database.Model;

namespace Business.Services
{
    public class SupplierService(IMSContext context)
    {
        private readonly IMSContext _context = context;

        public Result AddSupplier(Supplier supplier)
        {
            _context.Suppliers.Add(supplier);
            return Result.DBcommit(_context, "Supplier added successfully");
        }

        public Result UpdateSupplier(Supplier supplier)
        {
            _context.Suppliers.Update(supplier);
            return Result.DBcommit(_context, "Supplier updated successfully");
        }

        public Result DeleteSupplier(Supplier supplier)
        {
            _context.Suppliers.Remove(supplier);
            return Result.DBcommit(_context, "Supplier deleted successfully");
        }

        public Result DeleteSupplier(int id)
        {
            var supplier = _context.Suppliers.Find(id);
            if (supplier == null)
                return new Result(false, "Supplier not found");

            _context.Suppliers.Remove(supplier);
            return Result.DBcommit(_context, "Supplier deleted successfully");
        }

        public Result GetAllSupplier()
        {
            var suppliers = _context.Suppliers.ToList();
            return new Result(true, "Suppliers retrieved successfully", suppliers);
        }

        public Result GetSupplier(int id)
        {
            var supplier = _context.Suppliers.Find(id);
            if (supplier == null)
                return new Result(false, "Supplier not found");

            return new Result(true, "Supplier retrieved successfully", supplier);
        }
    }
}