using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EventWorld.Models
{
    public class EventType
    {
        public virtual int EventTypeId { get; set; }

        [StringLength(50)]
        public virtual string Type { get; set; }
    }
}