using Library.API.DTOs;
using Library.API.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using AutoMapper;
using System;

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
            return new JsonResult(authors );
        }
        [HttpGet("{id}")]
        public IActionResult GetAuthor(Guid id)
        {
            var authorFromRepo = _libraryRepository.GetAuthor(id);
            var author = Mapper.Map<AuthorDto>(authorFromRepo);
            return new JsonResult(author);
        }
    }
}
