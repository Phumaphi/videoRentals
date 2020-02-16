using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class MovieViewModel
    {
        public Movie Movie { get; set; }
        public List<Customer> Customers { get; set; }
        public List<Movie> Movies { get; set; }
        public IEnumerable<Genre> Genres { get; set; }
    }
}