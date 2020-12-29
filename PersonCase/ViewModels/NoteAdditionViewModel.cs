using System.ComponentModel.DataAnnotations;

namespace PersonCase.ViewModels
{
    public class NoteAdditionViewModel
    {
        [MaxLength(100)]
        public string Text { get; set; }
    }
}