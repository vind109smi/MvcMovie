using System;
using System.ComponentModel.DataAnnotations;

namespace MvcMovie.Models
{
    public class Review
    {
        public int ReviewID { get; set; }

        [Display(Name = "Comment")]
        [Required(ErrorMessage = "Detail is required")]
        public string Detail { get; set; }

        [Display(Name ="Reviewed By")]
        [StringLength(60, MinimumLength =3)]
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [StringLength(100000, MinimumLength = 10)]
        [Required]
        public string MovieReview { get; set; }

        [Display(Name = "Movie")]
        [Required(ErrorMessage = "Please select a movie")]
        public int MovieID { get; set; }

        public Movie Movie { get; set; }

    }
}
