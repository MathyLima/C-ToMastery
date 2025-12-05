using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MyFirstAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class MyFirstAPIBaseController : ControllerBase
    {
        public string Author { get; set; } =  "Matheus Yago";
        [HttpGet("healthy")]
        public IActionResult Heathy()
        {
            return Ok("API is healthy");
        }
        protected string GetCustomKey()
        {
            return Request.Headers["MyKey"].ToString();
        }
    }
}
