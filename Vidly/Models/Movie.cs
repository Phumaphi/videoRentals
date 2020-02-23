using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Movie
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter customer's name.")]
        public string Name { get; set; }

        [ValidaDefaultDate]
        [Required(ErrorMessage = "The Release Date field is Required.")]
        public DateTime ReleaseDate { get; set; }
        public DateTime DateAdded { get; set; }

        [Range(1, 10)]
        [Required(ErrorMessage = "How many do you want?")]
        public int NumberInStock { get; set; }

        [Display(Name = "Genre")]
        public int GenreId { get; set; }    
        public Genre Genre { get; set; }
        public static DateTime DateofMovieReleased = new DateTime();
    }
}