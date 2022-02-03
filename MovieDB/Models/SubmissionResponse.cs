using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

/*submission model*/
namespace MovieDB.Models
{
    public class SubmissionResponse
    {
        /*key for database table, and then required fields as needed*/
        [Key]
        [Required]
        public int SubmissionId { get; set; }
        [Required(ErrorMessage = "You can't forget the title!")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Please add the year the film was released.")]
        public short Year { get; set; }
        [Required(ErrorMessage = "Go on IMDB and add the director to this film.")]
        public string Director { get; set; }
        [Required(ErrorMessage = "As per law, MPAA rating required.")]
        public string Rating { get; set; }
        public bool Edited { get; set; }
        public string LentTo { get; set; }
        /*for the text restraint on notes*/
        [MaxLength(25)]
        public string Notes { get; set; }
        [Required(ErrorMessage = "Pick a category!")]

        //Build Foreign Key Relations
        public int CategoryID { get; set; }
        public Category Category { get; set; }
    }
}
