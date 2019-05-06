using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EventWorld.Models
{
    public class ShoppingCartRemoveViewModel
    {
        public int DeleteId;
        public decimal CartTotal;
        public int ItemCount;
        public string Message;
    }
}