using System.Web.Http;
using API_ODATA.Models;
using Microsoft.AspNet.OData.Batch;
using Microsoft.AspNet.OData.Builder;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.OData.Edm;

namespace API_ODATA
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapODataServiceRoute(
                "odata",
                null,
                GetEdmModel(),
                new DefaultODataBatchHandler(GlobalConfiguration.DefaultServer)
            );
            config.EnsureInitialized();
        }

        private static IEdmModel GetEdmModel()
        {
            ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
            builder.Namespace = "Demos";
            builder.ContainerName = "DefaultContainer";
            var people = builder.EntitySet<People>("People");
            people.EntityType.Count().Filter().Page(100,100).OrderBy().Expand().Select();
            var comments = builder.EntitySet<Comments>("Comments");
            comments.EntityType.Count().Filter().Page(100, 100).OrderBy().Expand().Select();

            var functionPeople = builder.Function("AnotherData");
            functionPeople.ReturnsCollectionFromEntitySet<People>("People");

            var edmModel = builder.GetEdmModel();
            return edmModel;
        }
    }
}
