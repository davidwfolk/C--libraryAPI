using System;
using System.ComponentModel.DataAnnotations;

namespace libraryapi
{
  public class Movie
  {
    [Required]
    [MinLength(5)]
    public string Title { get; set; }
    [Required]
    [MaxLength(100)]
    public string Description { get; set; }
    [Required]
    [MaxLength(10)]
    public string Medium { get; set; }
    [Required]
    [Range(1, 7)]
    public int DaysBorrowed { get; set; }
    public string Id { get; private set; }

    public Movie()
    {
      Id = Guid.NewGuid().ToString();
    }
    public Movie(string title, string description, string medium, int daysBorrowed)
    {
      Title = title;
      Description = description;
      DaysBorrowed = daysBorrowed;
      Medium = medium;
      Id = Guid.NewGuid().ToString();
    }
  }
} 