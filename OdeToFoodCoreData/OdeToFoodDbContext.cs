using Microsoft.EntityFrameworkCore;
using OdeToFoodCoreCommon;
using System;
using System.Collections.Generic;
using System.Text;

namespace OdeToFoodCoreData
{
    public class OdeToFoodDbContext : DbContext
    {
        public DbSet<Restaurant> Restaurants { get; set; }

    }
}
