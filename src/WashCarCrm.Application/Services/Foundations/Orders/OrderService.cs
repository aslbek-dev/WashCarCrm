using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WashCarCrm.Domain;
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
        public async ValueTask<Order> AddOrderAsync(Order Order)
        {
            
           return await this.OrderRepository.InsertOrderAsync(Order);
        }
        public IQueryable<Order> RetrieveAllOrders()
        {
            return this.OrderRepository.SelectAll();
        }

        public async ValueTask<Order> RetrieveOrderByIdAsync(int id)
        {
            return await this.OrderRepository.SelectOrderByIdAsync(id);
        }

        public async ValueTask<Order> ModifyOrderAsync(Order Order)
        {
            return await this.OrderRepository.UpdateOrderAsync(Order);
        }

        public async ValueTask<Order> RemoveOrderByIdAsync(int id)
        {
            Order maybeOrder = await this.OrderRepository.SelectOrderByIdAsync(id);
            return await this.OrderRepository.DeleteOrderAsync(maybeOrder);
        }
    }
}