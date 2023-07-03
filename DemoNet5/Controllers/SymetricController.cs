using DemoNet5.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DemoNet5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SymetricController : ControllerBase
    {
        [Authorize(AuthenticationSchemes = "symetric")]
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("jwt symetric ok.");
        }

        [HttpPost]
        public IActionResult GetSymetricToken()
        {
            return Ok(new TokenService().GerarSymetric());
        }
    }
}
