using OdeToFoodCoreCommon;
using System.Collections.Generic;
using System.Linq;

namespace OdeToFoodCoreData
{
    public class InMemoryRestaurantData : IRestaurantData
    {

        private List<Restaurant> _restaurants;

        public InMemoryRestaurantData() 
        {
            _restaurants = new List<Restaurant>()
            {
                new Restaurant(){ Cuisine = CuisineType.Italian, Id = 1, Location="St. Louis, MO", Name="Giancarlo's Spegetti" },
                new Restaurant(){ Cuisine = CuisineType.Japanese, Id = 2, Location="Oak Brook, IL", Name="Kai Sushi" },
                new Restaurant(){ Cuisine = CuisineType.Mexican, Id = 3, Location="New York, New York", Name = "Scott's Tacos"}
                
            };
        
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return _restaurants.OrderBy(r => r.Name);
        }

        public IEnumerable<Restaurant> GetRestaurantsByName(string inName = null)
        {
            return from r in _restaurants
                   where string.IsNullOrEmpty(inName) || r.Name.StartsWith(inName)
                   orderby r.Name
                   select r;
                
        }
    }


}
