using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EventWorld.Models;

namespace EventWorld.Controllers
{
    public class StoreController : Controller
    {
        private EventWorldDB db = new EventWorldDB();

        public ActionResult Browse()
        {
            return View(db.EventTypes.ToList());
        }

        public ActionResult Index(int id)
        {
            var events = GetEvents(id);
            return View("Index", events);
        }

        private List<Event> GetEvents(int searchInt)
        {
            return db.Events
            .Where(a => a.EventId.Equals(searchInt))
            .ToList();
        }

        public ActionResult Details(int id)
        {
            Event eventt = db.Events.Find(id);
            return View("Details", eventt);
        }
    }
}