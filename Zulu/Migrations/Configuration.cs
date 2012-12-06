using Zulu.Models;

namespace Zulu.Migrations
{
  using System;
  using System.Data.Entity;
  using System.Data.Entity.Migrations;
  using System.Linq;

  internal sealed class Configuration : DbMigrationsConfiguration<Zulu.Models.MoviesDBContext>
  {
    public Configuration()
    {
      AutomaticMigrationsEnabled = false;
    }

    protected override void Seed(Zulu.Models.MoviesDBContext context)
    {
      context.Movies.AddOrUpdate(m => m.Title,
                                 new Movie {Title = "The Shining"},
                                 new Movie {Title = "Haloween 2"},
                                 new Movie {Title = "Moon"});
    }
  }
}