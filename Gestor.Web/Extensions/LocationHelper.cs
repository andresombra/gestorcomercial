using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace Gestor.Web.Extensions
{
    public static class LocationHelper
    {
        /// <summary>
        /// Dados sobre a localização obtido da rota atual
        /// </summary>
        public class LocationData
        {
            public string ActionName { get; set; }

            public string ControllerName { get; set; }
        }
        public static LocationData GetLocationData<TModel>(this ViewComponent page)
        {
            // TODO: validate page, ViewContext, RouteData, Values
            //      for:
            //          not null, contain values
            return new LocationData()
            {
                ActionName = (string)page.ViewContext.RouteData.Values["action"],
                ControllerName = (string)page.ViewContext.RouteData.Values["controller"]
                // TODO: get area name
            };
        }
    }
}
