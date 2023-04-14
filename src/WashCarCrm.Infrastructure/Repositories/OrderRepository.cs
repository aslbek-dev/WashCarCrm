using WashCarCrm.Domain;
using WashCarCrm.Infrastructure.Context;

namespace WashCarCrm.Infrastructure.Repositories
{
    public class OrderRepository : GenericRepository<Order, int>, IOrderRepository
    {
        public OrderRepository(AppDbContext appDbContext)
            : base(appDbContext)
        {  }

        public ValueTask<Order> InsertOrderAsync(Order Order)=>
            base.InsertAsync(Order);
        public IQueryable<Order> SelectAllOrders() =>
            base.SelectAll();
        public ValueTask<Order> SelectOrderByIdAsync(int id) =>
             base.SelectByIdAsync(id);
        public ValueTask<Order> UpdateOrderAsync(Order Order) =>
            base.UpdateAsync(Order);

        public ValueTask<Order> DeleteOrderAsync(Order Order) =>
            base.DeleteAsync(Order);
    }
}