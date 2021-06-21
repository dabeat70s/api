using AutoMapper;
using CourseLibrary.API.Helpers;
using CourseLibrary.API.Models;
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
        private readonly IMapper _mapper;

        public AuthorsController(
            ICourseLibraryRepository courseLibraryRepository, IMapper mapper)
        {
            _courseLibraryRepository = courseLibraryRepository ??
                throw new ArgumentNullException(nameof(courseLibraryRepository));
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }

        //[HttpGet("api/[controller]")]
        [HttpGet()]
        [HttpHead]
        public ActionResult<IEnumerable<AuthorDto>> GetAuthors()
        {                      
            var authorsFromRepo = _courseLibraryRepository.GetAuthors();
           

            //var authors = new List<AuthorDto>();

            //foreach (var author in authorsFromRepo)
            //{
            //    authors.Add(new AuthorDto()
            //    {
            //        Id = author.Id,
            //        Name = $"{author.FirstName} {author.LastName}",
            //        MainCategory = author.MainCategory,
            //        Age = author.DateOfBirth.GetCurrentAge()
            //    });
            //}

            return Ok(_mapper.Map<IEnumerable<AuthorDto>>(authorsFromRepo)); //new JsonResult(authors);
        }

        [HttpGet("{authorId:guid}")]
        public IActionResult GetAuthor(Guid authorId)
        {
            var authorFromRepo = _courseLibraryRepository.GetAuthor(authorId);

            if (authorFromRepo == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<AuthorDto>(authorFromRepo));
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
