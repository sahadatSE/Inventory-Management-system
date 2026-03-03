using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Database.Context;
using Database.Model;
using Microsoft.AspNetCore.Identity;

namespace Business.Services
{
    public class UserService(IMSContext context)
    {
        private readonly IMSContext _context = context;

        public Result AddUser(User user)
        {
            // Check duplicate username
            bool exists = _context.User.Any(u => u.UserName == user.UserName);
            if (exists)
                return new Result(false, "Username already exists");

            // Check duplicate user number
            bool numberExists = _context.User.Any(u => u.UserNumber == user.UserNumber);
            if (numberExists)
                return new Result(false, "User number already exists");

            // Hash password before saving
            user.UserPassword = new PasswordHasher<object>().HashPassword(user, user.UserPassword!);

            _context.User.Add(user);
            return Result.DBcommit(_context, "User added successfully");
        }

        public Result UpdateUser(User user)
        {
            var existing = _context.User.Find(user.UserId);
            if (existing == null)
                return new Result(false, "User not found");

            existing.UserName = user.UserName;
            existing.UserNumber = user.UserNumber;
            existing.RoleId = user.RoleId;

            // Only update password if a new one is provided
            if (!string.IsNullOrWhiteSpace(user.UserPassword))
                existing.UserPassword = new PasswordHasher<object>().HashPassword(user, user.UserPassword);

            _context.User.Update(existing);
            return Result.DBcommit(_context, "User updated successfully");
        }

        public Result DeleteUser(User user)
        {
            _context.User.Remove(user);
            return Result.DBcommit(_context, "User deleted successfully");
        }

        public Result GetAllUser()
        {
            var users = _context.User.ToList();
            return new Result(true, "Users retrieved successfully", users);
        }

        public Result GetUser(int id)
        {
            var user = _context.User.Find(id);
            if (user == null)
                return new Result(false, "User not found");

            return new Result(true, "User retrieved successfully", user);
        }

        public Result GetByUsername(string username)
        {
            var user = _context.User.FirstOrDefault(u => u.UserName == username);
            if (user == null)
                return new Result(false, "User not found");

            return new Result(true, "User retrieved successfully", user);
        }
    }
}