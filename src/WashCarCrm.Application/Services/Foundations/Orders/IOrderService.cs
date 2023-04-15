using System;
using System.Linq;
using System.Threading.Tasks;
using WashCarCrm.Domain;

namespace WashCarCrm.Application.Foundations.Orders
{
    public interface IOrderService
    {
        ValueTask<Order> AddOrderAsync(Order Order);
        IQueryable<Order> RetrieveAllOrders();
        ValueTask<Order> RetrieveOrderByIdAsync(int id);
        ValueTask<Order> ModifyOrderAsync(Order Order);
        ValueTask<Order> RemoveOrderByIdAsync(int id);
    }
}