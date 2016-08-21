using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.OData.Builder;
using System.Web.OData.Extensions;
using System.Web.OData.Routing;
using System.Web.OData.Routing.Conventions;
using Contracts;
using Microsoft.OData.Edm;

namespace WebApiWithODataRead
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            ODataConventionModelBuilder builder = new ODataConventionModelBuilder();


            //EntitySetConfiguration<Task> entitySet = builder.EntitySet<Task>("Task");

            //ODataRoute routes = config.MapODataServiceRoute(routeName:"ODataRoute", 
            //    routePrefix:"read/{codeType}", 
            //    model:builder.GetEdmModel()
            //    );
        }
    }

    public class CodeTypePathHandler : DefaultODataPathHandler
    {
        public override ODataPath Parse(IEdmModel model, string serviceRoot, string odataPath)
        {
            // Code made to remove the "codeType"

            // expected format of odataPath: "read/codeType/..."

            // This is assuming the codeType start after the first "/" The first slash should come after "read"
            int codeTypeIndex = odataPath.IndexOf("/", StringComparison.OrdinalIgnoreCase);
            string tempPath = odataPath.Substring(codeTypeIndex + 1);

            // find the "/" after the codeType
            codeTypeIndex = odataPath.IndexOf("/", StringComparison.OrdinalIgnoreCase);
            string codeType = tempPath.Substring(0, codeTypeIndex + 1);

            // now remove the codeType from the path. Should be of the form "codeType/"
            odataPath = odataPath.Replace(codeType + "/", string.Empty);

            // Now OData will route the request normaly since the route will only have "/Products('ABC123')"
            return base.Parse(model, serviceRoot, odataPath);
        }
    }
}
