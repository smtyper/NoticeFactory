using System.ComponentModel.DataAnnotations;

namespace PersonCase.ViewModels
{
    public class NoteViewModel
    {
        [Required]
        public string Title { get; set; }

        [Required]
        [MaxLength(500)]
        public string Text { get; set; }

        //public string ReturnUrl { get; set; }
    }
}
