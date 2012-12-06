using System.Web.Mvc;
using Zulu.Models;

namespace Zulu.Controllers
{
    public class MoviesController : Controller
    {
      private MoviesDBContext moviesDBContext;

      public MoviesController()
      {
        moviesDBContext = new MoviesDBContext();
      }

      public MoviesController(MoviesDBContext context = null)
      {
        moviesDBContext = context ?? new MoviesDBContext();
      }

      [HttpPost]
      public ViewResult Create(Movie movie)
      {
        moviesDBContext.CreateMovie(movie);
        ViewBag.Message = "Thank you";
        return View();
      }

      public ViewResult Create()
      {
        ViewBag.Message = "Welcome to movie creator";
        return View();
      }

      public ViewResult Index()
      {
        ViewBag.Message = "Search Movies";
        return View();
      }

      public ViewResult Search(SearchRequest searchRequest)
      {
        ViewBag.Message = "Found";
        var results = moviesDBContext.Search(searchRequest.SearchTerm);
        return View(results);
      }
    }
}
