using System;
using System.Collections.Generic;
using libraryapi.DB;
using Microsoft.AspNetCore.Mvc;

namespace libraryapi
{

  [ApiController]
  [Route("api/[controller]")]
  public class MoviesController : ControllerBase
  {
    // SECTION Get requests
    [HttpGet]
    public ActionResult<IEnumerable<Movie>> GetAllMovies()
    {
      try
      {
        return Ok(FakeDB.Movies);
      }
      catch (Exception err)
      {
        return BadRequest(err.Message);
      }
    }
    [HttpGet("{movieId}")]
    public ActionResult<Movie> GetMovieById(string movieId)
    {
      try
      {
        Movie foundMovie = FakeDB.Movies.Find(movie => movie.Id == movieId);
        if (foundMovie == null) // NOTE Remember to null check when finding stuff
        {
          throw new Exception("Invalid ID");
        }
        return Ok(foundMovie);
      }
      catch (System.Exception err)
      {
        return BadRequest(err.Message);
      }
    }
    //!SECTION End get requests
    //SECTION Post requests
    [HttpPost]
    public ActionResult<Movie> CreateMovie([FromBody] Movie newMovie)
    {
      try
      {
        FakeDB.Movies.Add(newMovie);
        return Created($"api/movies/{newMovie.Id}", newMovie);
      }
      catch (System.Exception err)
      {
        return BadRequest(err.Message);
      }
    }
    //!SECTION End post requests
    //SECTION Put requests
    [HttpPut("{movieId}")]
    public ActionResult<Movie> EditMovie(string movieId, [FromBody] Movie updatedMovie)
    {
      try
      {
        Movie movieToUpdate = FakeDB.Movies.Find(movie => movie.Id == movieId);
        if (movieToUpdate == null)
        {
          throw new Exception("Invalid Movie ID");
        }
        movieToUpdate.Title = updatedMovie.Title == null ? movieToUpdate.Title : updatedMovie.Title;
        movieToUpdate.Description = updatedMovie.Description == null ? movieToUpdate.Description : updatedMovie.Description;
        movieToUpdate.Medium = updatedMovie.Medium == null ? movieToUpdate.Medium : updatedMovie.Medium;
        movieToUpdate.DaysBorrowed = updatedMovie.DaysBorrowed;
        return Ok(movieToUpdate);
      }
      catch (System.Exception err)
      {
        return BadRequest(err.Message);
      }
    }
    //!SECTION End put requests
    //SECTION Delete requests
    [HttpDelete("{movieId}")]
    public ActionResult<Movie> DeleteMovie(string movieId)
    {
      try
      {
        Movie movieToDelete = FakeDB.Movies.Find(movie => movie.Id == movieId);
        if (movieToDelete == null)
        {
          throw new Exception("Invalid Movie ID");
        }
        FakeDB.Movies.Remove(movieToDelete);
        return Ok("Movie deleted.");
      }
      catch (System.Exception err)
      {
        return BadRequest(err.Message);
      }
    }
    //!SECTION End delete requests

  } /* END OF CONTROLLER */
} 