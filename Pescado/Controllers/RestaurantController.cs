using Pescado.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlServerCe;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Pescado.Controllers
{
    public class RestaurantController : ApiController
    {
        public IEnumerable<Restaurant> GetAllRestaurants()
        {
            var con = ConfigurationManager.ConnectionStrings["PescadoConnection"].ToString();

            List<Restaurant> Restaurants = new List<Restaurant>();
            using (SqlCeConnection myConnection = new SqlCeConnection(con))
            {
                string oString = "Select Id,Name,Description,Url from Restaurants";
                SqlCeCommand oCmd = new SqlCeCommand(oString, myConnection);
                myConnection.Open();
                using (SqlCeDataReader oReader = oCmd.ExecuteReader())
                {
                    while (oReader.Read())
                    {
                        Restaurant item = new Restaurant();
                        item.Id = Convert.ToInt16(oReader["Id"]);
                        item.Name = oReader["Name"].ToString();
                        item.Description = oReader["Description"].ToString();
                        item.Url = oReader["Url"].ToString();
                        Restaurants.Add(item);
                    }

                    myConnection.Close();
                }
            }
            return Restaurants;
        }
    }
}
