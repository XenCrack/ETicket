using ETicket.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ETicket.Data.Cart
{
    public class ShoppingCart
    {
        public ApplicationDbContext _context { get; set; }
        public string ShoppingCartId { get; set; }

        public ShoppingCart(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AddItemToCart(Movie movie)
        {
            var shoppingCartItem = _context.ShoppingCarts.FirstOrDefault(
                x=> x.Movie.Id == movie.Id && x.ShoppingCartId == ShoppingCartId);

            if (shoppingCartItem == null)
            {
                shoppingCartItem = new ShoppingCartItem()
                {
                    ShoppingCartId = ShoppingCartId,
                    Movie = movie,
                    Quantity = 1
                };

                _context.ShoppingCarts.Add(shoppingCartItem);
            }
            else
            {
                shoppingCartItem.Quantity++;
            }

            _context.SaveChanges();

            
        }

        public void RemoveItemToCart(Movie movie)
        {
            var shoppingCartItem = _context.ShoppingCarts.FirstOrDefault(
                x=>x.Movie.Id == movie.Id && x.ShoppingCartId == ShoppingCartId);

            if (shoppingCartItem != null)
            {
                if (shoppingCartItem.Quantity > 1)
                {
                    shoppingCartItem.Quantity--;
                }
                else
                {
                    _context.ShoppingCarts.Remove(shoppingCartItem);
                }

                _context.SaveChanges();
            }
        }

        public List<ShoppingCartItem> GetShopingCartItems()
        {
            return _context.ShoppingCarts
                .Where(x => x.ShoppingCartId == ShoppingCartId)
                .Include(m => m.Movie).ToList();
        }

        public double GetShoppingCartTotal()
        {
            return _context.ShoppingCarts.Where(x => x.ShoppingCartId == ShoppingCartId)
                .Select(x=> x.Movie.Price * x.Quantity).Sum();
        }

        public async Task ClearShoppingCartAsync()
        {
            var items = await _context.ShoppingCarts.Where(x => x.ShoppingCartId == ShoppingCartId).ToArrayAsync();
            
            _context.ShoppingCarts.RemoveRange(items);

            await _context.SaveChangesAsync();
        }
    }
}
