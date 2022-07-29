using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_Homework.Models;
using MVC_Homework.Models.DatabaseModels;
using MVC_Homework.Services.Contracts;

namespace MVC_Homework.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorsService _authorsService;

        public AuthorsController(IAuthorsService authorsService)
        {
            _authorsService = authorsService;
        }

        // GET: api/Authors
        [HttpGet]
        public ActionResult<IEnumerable<Author>> GetAuthors() => Ok(_authorsService.GetAuthors());

        // GET: api/Authors/5
        [HttpGet("{id}")]
        public ActionResult GetAuthor(int id) => Ok(_authorsService.Get(id));

        // PUT: api/Authors/5
        [HttpPut("{id}")]
        public IActionResult PutAuthor(int id, Author author)
        {
            if (id != author.Id)
            {
                return BadRequest();
            }

            _authorsService.Update(id, author);

            return Ok();
        }

        // POST: api/Authors
        [HttpPost]
        public IActionResult PostAuthor(Author author)
        {
            _authorsService.Create(author);
            
            return Ok();
        }

        // DELETE: api/Authors/5
        [HttpDelete("{id}")]
        public IActionResult DeleteAuthor(int id)
        {
            _authorsService.Delete(id);

            return Ok();
        }
    }
}
