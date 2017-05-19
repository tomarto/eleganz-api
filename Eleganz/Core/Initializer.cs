using System.Data.Entity;

namespace EleganzApi.Core
{
    public class Initializer : MigrateDatabaseToLatestVersion<EleganzContext, Configuration>
    {
    }
}
