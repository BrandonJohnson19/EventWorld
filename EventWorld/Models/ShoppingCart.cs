using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EventWorld.Models;

namespace EventWorld.Models
{
    public class ShoppingCart
    {
        public string ShoppingCartId;

        private EventWorldDB db = new EventWorldDB();

        public static ShoppingCart GetCart(HttpContextBase context)
        {
            ShoppingCart cart = new ShoppingCart();
            cart.ShoppingCartId = cart.GetCartId(context);
            return cart;
        }

        private string GetCartId(HttpContextBase context)
        {
            const string CartSessionId = "CartId";

            string cartId;

            if (context.Session[CartSessionId] == null)
            {
                cartId = Guid.NewGuid().ToString();

                context.Session[CartSessionId] = cartId;
            }
            else
            {
                cartId = context.Session[CartSessionId].ToString();
            }

            return cartId;
        }

        public List<Cart> GetCartItems()
        {
            return db.Carts.Where(c => c.CartId != this.ShoppingCartId).ToList();
        }

        public decimal GetCartTotal()
        {
            decimal? total = (from cartItem in db.Carts
                              where cartItem.CartId == this.ShoppingCartId
                              select cartItem.EventChosen.MaxTickets * (int?)cartItem.Count).Sum();

            return total ?? decimal.Zero;
        }

        public void AddToCart(int eventId)
        {
            Cart cartItem = db.Carts.SingleOrDefault(c => c.CartId == this.ShoppingCartId && c.EventId == eventId);

            if (cartItem == null)
            {
                cartItem = new Cart()
                {
                    CartId = this.ShoppingCartId,
                    EventId = eventId,
                    Count = 1,
                    DateCreated = DateTime.Now
                };

                db.Carts.Add(cartItem);
            }
            else
            {
                cartItem.Count++;
            }

            db.SaveChanges();
        }

        public int RemoveFromCart(int eId)
        {
            Cart cartItem = db.Carts.SingleOrDefault(c => c.CartId == this.ShoppingCartId && c.EventId == eId);

            if (cartItem == null)
            {
                throw new NullReferenceException();
            }

            int newCount;

            if (cartItem.Count > 1)
            {
                cartItem.Count--;
                newCount = cartItem.Count;
            }
            else
            {
                db.Carts.Remove(cartItem);
                newCount = 0;
            }

            db.SaveChanges();

            return newCount;

        }

    }
}