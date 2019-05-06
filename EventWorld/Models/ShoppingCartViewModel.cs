using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EventWorld.Models
{
    public class ShoppingCartViewModel
    {
        public List<Cart> CartItems;
        public int Count;
        public int CartTotal;
    }
}