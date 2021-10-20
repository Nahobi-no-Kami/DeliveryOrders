using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DeliveryOrders
{
    public class OrderTable
    {
        public int Id { get; set; }
        public string SenderCity { get; set; } 
        public string SenderAdress { get; set; }
        public string RecieverCity { get; set; } 
        public string RecieverAdress { get; set; }
        public double Weight { get; set; }
        public DateTime Date{ get; set; }
    }

    public class ApplicationContext : DbContext
    {
        public DbSet<OrderTable> Orders{ get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            Database.EnsureCreated(); 
        }
    }
}
