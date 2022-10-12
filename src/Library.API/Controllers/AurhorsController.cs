using Library.API.DTOs;
using Library.API.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using AutoMapper;

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
    }
}
