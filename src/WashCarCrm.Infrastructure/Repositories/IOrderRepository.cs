using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WashCarCrm.Domain;

namespace WashCarCrm.Infrastructure.Repositories
{
   public interface IOrderRepository : IGenericRepository<Order, int>
    {
        ValueTask<Order> InsertOrderAsync(Order Order);
        IQueryable<Order> SelectAllOrders();
        ValueTask<Order> SelectOrderByIdAsync(int id);
        ValueTask<Order> UpdateOrderAsync(Order Order);
        ValueTask<Order> DeleteOrderAsync(Order Order);
    }
}