using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace EleganzApi.Core
{
    public class EleganzUserManager : UserManager<IdentityUser>
    {
        public EleganzUserManager() : base(new EleganzUserStore())
        {

        }
    }
}
