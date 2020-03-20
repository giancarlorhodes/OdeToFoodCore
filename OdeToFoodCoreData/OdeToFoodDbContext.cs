using Microsoft.EntityFrameworkCore;
using OdeToFoodCoreCommon;
using System;
using System.Collections.Generic;
using System.Text;

namespace OdeToFoodCoreData
{
    public class OdeToFoodDbContext : DbContext
    {

        public OdeToFoodDbContext(DbContextOptions<OdeToFoodDbContext> options) : base(options)
        {
            // pass it back to the base 
        }

        public DbSet<Restaurant> Restaurants { get; set; }

    }
}
