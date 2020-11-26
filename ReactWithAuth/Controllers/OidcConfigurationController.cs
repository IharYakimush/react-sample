using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace ReactWithAuth.Controllers
{
    public class OidcConfigurationController : Controller
    {
        [HttpGet("_configuration/{clientId}")]
        public IActionResult GetClientRequestParameters([FromRoute] string clientId)
        {
            Dictionary<string, string> parameters = new()
            {
                { "authority", "https://localhost:5003" },
                { "client_id", "js" },
                { "redirect_uri", "https://localhost:5000/authentication/login-callback" },
                { "post_logout_redirect_uri", "https://localhost:5000/index.html" },
                { "response_type", "code" },
                { "scope", "openid profile api1" },
            };

            return Ok(parameters);
        }
    }
}
