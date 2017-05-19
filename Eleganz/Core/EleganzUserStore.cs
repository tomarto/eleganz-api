using Microsoft.AspNet.Identity.EntityFramework;

namespace EleganzApi.Core
{
    public class EleganzUserStore : UserStore<IdentityUser>
    {
        public EleganzUserStore() : base(new EleganzContext())
        {

        }
    }
}
