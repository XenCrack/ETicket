using ETicket.Data.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ETicket.Controllers
{
    [Authorize]
    public class OrdersController : Controller
    {
        private readonly IMovieService _movieService;
        private readonly IOrderService _orderService;
        public OrdersController(IMovieService movieService, IOrderService orderService)
        {
            _movieService = movieService;
            _orderService = orderService;
        }

        public async Task<IActionResult> Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var userRole = User.FindFirstValue(ClaimTypes.Role);

            var orders = await _orderService.GetOrderByUserIdAndRoleAsync(userId, userRole);   
            
            return View(orders);
        }
    }
}
