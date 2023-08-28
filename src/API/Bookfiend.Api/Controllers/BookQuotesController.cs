using Bookfiend.Application.Features.BookQuote.Commands.CreateBookQuote;
using Bookfiend.Application.Features.BookQuote.Commands.DeleteBookQuote;
using Bookfiend.Application.Features.BookQuote.Commands.UpdateBookQuote;
using Bookfiend.Application.Features.BookQuote.Queries.GetAllBookQuotes;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Bookfiend.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookQuotesController : ControllerBase
    {
        private readonly ISender _mediator;

        public BookQuotesController(ISender mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<BookQuotesController>
        [Authorize(Policy ="BookQuoteListPermission")]
        [HttpGet]
        public async Task<List<BookQuoteDto>> Get()
        {
            var BookQuotes = await _mediator.Send(new GetAllBookQuotesQuery());
            return BookQuotes;
        }

        // GET api/<BookQuotesController>/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<BookQuoteDetailsDto>> Get(int id)
        //{
        //    var BookQuote = await _mediator.Send(new GetBookQuoteDetailsQuery(id));
        //    return BookQuote;
        //}

        // POST api/<BookQuotesController>
        [Authorize(Policy = "BookQuoteCreatePermission")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Post(CreateBookQuoteCommand BookQuote)
        {
            var response = await _mediator.Send(BookQuote);
            return CreatedAtAction(nameof(Get), new { id = response });
        }

        // PUT api/<BookQuotesController>/5
        [Authorize(Policy = "BookQuoteUpdatePermission")]
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Put(UpdateBookQuoteCommand BookQuote)
        {
            await _mediator.Send(BookQuote);
            return NoContent();
        }

        // DELETE api/<BookQuotesController>/5
        [Authorize(Policy = "BookQuoteDeletePermission")]
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteBookQuoteCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
