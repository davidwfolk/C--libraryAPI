using System.Collections.Generic;

namespace libraryapi.DB
{
  public static class FakeDB
  {
    public static List<Book> Books = new List<Book>()
    {
      new Book("Financial Peace", "Dave Ramsey", 3),
      new Book("The Bible", "God", 160),
      new Book("How To Win Friends & Influence People", "Dale Carnagie", 48)
    };
  }
} 