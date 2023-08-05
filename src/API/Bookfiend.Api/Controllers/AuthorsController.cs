
using Bookfiend.Application.Features.Author.Commands.CreateAuthor;
using Bookfiend.Application.Features.Author.Commands.DeleteAuthor;
using Bookfiend.Application.Features.Author.Commands.UpdateAuthor;
using Bookfiend.Application.Features.Author.Queries.GetAllAuthors;
using Bookfiend.Application.Features.Author.Queries.GetAuthorDetails;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Authorfiend.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly ISender _mediator;

        public AuthorsController(ISender mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<AuthorsController>
        [HttpGet]
        public async Task<List<AuthorDto>> Get()
        {
            var Authors = await _mediator.Send(new GetAllAuthorsQuery());
            return Authors;
        }

        // GET api/<AuthorsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AuthorDetailsDto>> Get(int id)
        {
            var Author = await _mediator.Send(new GetAuthorDetailsQuery(id));
            return Author;
        }

        // POST api/<AuthorsController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Post(CreateAuthorCommand Author)
        {
            var response = await _mediator.Send(Author);
            return CreatedAtAction(nameof(Get), new { id = response });
        }

        // PUT api/<AuthorsController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Put(UpdateAuthorCommand Author)
        {
            await _mediator.Send(Author);
            return NoContent();
        }

        // DELETE api/<AuthorsController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteAuthorCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
