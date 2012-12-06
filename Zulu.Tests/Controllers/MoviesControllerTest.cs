using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Zulu.Controllers;
using Zulu.Models;

namespace Zulu.Tests.Controllers
{
  [TestClass]
  public class MoviesControllerTest
  {
    [TestMethod]
    public void CanCreateAMovie()
    {
      var mockContext = new Mock<MoviesDBContext>();
      var movie = new Movie {Title = "The Shining"};
      mockContext.Setup(context => context.CreateMovie(movie));
      var movieController = new MoviesController(mockContext.Object);

      movieController.Create(movie);

      mockContext.Verify(context => context.CreateMovie(movie), Times.Once());
    }

    [TestMethod]
    public void VisitingCreatePageShowsPage()
    {
      var mockContext = new Mock<MoviesDBContext>();
      var movieController = new MoviesController(mockContext.Object);

      var result = movieController.Create();

      Assert.IsInstanceOfType(result, typeof(ViewResult));
      Assert.AreEqual("Welcome to movie creator", movieController.ViewBag.Message);
    }

    [TestMethod]
    public void CreatingAMovieSaysThanks()
    {
      var mockContext = new Mock<MoviesDBContext>();
      var movie = new Movie { Title = "The Shining" };
      mockContext.Setup(context => context.CreateMovie(movie));
      var movieController = new MoviesController(mockContext.Object);

      var result = movieController.Create(movie);

      Assert.IsInstanceOfType(result, typeof(ViewResult));
      Assert.AreEqual("Thank you", movieController.ViewBag.Message);
    }

    [TestMethod]
    public void VisitingSearchPageShowsSearchForm()
    {
      var mockContext = new Mock<MoviesDBContext>();
      var moviesController = new MoviesController(mockContext.Object);

      var result = moviesController.Index();

      Assert.IsInstanceOfType(result, typeof(ViewResult));
      Assert.AreEqual("Search Movies", moviesController.ViewBag.Message);
    }

    [TestMethod]
    public void CanSearchByTitle()
    {
      var testMovie = new Movie {Title = "test movie"};
      var mockContext = new Mock<MoviesDBContext>();
      mockContext.Setup(context => context.Search(testMovie.Title,10)).Returns(new List<Movie> {testMovie});
      var moviesController = new MoviesController(mockContext.Object);

      var result =  moviesController.Search(new SearchRequest{SearchTerm = testMovie.Title, NumRows = 10});
      var movies = (List<Movie>) result.Model;

      Assert.AreEqual("Found", moviesController.ViewBag.Message);
      Assert.AreEqual(1, movies.Count);
      Assert.AreEqual(testMovie.Title, movies[0].Title);
    }

    
  }
}
