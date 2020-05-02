using System;
using System.Collections.Generic;
using AutoMapper;
using CourseLibrary.API.Entities;
using CourseLibrary.API.Models;
using CourseLibrary.API.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CourseLibrary.API.Controllers
{
    [ApiController]
    [Route("api/authors-collection")]
    public class AuthorsColectionController : ControllerBase
    {
        private readonly ICourseLibraryRepository _courseLibraryRepository;
        private readonly IMapper _mapper;

        public AuthorsColectionController(ICourseLibraryRepository courseLibraryRepository, IMapper mapper)
        {
            _courseLibraryRepository = courseLibraryRepository ??
                throw new ArgumentNullException(nameof(courseLibraryRepository));

            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpPost]
        public ActionResult<IEnumerable<AuthorDto>> CreateAuthorCollection(
            IEnumerable<AuthorForCreationDto> authorCollection)
        {
            var authorEntities = _mapper.Map<IEnumerable<Author>>(authorCollection);
            foreach (var author in authorEntities)
            {
                _courseLibraryRepository.AddAuthor(author);
            }

            _courseLibraryRepository.Save();

            return Ok();
        }
    }
}