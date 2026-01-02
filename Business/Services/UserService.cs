using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database.Context;
using Database.Model;

namespace Business.Services
{
    public class UserService
    {
        public IMSContext context = new();
        public Result AddUser(User user)
        {
            context.User.Add(user);
            return Result.DBcommit(context, "User added successfully");
        }
        public Result DeleteUser(User user)
        {
            context.User.Remove(user);
            return Result.DBcommit(context, "User deleted successfully");
        }
        public Result UpdateUser(User user)
        {
            context.User.Update(user);
            return Result.DBcommit(context, "User updated successfully");
        }
        public Result GetAllUser()
        {
            var users = context.User.ToList();
            return new Result(true, "Users retrieved successfully", users);
        }
        public Result GetUser(int id)
        {
            var user = context.User.Find(id);
            if (user == null)
            {
                return new Result(false, "User not found");
            }
            return new Result(true, "User retrieved successfully", user);
        }


    }
}
