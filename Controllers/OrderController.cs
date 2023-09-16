using LightHeight.BackgroundService;
using LightHeight.Model;
using LightHeight.Model.DTO;
using LightHeight.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LightHeight.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;
        protected ResponseDTO _responseDTO;
        private readonly IRabbitMQProducer _rabbitMQProducer;

        public OrderController(IOrderRepository orderRepository, IRabbitMQProducer rabbitMQProducer)
        {
            _orderRepository = orderRepository;
            this._responseDTO = new ResponseDTO();
            _rabbitMQProducer = rabbitMQProducer;
        }

        [HttpGet]
        [Route("order-staus/{id}")]

        public async Task<object> GetOderStatus(int orderId)
        {
            try
            {
                OrderDTO status = await _orderRepository.OrderStatus(orderId);
                _responseDTO.Result = status;
            }
            catch (Exception ex)
            {
                _responseDTO.IsSuccess = false;
                _responseDTO.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _responseDTO;
        }

        [HttpPost]
        public async Task<IActionResult> PlaceOrder([FromBody] OrderDTO orderDto)
        {
            try
            {
                if (orderDto == null)
                {
                    return NotFound("Invalid order request.");
                }
                var order = await _orderRepository.PlaceOrder(orderDto.BookId, orderDto.Quantity);
                if (order == null)
                {
                    return NotFound("Book not found.");
                }
                _rabbitMQProducer.SendOrderMessage(order);
                _responseDTO.Result = order;
                return Ok(_responseDTO);
            }
            catch (Exception ex)
            {
                _responseDTO.IsSuccess = false;
                _responseDTO.ErrorMessages = new List<string>() { ex.ToString() };
                return StatusCode(StatusCodes.Status500InternalServerError, _responseDTO);
            }
        }
    }
}
