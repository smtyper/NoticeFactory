using System;
using System.ComponentModel.DataAnnotations;

namespace PersonCase.Models
{
    public class NoteAddition : HasId<Guid>
    {
        public NoteAddition(Guid id, string text, DateTime creationDate, Guid noteId) : base(id)
        {
            Text = text;
            CreationDate = creationDate;
            NoteId = noteId;
        }

        [MaxLength(100)]
        public string Text { get; protected set; }

        public DateTime CreationDate { get; protected set; }

        public Guid NoteId { get; protected set; }

        public virtual Note Note { get; protected set; }
    }
}
