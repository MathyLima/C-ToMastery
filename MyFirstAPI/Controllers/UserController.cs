using Microsoft.AspNetCore.Mvc;
using MyFirstAPI.Communication.Requests;
using MyFirstAPI.Communication.Responses;

namespace MyFirstAPI.Controllers
{
   
    public class UserController : MyFirstAPIBaseController
    {
        [HttpGet]
        [ProducesResponseType(typeof(List<User>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status204NoContent)]
        public IActionResult GetAll()
        {
            var response = new List<User>()
            {
                new User {Id = 1,Age = 23, Name = "Matheus"},
                new User {Id = 2,Age = 30, Name = "João"},


            };

            return Ok(response);
        }

        [HttpGet]
        [Route("{id}/person/{nickname}")]
        [ProducesResponseType(typeof(User), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public IActionResult GetById([FromRoute] int id, [FromRoute] string nickname)
        {

            var response = new User
            {
                Id = id,
                Age = 7,
                Name = "Matheus"

            };

            return Ok(response);
        }


        [HttpPost]
        [ProducesResponseType(typeof(ResponseRegisterUserJson), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public IActionResult Create([FromBody] RequestRegisterUserJson request)
        {
            var response = new ResponseRegisterUserJson
            {
                Id = 1,
                Name = request.Name
            };
            return Created(string.Empty, response);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult Update([FromBody] RequestUpdateUserProfileJson request)
        {
            return NoContent();
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult Delete()
        {
            return NoContent();

        }
        [HttpPut("change-password")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult ChangePassword([FromBody] RequestChangePassword request)
        {
            return NoContent();
        }
    }
}
