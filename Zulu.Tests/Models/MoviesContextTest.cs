using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Zulu.Models;

namespace Zulu.Tests.Models
{
  [TestClass]
  public class MoviesContextTest
  {
    [TestMethod]
    public void CreatingAMovieStoresIt()
    {
      var mockDbSet = new Mock<IDbSet<Movie>>();
      var context = new MoviesDBContext(mockDbSet.Object);
      var movie = new Movie{Title = "The Movie"};

      context.CreateMovie(movie);

      mockDbSet.Verify(set => set.Add(movie), Times.Once());
    }





  }

//  public class FakeDbSet<T> : IDbSet<T> where T : class
//  {
//
//    public HashSet<T> _data;
//
//    public FakeDbSet()
//    {
//      _data = new HashSet<T>();
//    }
//
//    public IEnumerator<T> GetEnumerator()
//    {
//      return _data.GetEnumerator();
//    }
//
//    IEnumerator IEnumerable.GetEnumerator()
//    {
//      return GetEnumerator();
//    }
//
//    public Expression Expression { get; private set; }
//    public Type ElementType { get; private set; }
//    public IQueryProvider Provider { get; private set; }
//    public T Find(params object[] keyValues)
//    {
//      throw new NotImplementedException();//
//    }
//
//    public T Add(T entity)
//    {
//      _data.Add(entity);
//      return entity;
//    }
//
//    public T Remove(T entity)
//    {
//      _data.Remove(entity);
//      return entity;
//    }
//
//    public T Attach(T entity)
//    {
//      return Add(entity);
//    }
//
//    public T Create()
//    {
//      return Activator.CreateInstance<T>();
//    }
//
//    public TDerivedEntity Create<TDerivedEntity>() where TDerivedEntity : class, T
//    {
//      return Activator.CreateInstance<TDerivedEntity>();
//    }
//
//    public ObservableCollection<T> Local
//    {
//      get { return new ObservableCollection<T>(_data); }
//    }
//  }
}
