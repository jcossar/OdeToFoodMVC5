using OdeToFood.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdeToFood.Data.Services
{
    public class OdeToFoodDbContext : DbContext
    {
        //defines table that can populate Restaurant Objects. It will have an Id property, a Name property and 
        //a Cuisine property. when the data comes back we can map the data into the class

        //By naming the property Restaurants by convention, we are telling the framework that there is a Table called Restaurants
        //by using the Restaurant as a type, we are telling the framework the data of that class

        public DbSet<Restaurant> Restaurants { get; set; }


    }
}
