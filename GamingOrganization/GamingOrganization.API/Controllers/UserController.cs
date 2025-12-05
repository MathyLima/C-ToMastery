using GamingOrganization.API.UseCases.Users.Delete;
using GamingOrganization.API.UseCases.Users.GetAll;
using GamingOrganization.API.UseCases.Users.GetById;
using GamingOrganization.API.UseCases.Users.Register;
using GammingOrganization.Communication.Requests.User;
using GammingOrganization.Communication.Responses;
using GammingOrganization.Communication.Responses.User;
using Microsoft.AspNetCore.Mvc;
using ProductClientHub.Exceptions.ExceptionsBase;

namespace GamingOrganization.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(typeof(ResponseAllUserJson),StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult GetAll()
        {
            var useCase = new GetAllUsersUseCase();
            var response = useCase.Execute();
            if (response.Users.Count == 0)
            {
                return NoContent();
            }
            return Ok(response);
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(ResponseUserJson),StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(NotFoundException),StatusCodes.Status404NotFound)]
        public IActionResult GetById([FromRoute] Guid id) {
            var useCase = new GetByIdUserUseCase();
            var response = useCase.Execute(id);
            return Ok(response);
        }

        [HttpPost]
        [ProducesResponseType(typeof(ResponseShortUserJson),StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseErrorMessagesJson),StatusCodes.Status400BadRequest)]
        public IActionResult Create(RequestUserJson request)
        {
            var useCase = new RegisterUserUseCase();
            var response = useCase.Execute(request);

            return Created(string.Empty,response);
        }

        [HttpPut]
        public IActionResult Update() {
            return Ok();
        }

        [HttpDelete]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(NotFoundException),StatusCodes.Status404NotFound)]
        public IActionResult Delete([FromRoute] Guid id) {
            var useCase = new DeleteUserUseCase();
            useCase.Execute(id);
            return NoContent();
        }

    }
}
