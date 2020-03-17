using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OdeToFoodCoreCommon;
using OdeToFoodCoreData;

namespace OdeToFoodCore
{
    public class DetailModel : PageModel
    {

        private readonly IRestaurantData _restaurantData;


        [TempData]
        public string Message { get; set; }
        public Restaurant Restaurant { get; set; }


        public DetailModel(IRestaurantData inRestaurantData)
        {
            this._restaurantData = inRestaurantData;       
        }


        public IActionResult OnGet(int restaurantId)
        {

            // OLD
            //Restaurant = new Restaurant();
            //Restaurant.Id = restaurantId;

            Restaurant = _restaurantData.GetById(restaurantId);
            if (Restaurant == null)
            {
                return RedirectToPage("./NotFound");
            }
            else
            {
                return Page();
            }
        }
    }
}