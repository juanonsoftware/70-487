using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;

namespace ChattyServices
{
    public class CustomPrincipal : GenericPrincipal
    {
        public CustomPrincipal(IIdentity identity)
            : base(identity, GetRoles(identity).ToArray())
        {
        }

        private static IEnumerable<string> GetRoles(IIdentity identity)
        {
            if (identity.Name == "hhoangvan")
            {
                return new List<string>()
                {
                    "Administrators"
                };
            }

            return new List<string>()
            {
                "Users"
            };
        }
    }
}