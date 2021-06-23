﻿using AutoMapper;
using CourseLibrary.API.Entities;
using CourseLibrary.API.Helpers;
using CourseLibrary.API.Models;
using CourseLibrary.API.Services;
using CourseLibraryAPI.ResourceParameters;
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
        public ActionResult<IEnumerable<AuthorDto>> GetAuthors(
            [FromQuery] AuthorsResourceParameters authorsResourceParameters)
        {                      
            var authorsFromRepo = _courseLibraryRepository.GetAuthors(authorsResourceParameters);
           

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

        [HttpGet("{authorId:guid}",Name ="GetAuthor")]
        public IActionResult GetAuthor(Guid authorId)
        {
            var authorFromRepo = _courseLibraryRepository.GetAuthor(authorId);

            if (authorFromRepo == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<AuthorDto>(authorFromRepo));
        }

        [HttpPost]
        public ActionResult<AuthorDto> CreateAuthor(AuthorForCreationDto author)
        {
            var authorEntity = _mapper.Map<Author>(author);
            _courseLibraryRepository.AddAuthor(authorEntity);
            _courseLibraryRepository.Save();

            var authorToReturn = _mapper.Map<AuthorDto>(authorEntity);
            return CreatedAtRoute("GetAuthor",
                new { authorId = authorToReturn.Id },
                authorToReturn);
        }


        [HttpOptions]
        public IActionResult GetAuthorsOptions()
        {
            Response.Headers.Add("Allow", "GET,OPTIONS,POST");
            return Ok();
        }

        [HttpDelete("{authorId}")]
        public ActionResult DeleteAuthor(Guid authorId)
        {
            var authorFromRepo = _courseLibraryRepository.GetAuthor(authorId);

            if (authorFromRepo == null)
            {
                return NotFound();
            }

            _courseLibraryRepository.DeleteAuthor(authorFromRepo);

            _courseLibraryRepository.Save();

            return NoContent();
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
