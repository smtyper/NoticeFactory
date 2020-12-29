using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PersonCase.Data;
using PersonCase.Models.Dtos;

namespace PersonCase.Controllers.Api
{
    [ApiController]
    [Route("api/[controller]")]
    public class NoteController : ControllerBase
    {
        private readonly ApplicationContext _dbContext;

        public NoteController(ApplicationContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<NoteDto>), StatusCodes.Status200OK)]
        public ActionResult<List<NoteDto>> Get() => _dbContext.Notes
                .Select(note => new NoteDto
                {
                    Id = note.Id,
                    Text = note.Text,
                    Title = note.Title,
                    CreationDate = note.CreationDate,
                    AuthorId = note.UserId,
                    NoteAdditions = note.NoteAdditions
                            .Select(x => new NoteAdditionDto
                            {
                                CreationDate = x.CreationDate,
                                Text = x.Text
                            })
                }
                )
                .ToList();
    }
}
