using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private readonly VidlyDbContext _vidlyDbContext;

        public MoviesController()
        {
            _vidlyDbContext = new VidlyDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            _vidlyDbContext.Dispose();
        }
        // GET: Movies/Index
        public ActionResult Index()
        {

            var viewModel = new MovieViewModel
            {
                Movies = _vidlyDbContext.Movies.Include(g => g.Genre).ToList()
            };

            return View(viewModel);
        }

        public ActionResult Details(int id)
        {


        var movie = _vidlyDbContext.Movies.Include(m => m.Genre).FirstOrDefault(c => c.Id == id);
                
            
            if (movie == null) return HttpNotFound($"this id {id} you pass is not in the system");
            //var movObj = new
            //{
            //    releasedate = movie.ReleaseDate.ToShortDateString(),
            //    dateAded = movie.DateAdded.ToLongDateString(),
            //    genreType = movie.Genre.Name,
            //    movie = movie.Name,
            //    movieItemOrdered = movie.NumberInStock
            //};

            return View(movie);
        }

        //[Route("movies/released/{year}/{month}")]
        //public ActionResult ByReleaseYear(int year, int month)
        //{
        //    return Content(year + "/" + month);
        //}

        public ActionResult MovieForm(Movie m)
        {
          
          var genres = _vidlyDbContext.Genres.ToList();
            var movieViewModel=new MovieViewModel()
            {
                Genres = genres,
               Movie = m
            };
          
            return View("MovieForm", movieViewModel);
        }
        [HttpPost]
        public ActionResult Save(Movie movie)
        {
           
            if (movie.Id == 0)
            {
                movie.DateAdded = DateTime.Now;
                _vidlyDbContext.Movies.Add(movie);
            }


            else
            {
                var movieUpdate = _vidlyDbContext.Movies.Single(m => m.Id == movie.Id);

                movieUpdate.GenreId = movie.GenreId;
                movieUpdate.Name = movie.Name;
                movieUpdate.ReleaseDate = movie.ReleaseDate;
                movieUpdate.NumberInStock = movie.NumberInStock;
            }

            _vidlyDbContext.SaveChanges();

            return RedirectToAction("Index","Movies");
        }

        public ActionResult Edit(int id)
        {
            var movie = _vidlyDbContext.Movies.Single(c => c.Id == id);
            if (movie ==null)
            {
                return HttpNotFound();
            }

            var model = new MovieViewModel
            {
                Genres = _vidlyDbContext.Genres.ToList(),
                Movie = movie
            };
            return View ("MovieForm", model);
        }

    
    }


}