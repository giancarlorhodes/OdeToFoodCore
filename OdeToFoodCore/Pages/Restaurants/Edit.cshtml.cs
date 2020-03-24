using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using OdeToFoodCoreCommon;
using OdeToFoodCoreData;

namespace OdeToFoodCore.Pages.Restaurants
{
    public class EditModel : PageModel
    {

        // fields
        private readonly IRestaurantData _restaurantData;
        private readonly IHtmlHelper _htmlHelper;

        // properties
        [BindProperty]
        public Restaurant Restaurant { get; set; }
        public IEnumerable<SelectListItem> Cuisines { get; set; }

        public EditModel(IRestaurantData inRestaurantData, IHtmlHelper inHtmlHelper)
        {
            this._restaurantData = inRestaurantData;
            this._htmlHelper = inHtmlHelper;
        }

        public IActionResult OnGet(int? restaurantId)
        {
            Cuisines = _htmlHelper.GetEnumSelectList<CuisineType>();
            if (restaurantId.HasValue)
            {

                Restaurant = _restaurantData.GetById(restaurantId.Value);

            }
            else
            {
                Restaurant = new Restaurant { Cuisine = CuisineType.None };
            }
           
            if (Restaurant == null)
            {
                return RedirectToPage("./NotFound");
            }
            else 
            {
                return Page();
            }
        }

        public IActionResult OnPost()
        {

            if (!ModelState.IsValid)
            {
                Cuisines = _htmlHelper.GetEnumSelectList<CuisineType>();
                return Page();
            }

            if (Restaurant.Id > 0)
            {
                _restaurantData.Update(Restaurant);              
            }
            else
            {
                _restaurantData.Add(Restaurant);
            }

            _restaurantData.Commit();

            // TempData is available to next request only
            TempData["Message"] = "Restaurant saved!";
            return RedirectToPage("./Detail", new { restaurantId = Restaurant.Id });
        }
       

    }
}