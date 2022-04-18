using ETicket.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ETicket.Data.Services.Concrete
{
    public class OrderService : IOrderService
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public OrderService(ApplicationDbContext context)
        {
            _applicationDbContext = context;
        }

        public async Task<List<Order>> GetOrderByUserIdAndRoleAsync(string userId, string roleId)
        {
            var orders = await _applicationDbContext.Orders.Include(x => x.OrderItems)
                .ThenInclude(m => m.Movie).Include(u => u.User).ToListAsync();

            if (roleId != "Admin")
            {
                orders = orders.Where(x => x.UserId == userId).ToList();
            }

            return orders;
        }

        public async Task StoreOrderAsync(List<ShoppingCart> items, string userId, string email)
        {
            var order = new Order()
            {
                Email = email,
                UserId = userId
            };

            await _applicationDbContext.Orders.AddAsync(order);
            await _applicationDbContext.SaveChangesAsync();

            foreach (var item in items)
            {
                var orderItem = new OrderItem()
                {
                    MovieId = item.Movie.Id,
                    OrderId = order.Id,
                    Price = item.Movie.Price,
                    Quantity = item.Quantity
                };

                await _applicationDbContext.OrderItems.AddAsync(orderItem);
            }

            await _applicationDbContext.SaveChangesAsync();
        }
    }
}
