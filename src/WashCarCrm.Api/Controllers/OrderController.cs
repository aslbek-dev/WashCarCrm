using WashCarCrm.Application.Foundations.Orders;
using Microsoft.AspNetCore.Mvc;
using RESTFulSense.Controllers;
using WashCarCrm.Domain;

namespace WashCarCrm.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : RESTFulController
    {
        private readonly IOrderService orderService;
        public OrderController(IOrderService orderService)
        {
            this.orderService = orderService;
        }
        [HttpPost]
        public async ValueTask<ActionResult<Order>> PostOrderAsync(Order order)
        {
            try
            {
                return await this.orderService.AddOrderAsync(order);
            }
            catch(Exception)
            {
                throw;
            }
        }

        [HttpGet]
        public ActionResult<IQueryable<Order>> GetAllOrders()
        {
            try
            {
                IQueryable<Order> allOrders = this.orderService.RetrieveAllOrders();

                return Ok(allOrders);
            }
            catch(Exception)
            {
                throw;
            }
        }

        [HttpGet("{orderId}")]
        public async ValueTask<ActionResult<Order>> GetOrderByIdAsync(int orderId)
        {
            try
            {
                return await this.orderService.RetrieveOrderByIdAsync(orderId);
            }
            catch(Exception)
            {
                throw;
            }
        }
        
        [HttpPut]
        public async ValueTask<ActionResult<Order>> PutOrderAsync(Order order)
        {
            try
            {
                Order modifiedOrder = await this.orderService.ModifyOrderAsync(order);

                return Ok(modifiedOrder);
            }
            catch(Exception)
            {
                throw;
            }
        }
        [HttpDelete("{orderId}")]
        public async ValueTask<ActionResult<Order>> DeleteOrderByIdAsync(int orderId)
        {
            try
            {
                Order deletedOrder = await this.orderService.RemoveOrderByIdAsync(orderId);

                return Ok(deletedOrder);
            }
            catch (Exception)
            {
                
                throw;
            }
        }

    }
}