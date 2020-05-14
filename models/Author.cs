using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace libraryapi
{
  public class Author
  {
    [Required]
    [MinLength(5)]
    public string Name { get; set; }
    public static List<Book> Books = new List<Book>();
    public string Id { get; private set; }

    public Author()
    {
      Id = Guid.NewGuid().ToString();
    }
    public Author(string name)
    {
      Name = name;
      Books = new List<Book>();
      Id = Guid.NewGuid().ToString();
    }
  }
} 