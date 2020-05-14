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
    public string Author { get; set; }
    [Required]
    [Range(1, 30)]
    public int DaysChecked { get; set; }
    public string Id { get; private set; }

    public Book()
    {
      Id = Guid.NewGuid().ToString();

    }
    public Book(string title, string author, int daysChecked)
    {
      Title = title;
      Author = author;
      DaysChecked = daysChecked;
      Id = Guid.NewGuid().ToString();
    }
  }
} 