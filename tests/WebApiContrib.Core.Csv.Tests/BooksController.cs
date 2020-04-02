using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace WebApiContrib.Core.Csv.Tests
{
    [Route("api/books")]
    public class BooksController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(Book.Data);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (Book.Data.Length >= id && id > 0)
            {
                return Ok(Book.Data[id - 1]);
            }

            return Ok(null);
        }

        [HttpGet("enumerable")]
        public IEnumerable<Book> GetEnumerable()
        {
            return Enumerable.Range(0, Book.Data.Length).Select(i => Book.Data[i]);
        }

        [HttpPost]
        public IActionResult Post([FromBody]Book book)
        {
            return Ok(book);
        }
    }
}
