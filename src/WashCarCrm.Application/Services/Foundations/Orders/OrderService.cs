using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WashCarCrm.Domain;
using System.Linq;
using WashCarCrm.Infrastructure.Repositories;

namespace WashCarCrm.Application.Foundations.Orders
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository OrderRepository;
        public OrderService(IOrderRepository OrderRepository)
        {
            this.OrderRepository = OrderRepository;
        }
        public async ValueTask<Order> AddOrderAsync(int washCompanyId, Order order)
        {
           order.WashCompanyId = washCompanyId; 
           return await this.OrderRepository.InsertOrderAsync(order);
        }
        public IQueryable<Order> RetrieveAllOrders()
        {
            return this.OrderRepository.SelectAll();
        }

        public async ValueTask<Order> RetrieveOrderByIdAsync(int id)
        {
            return await this.OrderRepository.SelectOrderByIdAsync(id);
        }

        public async ValueTask<Order> ModifyOrderAsync(int washCompanyId, Order order)
        {
            order.WashCompanyId = washCompanyId;
            return await this.OrderRepository.UpdateOrderAsync(order);
        }

        public async ValueTask<Order> RemoveOrderByIdAsync(int id)
        {
            Order maybeOrder = await this.OrderRepository.SelectOrderByIdAsync(id);
            return await this.OrderRepository.DeleteOrderAsync(maybeOrder);
        }

        public IQueryable<Order> GetisActiveOrder(int washCompanyId,int page, bool isActive,
                             DateTimeOffset dateFrom, DateTimeOffset dateTo)
        {
            List<Order> resultOrder = new List<Order>();
            int mockPage = 0;
            foreach(Order order in RetrieveAllOrders())
            {
                if
                (
                    order.IsActive == isActive && 
                    0 <= DateTimeOffset.Compare(dateFrom, order.DateTime) &&
                    0 >= DateTimeOffset.Compare(dateTo, order.DateTime) &&
                    order.WashCompanyId == washCompanyId
                )
                   {
                    resultOrder.Add(order);
                    mockPage++;
                   }
                if(mockPage == page)
                break;
            }
            return resultOrder.AsQueryable();
        }
    }
}