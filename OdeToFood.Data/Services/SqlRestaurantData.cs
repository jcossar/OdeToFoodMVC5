using OdeToFood.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdeToFood.Data.Services
{
    public class SqlRestaurantData : IRestaurantData
    {
        private readonly OdeToFoodDbContext db;

        public SqlRestaurantData(OdeToFoodDbContext db)
        {
            this.db = db;
        }
        public void Add(Restaurant restaurant)
        {
            //Entity Framework automatically makes our Id property a primary key
            //all these behaviours of the EF may be customized

            db.Restaurants.Add(restaurant);
            db.SaveChanges();
        }

        public Restaurant Get(int id)
        {
            return db.Restaurants.FirstOrDefault(r => r.Id == id);
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return db.Restaurants;

            //"Fancier, Linq Syntax
        //    return from r in db.Restaurants
          //         orderby r.Name
         //          select r;
        }

        public void Update(Restaurant restaurant)
        {

            //This does not track changes for multiple users:
            // var r = Get(restaurant.Id);
            // r.Name = "";
            //  db.SaveChanges();

            //Using Optimistic Concurrancy (not covered) does track changes:

            var entry = db.Entry(restaurant);
            entry.State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
