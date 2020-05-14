using System;
using System.ComponentModel.DataAnnotations;

namespace libraryapi
{
  public class Book
  {
    [Required]
    [MinLength(5)]
    public string Title { get; set; }
    [Required]
    [MaxLength(100)]
    public string Description { get; set; }
    [Required]
    [Range(1, 30)]
    public int DaysBorrowed { get; set; }
    public string Id { get; private set; }

    public Book()
    {
      Id = Guid.NewGuid().ToString();

    }
    public Book(string title, string description, int daysBorrowed)
    {
      Title = title;
      Description = description;
      DaysBorrowed = daysBorrowed;
      Id = Guid.NewGuid().ToString();
    }
  }
} 