using System;
using System.Collections.Generic;
using libraryapi.DB;
using Microsoft.AspNetCore.Mvc;

namespace libraryapi
{

  [ApiController]
  [Route("api/[controller]")]
  public class AuthorsController : ControllerBase
  {
    // SECTION Get requests
    [HttpGet]
    public ActionResult<IEnumerable<Author>> GetAllAuthors()
    {
      try
      {
        return Ok(FakeDB.Authors);
      }
      catch (Exception err)
      {
        return BadRequest(err.Message);
      }
    }
    [HttpGet("{authorId}")]
    public ActionResult<Author> GetAuthorById(string authorId)
    {
      try
      {
        Author foundAuthor = FakeDB.Authors.Find(author => author.Id == authorId);
        if (foundAuthor == null) // NOTE Remember to null check when finding stuff
        {
          throw new Exception("Invalid ID");
        }
        return Ok(foundAuthor);
      }
      catch (System.Exception err)
      {
        return BadRequest(err.Message);
      }
    }
    [HttpGet("{authorId}/books")]
    public ActionResult<Book> GetBooksByAuthorId(string authorId)
    {
      try
      {
        List<Book> foundBooks = FakeDB.Books.FindAll(book => book.Author == authorId);
        if (foundBooks.Count == 0)
        {
          return Ok("No books written by that Author");
        }
        return Ok(foundBooks);
      }
      catch (System.Exception)
      {

        throw;
      }
    }
    //!SECTION End get requests
    //SECTION Post requests
    [HttpPost]
    public ActionResult<Author> CreateAuthor([FromBody] Author newAuthor)
    {
      try
      {
        FakeDB.Authors.Add(newAuthor);
        return Created($"api/authors/{newAuthor.Id}", newAuthor);
      }
      catch (System.Exception err)
      {
        return BadRequest(err.Message);
      }
    }
    //!SECTION End post requests
    //SECTION Put requests
    [HttpPut("{authorId}")]
    public ActionResult<Author> EditAuthor(string authorId, [FromBody] Author updatedAuthor)
    {
      try
      {
        Author authorToUpdate = FakeDB.Authors.Find(author => author.Id == authorId);
        if (authorToUpdate == null)
        {
          throw new Exception("Invalid Author ID");
        }
        authorToUpdate.Name = updatedAuthor.Name == null ? authorToUpdate.Name : updatedAuthor.Name;
        return Ok(authorToUpdate);
      }
      catch (System.Exception err)
      {
        return BadRequest(err.Message);
      }
    }
    //!SECTION End put requests
    //SECTION Delete requests
    [HttpDelete("{authorId}")]
    public ActionResult<Author> DeleteAuthor(string authorId)
    {
      try
      {
        Author authorToDelete = FakeDB.Authors.Find(author => author.Id == authorId);
        if (authorToDelete == null)
        {
          throw new Exception("Invalid Author ID");
        }
        FakeDB.Authors.Remove(authorToDelete);
        return Ok("Author deleted.");
      }
      catch (System.Exception err)
      {
        return BadRequest(err.Message);
      }
    }
    //!SECTION End delete requests

  } /* END OF CONTROLLER */
} 