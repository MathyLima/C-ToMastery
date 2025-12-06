using GamingOrganization.API.Entities;
using GammingOrganization.Communication.Requests.UserTask;
using GammingOrganization.Communication.Responses.UserTask;
using Microsoft.AspNetCore.Mvc;

namespace GamingOrganization.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(typeof(List<UserTask>),StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult GetAll()
        {
            return Ok();
        }
        [HttpGet]
        [Route("{Id}")]
        [ProducesResponseType(typeof(UserTask), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Get([FromRoute]Guid Id)
        {
            return Ok();
        }

        [HttpPost]
        [ProducesResponseType(typeof(ResponseUserTaskJson),StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Create(RequestUserTaskJson request)
        {
            return Created();
        }

        [HttpDelete]
        [Route("{Id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult Delete([FromRoute]Guid Id) {
            return NoContent(); 
        }

    }
}
