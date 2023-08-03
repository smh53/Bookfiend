using Bookfiend.Application.Features.Book.Commands.CreateBook;
using Bookfiend.Application.Features.Book.Commands.DeleteBook;
using Bookfiend.Application.Features.Book.Commands.UpdateBook;
using Bookfiend.Application.Features.Book.Queries.GetAllBooks;
using Bookfiend.Application.Features.Book.Queries.GetBookDetails;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Bookfiend.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly ISender _mediator;

        public BooksController(ISender mediator)
        {
            _mediator = mediator;
        }


        // GET: api/<BooksController>
        [HttpGet]
        public async Task<List<BookDto>> Get()
        {
           var books = await _mediator.Send(new GetAllBooksQuery());
            return books;
        }

        // GET api/<BooksController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BookDetailsDto>> Get(int id)
        {
            var book = await _mediator.Send(new GetBookDetailsQuery(id));
            return book;
        }

        // POST api/<BooksController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Post(CreateBookCommand book)
        {
            var response = await _mediator.Send(book);
            return CreatedAtAction(nameof(Get),new {id = response });
        }

        // PUT api/<BooksController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Put(UpdateBookCommand book)
        {
            await _mediator.Send(book);
            return NoContent();
        }

        // DELETE api/<BooksController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteBookCommand { Id = id};
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
