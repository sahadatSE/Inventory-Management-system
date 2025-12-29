using System.Data;
using Business;
using Business.Services;
using Database.Model;
using Microsoft.AspNetCore.Identity;

namespace BusinessTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AddCustomer();
        }
        static void AddCustomer()
        {
            Customer customer = new Customer()
            {
                C_Id = "C123",
                C_Name = "Sahadat",
                C_Number = 42,
                C_Adress = "Uttara"
            };
            Result result = new CustomerService().AddCustomer(customer);
            Console.WriteLine(result.Message);
        }
    }
}