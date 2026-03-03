using System.Linq;
using Database.Context;
using Database.Model;

namespace Business.Services
{
    public class RoleService (IMSContext context)
    {
        private readonly IMSContext _context = context;

     
        public Result AddRole(Role role)
        {
            _context.Role.Add(role);
            return Result.DBcommit(_context, "Role added successfully");
        }
        public Result UpdateRole(Role role)
        {
            _context.Role.Update(role);
            return Result.DBcommit(_context, "Role updated successfully");
        }
        public Result DeleteRole(Role role)
        {
            _context.Role.Remove(role);
            return Result.DBcommit(_context, "Role deleted successfully");
        }
        public Result GetAllRole()
        {
            var roles = _context.Role.ToList();
            return new Result(true, "Roles retrieved successfully", roles);
        }
        public Result GetRole(int id)
        {
            var role = _context.Role.Find(id);//where r.RoleId == id).FirstOrDefault();

            if (role == null)
                return new Result(false, "Role not found");

            return new Result(true, "Role retrieved successfully", role);
        }
    }
}

