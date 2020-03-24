using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OdeToFoodCoreCommon;
using OdeToFoodCoreData;

namespace OdeToFoodCore.Pages.Restaurants
{
    public class DeleteModel : PageModel
    {

        private readonly IRestaurantData _restaurantData;

        public Restaurant Restaurant { get; set; }

        public DeleteModel(IRestaurantData inRestaurantData)
        {
            this._restaurantData = inRestaurantData; 
        }

        public IActionResult OnGet(int restaurantId)
        {
            Restaurant = _restaurantData.GetById(restaurantId);
            if (Restaurant == null) 
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }


        public IActionResult OnPost(int restaurantId)
        {
            var _restaurant = _restaurantData.Delete(restaurantId);
            _restaurantData.Commit();

            if (_restaurant == null) 
            {
                return RedirectToPage("./NotFound");
            }

            TempData["Message"] = $"{_restaurant.Name} deleted";
            return RedirectToPage("./List");
        }
    }
}