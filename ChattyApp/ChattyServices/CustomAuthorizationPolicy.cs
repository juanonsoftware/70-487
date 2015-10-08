using System;
using System.Collections.Generic;
using System.IdentityModel.Claims;
using System.IdentityModel.Policy;
using System.Security.Principal;

namespace ChattyServices
{
    public class CustomAuthorizationPolicy : IAuthorizationPolicy
    {
        private readonly Guid _id = Guid.NewGuid();

        public bool Evaluate(EvaluationContext evaluationContext, ref object state)
        {
            var identity = GetClientIdentity(evaluationContext);

            evaluationContext.Properties["Principal"] = new CustomPrincipal(identity);

            return true;
        }

        public ClaimSet Issuer
        {
            get { return ClaimSet.System; }
        }

        public string Id
        {
            get { return _id.ToString(); }
        }

        private IIdentity GetClientIdentity(EvaluationContext evaluationContext)
        {
            object obj;

            if (!evaluationContext.Properties.TryGetValue("Identities", out obj))
            {
                throw new Exception("No Identity found");
            }

            var identities = obj as IList<IIdentity>;
            if (identities == null || identities.Count <= 0)
            {
                throw new Exception("No Identity found");
            }

            return identities[0];
        }
    }
}