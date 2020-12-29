using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PersonCase.Models
{
    public class Note : HasId<Guid>
    {
        public string Title { get; protected set; }

        [MaxLength(500)]
        public string Text { get; protected set; }

        public DateTime CreationDate { get; protected set; }

        public Guid UserId { get; protected set; }

        public virtual User User { get; protected set; }

        public virtual ICollection<NoteAddition> NoteAdditions { get; set; }

        public Note(Guid id, string title, string text, DateTime creationDate, Guid userId) : base(id)
        {
            Text = text;
            CreationDate = creationDate;
            UserId = userId;
            Title = title;
        }

        protected Note(DateTime creationDate, Guid userId)
        {
            CreationDate = creationDate;
            UserId = userId;
        }
    }
}
