using EleganzApi.App_Start;
using EleganzApi.Core;
using Newtonsoft.Json.Serialization;
using System.Data.Entity;
using System.Web;
using System.Web.Http;

namespace EleganzApi
{
    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            Database.SetInitializer(new Initializer());

            // Set application to return camelCase JSON
            var settings = GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings;
            settings.Formatting = Newtonsoft.Json.Formatting.Indented;
            settings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            // Uncomment to Restrict access to everything unless authenticated.
            // GlobalConfiguration.Configure(FilterConfig.Configure);
        }
    }
}
