using Library.API.DTOs;
using Library.API.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using AutoMapper;
using System;
using Library.API.Entities;

namespace Library.API.Controllers
{
    [Route("api/authors")]
    public class AurhorsController: Controller
    {
        private ILibraryRepository _libraryRepository ; 
        public AurhorsController(ILibraryRepository libraryRepository)
        {
            _libraryRepository = libraryRepository;
        }
        [HttpGet()]
        public IActionResult GetAuthors()
        {
            var authorsFromRepo = _libraryRepository.GetAuthors();
            //Usig AutoMapper
            var authors = Mapper.Map<IEnumerable<AuthorDto>>(authorsFromRepo);
            return Ok(authors );
        }
        [HttpGet("{id}", Name = "GetAuthor")] 
        public IActionResult GetAuthor(Guid id)
        {
            var authorFromRepo = _libraryRepository.GetAuthor(id);
            if (authorFromRepo==null)
            {
                return NotFound();
            }
            var author = Mapper.Map<AuthorDto>(authorFromRepo);
            return Ok(author);
        }
        [HttpPost]
        public IActionResult CreateAuthor([FromBody]AuthorForCreationDto author)
        {
            if (author == null)
            {
                return BadRequest();
            }
            var authorEntity = Mapper.Map<Author>(author);
            _libraryRepository.AddAuthor(authorEntity);
            _libraryRepository.Save();
            if (!_libraryRepository.Save())
            {
                throw new Exception("Creating An Author Failed on Save.");
            }
            var authorToReturnDto = Mapper.Map<AuthorDto>(authorEntity);
            return CreatedAtRoute("GetAuthor",
                new
                {
                    id = authorToReturnDto.Id
                }, authorToReturnDto);
        
        }
    }
}
