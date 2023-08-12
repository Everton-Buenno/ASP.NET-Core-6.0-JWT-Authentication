using Microsoft.AspNetCore.Identity;

namespace ASP.NET_Core_6._0_JWT_Authentication.Entities
{
    public class ApplicationUser : IdentityUser
    {

            public string Name { get; set; }

            public string LastName { get; set; }

            public int Age { get; set; }


    }
}
