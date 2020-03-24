using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using OdeToFoodCoreCommon;
using OdeToFoodCoreData;

namespace OdeToFoodCore.Pages.ScaffoldingRestaurants
{
    public class IndexModel : PageModel
    {
        private readonly OdeToFoodCoreData.OdeToFoodDbContext _context;

        public IndexModel(OdeToFoodCoreData.OdeToFoodDbContext context)
        {
            _context = context;
        }

        public IList<Restaurant> Restaurant { get;set; }

        public async Task OnGetAsync()
        {
            Restaurant = await _context.Restaurants.ToListAsync();
        }
    }
}
