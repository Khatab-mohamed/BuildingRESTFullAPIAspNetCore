using Library.API.Services;
using Microsoft.AspNetCore.Mvc;
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

        public IActionResult GetAuthors()
        {
            var authorsFromRepo = _libraryRepository.GetAuthors();
            return new JsonResult(authorsFromRepo);
        }
    }
}
