using Microsoft.AspNetCore.Mvc;
using OdeToFoodCoreData;

namespace OdeToFoodCore.Pages.ViewComponents
{

    // cabob casing restaurant-count 
    public class RestaurantCountViewComponent : ViewComponent
    {

        private readonly IRestaurantData _restaurantData;

        public RestaurantCountViewComponent(IRestaurantData inRestaurantData)
        {
            this._restaurantData = inRestaurantData;
        }

        public IViewComponentResult Invoke() 
        {

            var _count = _restaurantData.GetCountOfRestaurants();
            return View(_count);
        }

    }
}
