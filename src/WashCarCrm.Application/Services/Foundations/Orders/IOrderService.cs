using System;
using System.Linq;
using System.Threading.Tasks;
using WashCarCrm.Domain;

namespace WashCarCrm.Application.Foundations.Orders
{
    public interface IOrderService
    {
        ValueTask<Order> AddOrderAsync(int washCompanyId,Order order);
        IQueryable<Order> RetrieveAllOrders();
        IQueryable<Order> GetisActiveOrder(
            int washCompanyId,
            int page, 
            bool isActive, 
            DateTimeOffset dateFrom, 
            DateTimeOffset dateTo);
        ValueTask<Order> RetrieveOrderByIdAsync(int id);
        ValueTask<Order> ModifyOrderAsync(int washCompanyId, Order Order);
        ValueTask<Order> RemoveOrderByIdAsync(int id);
    }
}