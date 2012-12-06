using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Zulu.Models
{
  public class MoviesDBContext : DbContext
  {
    public IDbSet<Movie> Movies { get; set; }

    public MoviesDBContext()
    {
      
    }

    public MoviesDBContext(IDbSet<Movie> dbSet)
    {
      Movies = dbSet;
    }

    public virtual Movie CreateMovie(Movie movie)
    {
      var added = Movies.Add(movie);
      SaveChanges();
      return added;
    }

    public virtual List<Movie> Search(string searchTerm, int numberOfRows=10)
    {
      return Movies.Where(movie => movie.Title.Contains(searchTerm)).Take(numberOfRows).ToList();
    }
  }
}