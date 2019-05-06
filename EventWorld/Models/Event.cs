using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace EventWorld.Models
{
    public class Event
    {
        public virtual int EventId { get; set; }

        public virtual EventType Type { get; set; }

        [Required(ErrorMessage = "This is a required field.")]
        [StringLength(50)]
        public virtual string Title { get; set; }

        [StringLength(150)]
        public virtual string Description { get; set; }

        [Required(ErrorMessage = "This is a required field.")]
        [Display(Name = "Start Date")]
        public virtual DateTime StartDate { get; set; }

        [Required(ErrorMessage = "This is a required field.")]
        [Display(Name = "End Date")]
        public virtual DateTime EndDate { get; set; }

        [Required(ErrorMessage = "This is a required field.")]
        [Display(Name = "Max Tickets")]
        [Range(1, int.MaxValue)]
        public virtual int MaxTickets { get; set; }

        [Required(ErrorMessage = "This is a required field.")]
        [Display(Name = "Available Tickets")]
        [Range(1, int.MaxValue)]
        public virtual int AvailableTickets { get; set; }

        [Required(ErrorMessage = "This is a required field.")]
        public virtual string Organizer { get; set; }

        [Display(Name = "Organizer Contact Info")]
        public virtual string OrganizerContactInfo { get; set; }

        public virtual string Location { get; set; }
    }
}