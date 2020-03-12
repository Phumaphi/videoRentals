using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class MovieViewModel
    {
        public MovieViewModel()
        {
            Id = 0;
        }

        public MovieViewModel(Movie movie)
        {

            Id = movie.Id;
            GenreId = movie.GenreId;
            NumberInStock = movie.NumberInStock;
            ReleaseDate = movie.ReleaseDate;
            Name = movie.Name;


        }
    
        public List<Movie> Movies { get; set; }
        public IEnumerable<Genre> Genres { get; set; }

        public int? Id { get; set; }
        [Required(ErrorMessage = "Please enter customer's name.")]
        public string Name { get; set; }

        [ValidaDefaultDate]
        [Required(ErrorMessage = "The Release Date field is Required.")]
        public DateTime? ReleaseDate { get; set; }

        [Range(1, 10)]
        [Required(ErrorMessage = "How many do you want?")]
        public int? NumberInStock { get; set; }

        [Display(Name = "Genre")]
        [Required]
        public int? GenreId { get; set; }

        public string Title => Id != 0 ? "Edit Movie" : "New Movie";
    }
}