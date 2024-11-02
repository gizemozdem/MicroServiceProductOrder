using MicroServiceOrder.Models;
using System.Collections.Generic;

namespace MicroServiceOrder.Repository
{
    public interface IOrderRepository
    {
        IEnumerable<Order> GetOrders();
        Order GetOrderById(int orderId);
        void InsertOrder(Order order);
        void UpdateOrder(Order order);
        void DeleteOrder(int orderId);
        void Save();
    }
}
