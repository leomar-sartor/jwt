using DemoNet5.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DemoNet5.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RsaController : ControllerBase
    {
        [HttpGet]
        [Authorize(AuthenticationSchemes = "Rsa")]
        public IActionResult Get()
        {
            return Ok("jwt Rsa assymetric ok.");
        }


        [HttpPost]
        public IActionResult GerarToken()
        {
            return Ok(new TokenService().GerarRSA());
        }
    }
}
