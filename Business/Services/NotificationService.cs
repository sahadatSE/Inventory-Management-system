using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database.Context;
using Database.Model;

namespace Business.Services
{
    public class NotificationService(IMSContext context)
    {
        public IMSContext _context = context;

        // GET ALL
        public List<Notification> GetAll()
        {
            return _context.Notification.ToList();
        }

        // GET BY ID
        public Result  GetById(int id)
        {
            var notify = _context.Notification.FirstOrDefault(n => n.Notification_Id == id);
            if (notify == null)
            {
                return new Result(false, "Notification not found");
            }
            return new Result(true, "Notification retrieved", notify);
        }

        // ADD
        public async Task AddAsync(Notification notification)
        {
            _context.Notification.Add(notification);
            await _context.SaveChangesAsync();
        }

        // UPDATE
        public async Task UpdateAsync(Notification notification)
        {
            _context.Notification.Update(notification);
            await _context.SaveChangesAsync();
        }

        // DELETE
        public async Task DeleteAsync(int id)
        {
            var notification = GetById(id);
            if (notification != null)
            {
                _context.Notification.Remove(notification);
                await _context.SaveChangesAsync();
            }
        }

        // CHECK LOW STOCK
        public List<Notification> GetLowStockAlerts()
        {
            return _context.Notification
                .Where(n => n.P_Quantity <= n.LowStockThreshold)
                .ToList();
        }

        // SEND ALERT (checks IsLowStock and triggers)
        public async Task CheckAndSendAlertAsync(Notification notification)
        {
            if (notification.IsLowStock)
            {
                await SendEmailAlertAsync(notification);
                await SendSmsAlertAsync(notification);
            }
        }

        // EMAIL
        private Task SendEmailAlertAsync(Notification notification)
        {
            // plug in your SMTP here later
            Console.WriteLine($"Email sent to {notification.AlertEmail} — " +
                              $"{notification.P_Name} is low! Only {notification.P_Quantity} left.");
            return Task.CompletedTask;
        }

        // SMS
        private Task SendSmsAlertAsync(Notification notification)
        {
            // plug in Twilio here later
            Console.WriteLine($"SMS sent to {notification.AlertPhone} — " +
                              $"LOW STOCK: {notification.P_Name} has {notification.P_Quantity} unit(s) left!");
            return Task.CompletedTask;
        }
    }
} 
