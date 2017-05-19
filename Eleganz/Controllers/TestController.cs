using EleganzApi.Core;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace EleganzApi.Controllers
{
    public class TestController : ApiController
    {
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public Object Get()
        {
            using (var context = new EleganzContext())
            {
                return Ok(new { result = new List<string>() { "Test1", "Test2", "Test3" } });
            }
        }
    }
}
