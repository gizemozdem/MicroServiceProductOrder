
using MicroServiceOrder.DbContexts;
using MicroServiceOrder.Models;
using System.Collections.Generic;
using System.Linq;

namespace MicroServiceOrder.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly OrderContext _context;

        public OrderRepository(OrderContext context)
        {
            _context = context;
        }

        public IEnumerable<Order> GetOrders() => _context.Orders.ToList();

        public Order GetOrderById(int orderId) => _context.Orders.Find(orderId);

        public void InsertOrder(Order order)
        {
            _context.Orders.Add(order);
            Save();
        }

        public void UpdateOrder(Order order)
        {
            _context.Orders.Update(order);
            Save();
        }

        public void DeleteOrder(int orderId)
        {
            var order = _context.Orders.Find(orderId);
            if (order != null) _context.Orders.Remove(order);
            Save();
        }

        public void Save() => _context.SaveChanges();
    }
}
