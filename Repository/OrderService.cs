using AutoMapper;
using LightHeight.Data;
using LightHeight.Model;
using LightHeight.Model.DTO;
using Microsoft.EntityFrameworkCore;

namespace LightHeight.Repository
{
    public class OrderService : IOrderRepository
    {
        private readonly AppDbContext _ctx;
        private IMapper _mapper;

        public OrderService(AppDbContext dbContext, IMapper mapper)
        {
            _ctx = dbContext;
            _mapper = mapper;
        }

        public async Task<OrderDTO> OrderStatus(int orderId)
        {
            var order = await _ctx.Orders.Include(x => x.Book).FirstOrDefaultAsync(x => x.OrderId == orderId);
            if (order == null)
            {
                return null;
            }

            return _mapper.Map<OrderDTO>(order);   
        }

        public async Task<OrderDTO> PlaceOrder(int bookId, int quantity)
        {
            var book = await _ctx.BookStores.FindAsync(bookId);
            if(book == null)
            {
                return null;
            }
            Order order = new Order
            {
                BookId = bookId,
                Quantity = quantity,
                TotalPrice = book.Price * quantity,
                Status = "Pending",
            };
            _ctx.Orders.Add(order);
            await _ctx.SaveChangesAsync();

            return _mapper.Map<OrderDTO>(order);
        }
    }
}
