using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    public class MoviesController : ApiController
    {
        private readonly VidlyDbContext _context;

        public MoviesController()
        {
            _context=new VidlyDbContext();
        }
        //api/movies
        [HttpGet]
        public IHttpActionResult GetAllMovies()
        {
            if (!ModelState.IsValid)
            {
                return NotFound();
            }

            var movies = _context.Movies.ToList().Select(Mapper.Map<Movie, MovieDto>);
            return Ok(movies);
        }
        //api/movies/1
        [HttpGet]
        public IHttpActionResult GetMovie(int id)
        {
            if (!ModelState.IsValid)
            {
                return NotFound();
            }

            var movie = _context.Movies.SingleOrDefault(m=>m.Id==id);
            if (movie==null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<Movie, MovieDto>(movie));
        }

        //api/movies/1
        [HttpPut]
        public IHttpActionResult Edit(int id, MovieDto movieDto)
        {
            if (!ModelState.IsValid) return BadRequest();
            var movieInDb = _context.Movies.SingleOrDefault(s => s.Id == id);
            if (movieInDb == null) return NotFound();
            Mapper.Map(movieDto,movieInDb ); // updating line useing map function instead of generic one
            _context.SaveChanges();

            return Ok();
       
        }

        //api/movies
        [HttpPost]
        public IHttpActionResult CreateMovie(MovieDto movieDto)
        {
            if (!ModelState.IsValid) return BadRequest();

            var movie = Mapper.Map<MovieDto,Movie>(movieDto);
            movie.DateAdded=DateTime.Now;
            _context.Movies.Add(movie);
            _context.SaveChanges();
            movieDto.Id = movie.Id;

            return Created(new Uri(Request.RequestUri + "/" + movieDto.Id),movieDto);
        }

        //api/movies/1
        [HttpDelete]
        public IHttpActionResult DeleteMovie(int id)
        {
            if (!ModelState.IsValid) return BadRequest();
            var movieInDb = _context.Movies.SingleOrDefault(s => s.Id == id);
            if (movieInDb == null) return NotFound();
            _context.Movies.Remove(movieInDb);
            _context.SaveChanges();

            return Ok();

        }
    }
}
