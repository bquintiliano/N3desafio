using Microsoft.AspNetCore.Mvc;
using N3desafio.Communication.Requests;
using N3desafio.Communication.Responses;
using N3desafio.Services;

namespace N3desafio.Controllers
{
    public class BookController : N3desafioBaseController
    {
        BookServices _bookServices;
        public BookController(BookServices bookServices)
        {
            _bookServices = bookServices;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<ResponseCreateBook>),StatusCodes.Status200OK)]
        public IActionResult GetBooks()
        {
            var getBooks = _bookServices.GetBooks();
            return Ok(getBooks);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult PostBook(RequestCreateBook book)
        {
            var newBook = _bookServices.PostBook(book);
            return Created(String.Empty, newBook);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(List<ResponseCreateBook>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string),StatusCodes.Status404NotFound)]
        public IActionResult PutBook(RequestCreateBook book, int id)
        {
            var newBook = _bookServices.PutBook(book, id);

            if(newBook == null)
                return NotFound();

            return Ok(newBook);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public IActionResult DeleteBook(int id)
        {
            var newBook = _bookServices.DeleteBook(id);

            if (newBook == null)
                return NotFound();

            return Ok();
        }
    }
}
