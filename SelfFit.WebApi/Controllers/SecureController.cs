using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SelfFit.WebApi.Controllers
{
    /// <summary>
    /// rtt
    /// </summary>
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class SecureController : ControllerBase
    {
        /// <summary>
        /// rewt
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetSecuredData()
        {
            return Ok("This Secured Data is available only for Authenticated Users.");
        }
    }
}
