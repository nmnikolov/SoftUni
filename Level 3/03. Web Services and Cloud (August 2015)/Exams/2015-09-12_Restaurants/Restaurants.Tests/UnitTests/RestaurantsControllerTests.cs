namespace Restaurants.Tests.UnitTests
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Threading;
    using System.Web.Http;
    using Data;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using Services.Controllers;
    using Services.Infrastructure;
    using Services.Models.Restaurants;

    [TestClass]
    public class RestaurantsControllerTests
    {
        private MockContainer mocks;

        private Mock<IRestaurantsData> mockContext;

        private Mock<IUserProvider> mockUserProvider;

        private RestaurantsController controller;

        [TestInitialize]
        public void InitTest()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            this.mocks = new MockContainer();
            this.mocks.PrepareMocks();
            this.mockContext = new Mock<IRestaurantsData>();
            this.PrepareMockContext();
            this.mockUserProvider = new Mock<IUserProvider>();
            this.PrepareMockUserProvider();

            this.controller = new RestaurantsController(this.mockContext.Object, this.mockUserProvider.Object);
            this.SetupController(this.controller);
        }

        [TestMethod]
        public void GetRestaurantsByTown_ValidTownId_NonEmptyDb_ShouldReturn_200Ok()
        {
            var existingTownId = this.mocks.TownsRepositoryMock.Object.All().LastOrDefault().Id;
            var fakeRestaurants = this.mocks.RestaurantFakeRepo
                .Where(r => r.TownId == existingTownId)
                .ToList();

            var model = new RestaurantsByTownBindingModel
            {
                TownId = existingTownId
            };

            var response = this.controller.GetRestaurantsByTown(model)
                .ExecuteAsync(CancellationToken.None).Result;

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

            var newsResponse = response.Content.ReadAsAsync<IEnumerable<RestaurantsByTownViewModel>>()
                .Result.Select(a => a.Id)
                .ToList();

            var orderedFakeNews = fakeRestaurants
                .OrderByDescending(r => r.Ratings.Average(rr => rr.Stars))
                .ThenBy(r => r.Name)
                .Select(r => r.Id)
                .ToList();

            this.controller.GetRestaurantsByTown(model);

            CollectionAssert.AreEqual(orderedFakeNews, newsResponse);
        }

        [TestMethod]
        public void GetRestaurantsByTown_NonExistingTown_NonEmptyDb_ShouldReturn_200Ok_EmptyColletion()
        {
            var invalidTownId = -1;

            var model = new RestaurantsByTownBindingModel
            {
                TownId = invalidTownId
            };

            var response = this.controller.GetRestaurantsByTown(model)
                .ExecuteAsync(CancellationToken.None).Result;

            var newsResponse = response.Content.ReadAsAsync<IEnumerable<RestaurantsByTownViewModel>>()
                .Result.Select(a => a.Id)
                .ToList();

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.AreEqual(0, newsResponse.Count);
        }

        [TestMethod]
        public void GetRestaurantsByTown_EmptyModel_NonEmptyDb_ShouldReturn_400BadRequest()
        {
            var response = this.controller.GetRestaurantsByTown(null)
                .ExecuteAsync(CancellationToken.None).Result;
            
            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [TestMethod]
        public void GetRestaurantsByTown_InvalidModelState_NonEmptyDb_ShouldReturn_400BadRequest()
        {
            var existingTownId = this.mocks.TownsRepositoryMock.Object.All().LastOrDefault().Id;

            var model = new RestaurantsByTownBindingModel
            {
                TownId = existingTownId
            };

            this.controller.ModelState.AddModelError("townId", "missing");

            var response = this.controller.GetRestaurantsByTown(model)
                .ExecuteAsync(CancellationToken.None).Result;

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }

        private void PrepareMockContext()
        {
            this.mockContext.Setup(c => c.Restaurants)
                .Returns(this.mocks.RestaurantsRepositoryMock.Object);
            this.mockContext.Setup(c => c.Users)
                .Returns(this.mocks.UserRepositoryMock.Object);
            this.mockContext.Setup(c => c.Towns)
                .Returns(this.mocks.TownsRepositoryMock.Object);
            this.mockContext.Setup(c => c.Users.Find(It.IsAny<string>()))
                .Returns(this.mocks.UserRepositoryMock.Object.All().FirstOrDefault());
        }

        private void PrepareMockUserProvider()
        {
            this.mockUserProvider.SetupGet(ip => ip.IsAuthenticated)
                .Returns(true);
            this.mockUserProvider.Setup(ip => ip.GetUserId())
                .Returns(this.mocks.UserRepositoryMock.Object.All().First().Id);
        }

        private void SetupController(RestaurantsController newsController)
        {
            string serverUrl = "http://sample-url.com";

            newsController.Request = new HttpRequestMessage
            {
                RequestUri = new Uri(serverUrl)
            };

            newsController.Configuration = new HttpConfiguration();
            newsController.Configuration.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { controller = RouteParameter.Optional, id = RouteParameter.Optional });
        }
    }
}