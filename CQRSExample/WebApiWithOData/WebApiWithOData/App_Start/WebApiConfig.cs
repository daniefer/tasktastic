using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.OData.Builder;
using System.Web.OData.Extensions;
using Contracts;
using WebApiWithOData.Models;

namespace WebApiWithOData
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var builder = new ODataConventionModelBuilder();

            builder.EntitySet<DtoTask>("Task");
            //builder.EntitySet<DtoReminder>("Reminder");


            config.MapODataServiceRoute("ODataRoute", "api", builder.GetEdmModel());
        }
    }
}
