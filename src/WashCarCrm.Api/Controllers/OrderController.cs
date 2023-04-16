using WashCarCrm.Application.Foundations.Orders;
using Microsoft.AspNetCore.Mvc;
using RESTFulSense.Controllers;
using WashCarCrm.Domain;

namespace WashCarCrm.Api.Controllers
{
    [ApiController]
    [Route("api/")]
    public class OrderController : RESTFulController
    {
        private readonly IOrderService orderService;
        public OrderController(IOrderService orderService)
        {
            this.orderService = orderService;
        }
        [HttpPost("{washCompanyId}/insertOrder")]
        public async ValueTask<ActionResult<Order>> PostOrderAsync(int washCompanyId, Order order)
        {
            try
            {

                return await this.orderService.AddOrderAsync(washCompanyId,order);
            }
            catch(Exception)
            {
                throw;
            }
        }
        [HttpGet("{washCompanyId}/ordersByIsActive")]
        public ActionResult<IQueryable<Order>> GetisActiveOrder(
            [FromQuery] bool isActive,
            [FromQuery] DateTimeOffset dateFrom,
            [FromQuery] DateTimeOffset dateTo,
            [FromQuery] int page, int washCompanyId)
        {
            return Ok(this.orderService.GetisActiveOrder(washCompanyId, page, isActive, dateFrom, dateTo));
        }

        [HttpGet("allOrder")]
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
        
        [HttpPut("{washCompanyId}/updateOrder")]
        public async ValueTask<ActionResult<Order>> PutOrderAsync(int washCompanyId, Order order)
        {
            try
            {
                Order modifiedOrder = await this.orderService.ModifyOrderAsync(washCompanyId, order);

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