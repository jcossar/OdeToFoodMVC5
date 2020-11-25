using OdeToFood.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OdeToFood.Web.Controllers
{
    public class Restaurants3Controller : Controller
    {
        private readonly IRestaurantData db;

        public Restaurants3Controller(IRestaurantData db)
        {
            this.db = db;
        }

        // GET: Restautants3

        //Test
        public ActionResult Index()
        {
            var model = db.GetAll();
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var model = db.Get(id);

            if(model == null)
            {
                return View("NotFound");
            }
            return View(model);
        }
    }
}