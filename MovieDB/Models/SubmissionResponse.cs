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
        [Required(ErrorMessage = "Required Field")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Required Field")]
        public short Year { get; set; }
        [Required(ErrorMessage = "Required Field")]
        public string Director { get; set; }
        [Required(ErrorMessage = "Required Field")]
        public string Rating { get; set; }
        public bool Edited { get; set; }
        public string LentTo { get; set; }
        /*for the text restraint on notes*/
        [MaxLength(25)]
        public string Notes { get; set; }
    }
}
