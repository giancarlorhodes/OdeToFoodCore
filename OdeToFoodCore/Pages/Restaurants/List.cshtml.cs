using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using OdeToFoodCoreCommon;
using OdeToFoodCoreData;

namespace OdeToFoodCore.Pages.Restaurants
{
    public class ListModel : PageModel
    {

        
        private readonly IConfiguration _config;
        private readonly IRestaurantData _restaurantData;
        private readonly ILogger _logger;


        // outputs models
        public string Message { get; set; }
        public IEnumerable<Restaurant> Restaurants { get; set; }
        
        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get;set; }

        public ListModel(IConfiguration inConfig, IRestaurantData inRestaurantData, ILogger<ListModel> logger)
        {
            _config = inConfig;
            _restaurantData = inRestaurantData;
            _logger = logger;
        }


        // model binding from input field
        // input name must be a exact match to the method parameter name
        public void OnGet()
        {

            // Message = "Hello, World!";
            Message = _config["Message"];
            //Restaurants = _restaurantData.GetAll(); // OLD
            Restaurants = _restaurantData.GetRestaurantsByName(SearchTerm);
        }
    }
}