using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoNet5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenericController : ControllerBase
    {
        [Authorize(AuthenticationSchemes = "ECDsa")]
        [Authorize(AuthenticationSchemes = "Rsa")]
        [Authorize(AuthenticationSchemes = "symetric")]
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Sucesso!");
        }
    }
}
