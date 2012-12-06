using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Zulu.Controllers;
using Zulu.Models;

namespace Zulu.Tests.Integration.Models
{
  [TestClass]
  public class MoviesContextTest
  {
    private MoviesDBContext moviesDBContext = new MoviesDBContext();

    [TestInitialize]
    public void Setup()
    {
      moviesDBContext = new MoviesDBContext();
    }

    [TestCleanup]
    public void TearDown()
    {

      moviesDBContext.Database.Delete();
    }

    [TestMethod]
    public void CreatingAMovieStoresItInTheDb()
    {
      var movie = new Movie { Title = "The Movie" };

      var savedMovie = moviesDBContext.CreateMovie(movie);

      Assert.AreNotEqual(0, savedMovie.Id);
    }

    [TestMethod]
    public void SearchReturnsCorrectResults()
    {
      var movie = new Movie { Title = "Movie A" };
      var id = moviesDBContext.CreateMovie(movie).Id;

      var results = moviesDBContext.Search(movie.Title);

      Assert.AreEqual(1, results.Count);
      Assert.AreEqual(id, results[0].Id);
    }

    [TestMethod]
    public void SearchIsCaseInsensitive()
    {
      var movie = new Movie { Title = "The Movie" };
      var context = new MoviesDBContext();
      context.CreateMovie(movie);

      var results = context.Search("tHe mOVIE");

      Assert.AreEqual(1, results.Count);
      Assert.AreEqual(movie.Title, results[0].Title);
    }

    [TestMethod]
    public void SearchReturnsPartialMatches()
    {
      var movie = new Movie { Title = "The Other Movie" };
      var context = new MoviesDBContext();
      context.CreateMovie(movie);

      var results = context.Search("Other");

      Assert.AreEqual(1, results.Count);
      Assert.AreEqual(movie.Title, results[0].Title);
    }

    [TestMethod]
    public void NumberOfSearchResultsLimited()
    {
      var context = new MoviesDBContext();
      Enumerable.Range(1, 10).ToList().ForEach(x => context.CreateMovie(new Movie { Title = "Movie " + x }));

      var result = context.Search("Movie",3);     

      Assert.AreEqual(3, result.Count);
    }
  }
}
