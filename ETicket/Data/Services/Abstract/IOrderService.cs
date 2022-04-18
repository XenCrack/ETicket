using ETicket.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ETicket.Data.Services
{
    public interface IOrderService
    {
        Task StoreOrderAsync(List<ShoppingCart> items, string userId, string email);

        Task<List<Order>> GetOrderByUserIdAndRoleAsync(string userId, string roleId);
    }
}
