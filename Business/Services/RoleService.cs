using System.Linq;
using Database.Context;
using Database.Model;

namespace Business.Services
{
    public class RoleService
    {
        public IMSContext context = new();

     
        public Result AddRole(Role role)
        {
            context.Role.Add(role);
            return Result.DBcommit(context, "Role added successfully");
        }
        public Result UpdateRole(Role role)
        {
            context.Role.Update(role);
            return Result.DBcommit(context, "Role updated successfully");
        }
        public Result DeleteRole(Role role)
        {
            context.Role.Remove(role);
            return Result.DBcommit(context, "Role deleted successfully");
        }
        public Result GetAllRole()
        {
            var roles = context.Role.ToList();
            return new Result(true, "Roles retrieved successfully", roles);
        }
        public Result GetRole(int id)
        {
            var role = context.Role.Find(id);

            if (role == null)
                return new Result(false, "Role not found");

            return new Result(true, "Role retrieved successfully", role);
        }
    }
}

