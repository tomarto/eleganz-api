using System.Web.Http;

namespace EleganzApi.App_Start
{
    public class FilterConfig
    {
        public static void Configure(HttpConfiguration config)
        {
            config.Filters.Add(new AuthorizeAttribute());
        }
    }
}
