using Microsoft.AspNetCore.Mvc;
using ProductClientHub.API.UseCases.Clients.Delete;
using ProductClientHub.API.UseCases.Clients.GetAll;
using ProductClientHub.API.UseCases.Clients.Register;
using ProductClientHub.API.UseCases.Clients.Update;
using ProductClientHub.API.UseCases.GetById;
using ProductClientHub.Communication.Requests;
using ProductClientHub.Communication.Responses;
namespace ProductClientHub.API.Controllers

{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(ResponseShortClientJson),StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseErrorMessagesJson),StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ResponseErrorMessagesJson),StatusCodes.Status500InternalServerError)]
        public IActionResult Register([FromBody]RequestsClientJson request)
        {
           var useCase = new RegisterClientUseCase();
          var response = useCase.Execute(request);
            return Created(string.Empty,response);
        }

        [HttpPut]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ResponseErrorMessagesJson), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ResponseErrorMessagesJson), StatusCodes.Status404NotFound)]
        public IActionResult Update([FromRoute] Guid id,[FromBody] RequestsClientJson request)
        {
            var useCase = new UpdateClientUseCase();
            useCase.Execute(id,request);
            return NoContent();
        }

        [HttpGet]
        [ProducesResponseType(typeof(ResponseAllClientsJson), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult GetAll()
        {
            var useCase = new GetAllClientsUseCase();
            var response = useCase.Execute();

            if(response.Clients.Count == 0)
            {
                return NoContent();
            }

            return Ok(response);
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(ResponseClientJson),StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseErrorMessagesJson), StatusCodes.Status404NotFound)]
        public IActionResult GetById([FromRoute]Guid id)
        {
            var useCase = new GetCLientByIdUseCase();
            var response = useCase.Execute(id);
            return Ok(response);
        }


        [HttpDelete]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ResponseErrorMessagesJson), StatusCodes.Status404NotFound)]
        public IActionResult Delete([FromRoute] Guid id)
        {
            var useCase = new DeleteClientCase();
            useCase.Execute(id);
            // Implementation for deleting a product goes here
            return NoContent();
        }
    }
}
