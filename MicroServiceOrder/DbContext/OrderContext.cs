using MicroServiceOrder.Models; // Order modelini kullandığınız için bu using ifadesini ekledik
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroServiceOrder.DbContexts
{
    public class OrderContext : DbContext 
    {
        public OrderContext(DbContextOptions<OrderContext> options) : base(options) { }

        public DbSet<Order> Orders { get; set; }

        public static void Seed(OrderContext context)
        {
            if (!context.Orders.Any())
            {
                context.Orders.AddRange(
                    new Order { Id = 1, ProductId = 1, Quantity = 2, TotalPrice = 200, OrderDate = DateTime.Now },
                    new Order { Id = 2, ProductId = 2, Quantity = 1, TotalPrice = 100, OrderDate = DateTime.Now }
                );
                context.SaveChanges();
            }
        }
    }
}
