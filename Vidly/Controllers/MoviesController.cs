using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies/Random
        public ActionResult Random()
        {

            var mvs = new List<Movie>
            {
                new Movie() {Id = 1, Name = "Dark Tower"},
                new Movie(){ Id = 2, Name = "Anaconda 2"},
                new Movie(){ Id = 3, Name = "Brothers"}
            };

            var viewModel = new RandomMovieViewModel
            {
              Movies = mvs
            };
            //return Content("my name is manbue");
           // return HttpNotFound();
           //return  new EmptyResult();
          // return RedirectToAction("Index", "Home", new {page = 1, sortBy = "name"});
          
          return View(viewModel);
        }

        public ActionResult Edit(int id)
        {

            return Content($"id: {id}");
        }

        public ActionResult Index(int? pageIndex, string sortBy)
        {
            if (!pageIndex.HasValue) pageIndex = 1;
            if(string.IsNullOrWhiteSpace(sortBy))sortBy = "Name";

            return Content(String.Format("pageIndex={0}&sortBy={1}", pageIndex, sortBy));
        }
        [Route("movies/released/{year}/{month}")]
        public ActionResult ByReleaseYear(int year,int month)
        {
            return Content(year + "/" + month);
        }
    }


}