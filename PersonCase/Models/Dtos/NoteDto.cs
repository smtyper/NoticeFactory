using System;
using System.Collections.Generic;

namespace PersonCase.Models.Dtos
{
    public class NoteDto
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Text { get; set; }

        public DateTime CreationDate { get; set; }

        public Guid AuthorId { get; set; }

        public IEnumerable<NoteAdditionDto> NoteAdditions { get; set; }
    }
}
