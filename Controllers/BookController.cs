using System;
using System.Collections.Generic;
using libraryapi.DB;
using Microsoft.AspNetCore.Mvc;

namespace libraryapi
{

  [ApiController]
  [Route("api/[controller]")]
  public class BooksController : ControllerBase
  {
    // SECTION Get requests
    [HttpGet]
    public ActionResult<IEnumerable<Book>> GetAllBooks()
    {
      try
      {
        return Ok(FakeDB.Books);
      }
      catch (Exception err)
      {
        return BadRequest(err.Message);
      }
    }
    [HttpGet("{bookId}")]
    public ActionResult<Book> GetBookById(string bookId)
    {
      try
      {
        Book foundBook = FakeDB.Books.Find(book => book.Id == bookId);
        if (foundBook == null) // NOTE Remember to null check when finding stuff
        {
          throw new Exception("Invalid ID");
        }
        return Ok(foundBook);
      }
      catch (System.Exception err)
      {
        return BadRequest(err.Message);
      }
    }
    //!SECTION End get requests
    //SECTION Post requests
    [HttpPost]
    public ActionResult<Book> CreateBook([FromBody] Book newBook)
    {
      try
      {
        FakeDB.Books.Add(newBook);
        return Created($"api/books/{newBook.Id}", newBook);
      }
      catch (System.Exception err)
      {
        return BadRequest(err.Message);
      }
    }
    //!SECTION End post requests
    //SECTION Put requests
    [HttpPut("{bookId}")]
    public ActionResult<Book> EditBook(string bookId, [FromBody] Book updatedBook)
    {
      try
      {
        Book bookToUpdate = FakeDB.Books.Find(book => book.Id == bookId);
        if (bookToUpdate == null)
        {
          throw new Exception("Invalid Book ID");
        }
        bookToUpdate.Title = updatedBook.Title == null ? bookToUpdate.Title : updatedBook.Title;
        bookToUpdate.Author = updatedBook.Author == null ? bookToUpdate.Author : updatedBook.Author;
        bookToUpdate.DaysChecked = updatedBook.DaysChecked;
        return Ok(bookToUpdate);
      }
      catch (System.Exception err)
      {
        return BadRequest(err.Message);
      }
    }
    //!SECTION End put requests
    //SECTION Delete requests
    [HttpDelete("{bookId}")]
    public ActionResult<Book> DeleteBook(string bookId)
    {
      try
      {
        Book bookToDelete = FakeDB.Books.Find(book => book.Id == bookId);
        if (bookToDelete == null)
        {
          throw new Exception("Invalid Book ID");
        }
        FakeDB.Books.Remove(bookToDelete);
        return Ok("Book deleted.");
      }
      catch (System.Exception err)
      {
        return BadRequest(err.Message);
      }
    }
    //!SECTION End delete requests

  } /* END OF CONTROLLER */
} 