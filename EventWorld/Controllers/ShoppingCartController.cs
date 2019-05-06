using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EventWorld.Models;

namespace EventWorld.Controllers
{
    public class ShoppingCartController : Controller
    {
        EventWorldDB db = new EventWorldDB();

        public ActionResult Index()
        {
            ShoppingCart cart = ShoppingCart.GetCart(this.HttpContext);

            ShoppingCartViewModel vm = new ShoppingCartViewModel()
            {
                CartItems = cart.GetCartItems(),          
            };

            return View(vm);
        }

        public ActionResult AddToCart(int id)
        {
            ShoppingCart cart = ShoppingCart.GetCart(this.HttpContext);
            cart.AddToCart(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult RemoveFromCart(int id)
        {
            ShoppingCart cart = ShoppingCart.GetCart(this.HttpContext);

            Event album = db.Events.SingleOrDefault(c => c.EventId == id);

            int newItemCount = cart.RemoveFromCart(id);

            ShoppingCartRemoveViewModel vm = new ShoppingCartRemoveViewModel()
            {
                DeleteId = id,
                CartTotal = cart.GetCartTotal(),
                ItemCount = newItemCount,
                Message = album.Title + " has been removed from the cart"
            };

            return Json(vm);
        }
    }

}
