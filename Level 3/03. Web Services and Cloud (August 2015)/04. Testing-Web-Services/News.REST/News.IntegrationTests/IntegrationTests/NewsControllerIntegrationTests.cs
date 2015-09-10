namespace News.Tests.IntegrationTests
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Transactions;
    using System.Web.Http;
    using Data;
    using Data.Contracts;
    using Microsoft.Owin.Testing;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Models;
    using Owin;
    using Services;
    using EntityFramework.Extensions;

    [TestClass]
    public class NewsControllerIntegrationTests
    {
        private static TransactionScope tran;
        private TestServer httpTestServer;
        private HttpClient httpClient;

        [TestInitialize]
        public void TestInit()
        {
            // Start OWIN testing HTTP server with Web API support
            this.httpTestServer = TestServer.Create(appBuilder =>
            {
                var config = new HttpConfiguration();
                WebApiConfig.Register(config);

                var startup = new Startup();
                startup.Configuration(appBuilder);

                appBuilder.UseWebApi(config);
            });
            this.httpClient = this.httpTestServer.HttpClient;
        }

        [TestCleanup]
        public void TestCleanup()
        {
            this.httpTestServer.Dispose();
        }

        [TestMethod]
        public void ListNews_EmptyDb_ShouldReturn200Ok_EmptyNewsList()
        {
            // Arrange
            this.CleanDatabase();

            // Act
            var httpResponse = this.httpClient.GetAsync("/api/news").Result;
            var bugs = httpResponse.Content.ReadAsAsync<List<News>>().Result;

            // Assert
            Assert.AreEqual(HttpStatusCode.OK, httpResponse.StatusCode);
            Assert.AreEqual(httpResponse.Content.Headers.ContentType.MediaType, "application/json");
            Assert.AreEqual(0, bugs.Count);
        }

        [TestMethod]
        public void ListNews_NonEmptyDb_ShouldReturnNewsList()
        {
            // Arrange
            this.CleanDatabase();

            var dbContext = new NewsData(NewsContext.Create());
            var user = new ApplicationUser
            {
                UserName = "petar",
                Email = "petar@abv.bg"
            };

            dbContext.Users.Add(user);
            dbContext.SaveChanges();

            dbContext.News.Add(
                new News
                {
                    Title = "Title #1",
                    Content = "Another content.",
                    PublishDate = DateTime.Now,
                    AuthorId = user.Id,
                    Author = user
                });
            dbContext.SaveChanges();
            dbContext.News.Add(
                new News
                {
                    Title = "Title #2",
                    Content = "Test content.",
                    PublishDate = DateTime.Now,
                    AuthorId = user.Id,
                    Author = user
                });
            dbContext.SaveChanges();

            // Act
            var httpResponse = this.httpClient.GetAsync("/api/news").Result;
            var dbNews = httpResponse.Content.ReadAsAsync<List<News>>().Result;

            // Assert
            Assert.AreEqual(HttpStatusCode.OK, httpResponse.StatusCode);
            Assert.AreEqual(httpResponse.Content.Headers.ContentType.MediaType, "application/json");
            Assert.AreEqual(2, dbNews.Count);
            Assert.AreEqual("Title #2", dbNews[0].Title);
            Assert.AreEqual("Another content.", dbNews[1].Content);
        }

        [TestMethod]
        public void CreateNews_CorrectData_ShouldReturn_201Created()
        {
            // Arrange
            this.CleanDatabase();

            var dbContext = new NewsData(NewsContext.Create());
            var user = new ApplicationUser
            {
                UserName = "petar",
                Email = "petar@abv.bg"
            };

            dbContext.Users.Add(user);
            dbContext.SaveChanges();

            dbContext.News.Add(
                new News
                {
                    Title = "Title #1",
                    Content = "Another content.",
                    PublishDate = DateTime.Now,
                    AuthorId = user.Id,
                    Author = user
                });
            dbContext.SaveChanges();
            dbContext.News.Add(
                new News
                {
                    Title = "Title #2",
                    Content = "Test content.",
                    PublishDate = DateTime.Now,
                    AuthorId = user.Id,
                    Author = user
                });
            dbContext.SaveChanges();

            // Act
            var httpResponse = this.httpClient.GetAsync("/api/news").Result;
            var dbNews = httpResponse.Content.ReadAsAsync<List<News>>().Result;

            // Assert
            Assert.AreEqual(HttpStatusCode.OK, httpResponse.StatusCode);
            Assert.AreEqual(httpResponse.Content.Headers.ContentType.MediaType, "application/json");
            Assert.AreEqual(2, dbNews.Count);
            Assert.AreEqual("Title #2", dbNews[0].Title);
            Assert.AreEqual("Another content.", dbNews[1].Content);
        }

        private void CleanDatabase()
        {
            // Clean all data in all database tables
            var dbContext = new NewsContext();
            dbContext.News.Delete();
            dbContext.Users.Delete();
            dbContext.SaveChanges();
        }
    }
}