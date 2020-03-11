using OdeToFoodCoreCommon;
using System;
using System.Collections.Generic;
using System.Text;

namespace OdeToFoodCoreData
{


    // dependency inversion principle is used by CORE
    public interface IRestaurantData
    {

        IEnumerable<Restaurant> GetAll();


        IEnumerable<Restaurant> GetRestaurantsByName(string inName);
    }


}
