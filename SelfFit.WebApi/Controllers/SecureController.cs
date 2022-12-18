using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SelfFit.Identity.Authorization;

namespace SelfFit.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class SecureController : ControllerBase
    {
        [Authorize(Policy = Policy.ForAdminOnly)]
        [HttpGet("for-admin")]
        public IActionResult GetSecuredAdminData()
        {
            return Ok("This Secured Data is available only for Authenticated ADMINS.");
        }

        [Authorize(Policy = Policy.ForInstructorOnly)]
        [HttpGet("for-instructor")]
        public IActionResult GetSecuredInstructorData()
        {
            return Ok("This Secured Data is available only for Authenticated INSTRUCTORS.");
        }

        [HttpGet("for-default")]
        public IActionResult GetSecuredData()
        {
            return Ok("This Secured Data is available only for Authenticated.");
        }
    }
}
