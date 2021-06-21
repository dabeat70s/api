using CourseLibrary.API.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseLibraryAPI.Controllers
{
    [ApiController]
    // [Route("api/[controller]")]
    [Route("api/authors")]
    public class AuthorsController : ControllerBase
    {
        private readonly ICourseLibraryRepository _courseLibraryRepository;

        public AuthorsController(ICourseLibraryRepository courseLibraryRepository)
        {
            _courseLibraryRepository = courseLibraryRepository ??
                throw new ArgumentNullException(nameof(courseLibraryRepository));
        }

        //[HttpGet("api/[controller]")]
        [HttpGet()]
        public IActionResult GetAuthors()
        {
            
            var authors = _courseLibraryRepository.GetAuthors();
            return Ok(authors); //new JsonResult(authors);
        }

        [HttpGet("{authorId:guid}")]
        public IActionResult GetAuthor(Guid authorId)
        {
            var authorFromRepo = _courseLibraryRepository.GetAuthor(authorId);

            if (authorFromRepo == null)
            {
                return NotFound();
            }

            return Ok(authorFromRepo);
        }






        [HttpGet("{authorId}")]
        public IActionResult GetAuthorMe(string authorId)
        {


            if (authorId == "CLINT")
            {
                return Ok("Your Name Must Be Clint Adams");
            }

            return NotFound();
        }
        [HttpGet("{authorId:int}")]
        public IActionResult GetAuthornUM(int authorId)
        {


            if (authorId == 22)
            {
                return Ok("Your Name Must Be Clint Adams of age" + authorId);
            }

            return NotFound();
        }

    }
}
