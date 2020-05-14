using System.Collections.Generic;

namespace libraryapi.DB
{
  public static class FakeDB
  {
    public static List<Author> Authors = new List<Author>()
    {
      new Author("Dave Ramsey"),
      new Author("God"),
      new Author("Dale Carnagie"),
    };
    public static List<Book> Books = new List<Book>()
    {
      new Book("Financial Peace", Authors[0].Name, 3),
      new Book("The Bible", Authors[1].Name, 160),
      new Book("How To Win Friends & Influence People", Authors[2].Name, 48)
    };
    public static List<Movie> Movies = new List<Movie>()
    {
      new Movie("7 Days in Utopia", "Young PGA Tour pro loses temper, walks of the course, and on his way home crashed in the small Town of Utopia.  As fate would have it, there's an old golf pro who lives there and is open to teaching the young buck a lesson or two, if he listens...", "Digital Rental", 1),
      new Movie("Legend of Bagger Vance", "On the brink of the Great Depression, a great golf spectacle is arranges in Savannah Georgia.  The local legend, lost from his time fighting in WW1, joins Bobby Jones & Walter Hagen in a 72 hole match.  In need of a caddy, the local hero hires a nomad named Bagger Vance", "DVD", 4)
    };
  }
} 