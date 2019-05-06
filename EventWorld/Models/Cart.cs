using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace EventWorld.Models
{
    public class Cart
    {
        [Key]
        public int EventId { get; set; }
        public string CartId { get; set; }
        public virtual Event EventChosen { get; set; }
        public int Count { get; set; }
        public DateTime DateCreated { get; set; }
    }
}