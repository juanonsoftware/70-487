using System.Globalization;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http;
using WebApiSecurity.Models;

namespace WebApiSecurity.Controllers
{
    [ApiAuthenticationFilter]
    public class AccountController : ApiController
    {
        [HttpGet]
        public HttpResponseMessage Authenticate()
        {
            if (Thread.CurrentPrincipal != null &&
                Thread.CurrentPrincipal.Identity.IsAuthenticated)
            {
                return GetAuthToken();
            }

            return null;
        }

        private HttpResponseMessage GetAuthToken()
        {
            var response = Request.CreateResponse(HttpStatusCode.OK, "Authorized");

            var token = TokenService.GenerateToken();
            // TODO: encrypt token

            response.Headers.Add("Token", token.AuthToken);
            response.Headers.Add("TokenExpires", token.ExpiresOn.ToString(CultureInfo.InvariantCulture));
            response.Headers.Add("Access-Control-Expose-Headers", "Token, TokenExpires");

            return response;
        }
    }
}