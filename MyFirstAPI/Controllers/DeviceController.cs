using Microsoft.AspNetCore.Mvc;

namespace MyFirstAPI.Controllers
{
    public class DeviceController : MyFirstAPIBaseController
    {
        [HttpGet]
        public IActionResult Get()
        {
            var key = GetCustomKey();

            return Ok(key);
        }
    }
}
