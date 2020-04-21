using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MovieShop.Data;
using MovieShop.Entity;
using MovieShop.Services;
using System.Linq;

namespace UnitTests
{
    [TestClass]
    public class MovieServiceUnitTest
    {
        private MovieService _sut;
        private List<Movie> _fakeMovies;
        private readonly Mock<IMovieRepository> _mockMovieRepository;

        public MovieServiceUnitTest()
        {
            _mockMovieRepository = new Mock<IMovieRepository>();
            _sut = new MovieService(_mockMovieRepository.Object);
        }

        [TestInitialize]
        public void TestInitialize()
        {
            _fakeMovies = new List<Movie>
            {
                new Movie
                {
                    Id=1, Title="TestMethod1",Budget=20000
                },
                new Movie
                {
                    Id=2, Title="TestMethod2",Budget=35000
                },
                new Movie
                {
                    Id=3, Title="TestMethod3",Budget=40000
                }


            };
            _mockMovieRepository.Setup(m => m.GetTopGrossingMovies()).Returns(_fakeMovies);
            _mockMovieRepository.Setup(m => m.GetById(It.IsAny<int>())).Returns((int id) => _fakeMovies.FirstOrDefault(x => x.Id==id));
        }

        [TestMethod]
        public void Test_For_GetTopGrossingMovies_FromFakeData()
        {
            var topMovies = _sut.GetTopGrossingMovies();
            Assert.AreEqual(3, topMovies.Count());
            Assert.IsNotNull(topMovies);
            CollectionAssert.AllItemsAreInstancesOfType(topMovies.ToList(), typeof(Movie));
           

        }

        [TestMethod]
        public void Test_For_GetMovieDetails_FromFakeData()
        {
            //Assert,check movie name,id,type,is not null
            int id = 3;
            var movieDetail = _sut.GetMovieDetails(id);
            Assert.AreEqual("TestMethod3", movieDetail.Title);
            Assert.AreEqual(3, movieDetail.Id);
            Assert.IsInstanceOfType(movieDetail, typeof(Movie));
            Assert.IsNotNull(movieDetail);
        }
    }
}
