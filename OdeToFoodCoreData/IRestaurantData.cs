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


        Restaurant GetById(int id);


        Restaurant Update(Restaurant updatedRestaurant);
        int Commit();

        Restaurant Add(Restaurant addRestaurant);

        Restaurant Delete(int deleteRestaurantId);

    }


}
