using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OdeToFoodCoreCommon;

namespace OdeToFoodCore
{
    public class DetailModel : PageModel
    {

        public Restaurant Restaurant { get; set; }

        public void OnGet(int inRestaurantId)
        {
            Restaurant = new Restaurant();
            Restaurant.Id = inRestaurantId;
        }
    }
}