namespace Restaurants.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Moq;
    using Data.Repositories;
    using Models;

    public class MockContainer
    {
        public int InitialRestaurantsCount { get; private set; }

        public Mock<IRepository<Restaurant>> RestaurantsRepositoryMock { get; set; }

        public Mock<IRepository<Town>> TownsRepositoryMock { get; set; }
        
        public Mock<IRepository<ApplicationUser>> UserRepositoryMock { get; set; }

        public IList<Restaurant> RestaurantFakeRepo { get; set; }

        public void PrepareMocks()
        {
            this.SetupFakeUsers();
            this.SetupFakeTowns();
            this.SetupFakeRestaurants();
            this.InitialRestaurantsCount = this.RestaurantFakeRepo.Count;
        }

        private void SetupFakeRestaurants()
        {
            this.RestaurantFakeRepo = new List<Restaurant>
            {
                new Restaurant
                {
                    Id = 1,
                    Name = "Five star restaurant",
                    TownId = this.TownsRepositoryMock.Object.All().First().Id,
                    Town = this.TownsRepositoryMock.Object.All().First(),
                    OwnerId = this.UserRepositoryMock.Object.All().First().Id,
                    Owner = this.UserRepositoryMock.Object.All().First(),
                    Ratings = new List<Rating>(new Rating[]
                    {
                        new Rating {Stars = 1},
                        new Rating {Stars = 2},
                        new Rating {Stars = 3},
                    })
                },
                new Restaurant
                {
                    Id = 1,
                    Name = "Two star restaurant",
                    TownId = this.TownsRepositoryMock.Object.All().First().Id,
                    Town = this.TownsRepositoryMock.Object.All().First(),
                    OwnerId = this.UserRepositoryMock.Object.All().First().Id,
                    Owner = this.UserRepositoryMock.Object.All().First(),
                    Ratings = new List<Rating>(new Rating[]
                    {
                        new Rating {Stars = 5}, 
                        new Rating {Stars = 6}, 
                        new Rating {Stars = 7}, 
                    })
                }
            };

            this.RestaurantsRepositoryMock = new Mock<IRepository<Restaurant>>();
            this.RestaurantsRepositoryMock.Setup(r => r.All())
                .Returns(this.RestaurantFakeRepo.AsQueryable());

            this.RestaurantsRepositoryMock.Setup(r => r.Find(It.IsAny<int>()))
                .Returns((int id) =>
                {
                    var ad = this.RestaurantFakeRepo.FirstOrDefault(a => a.Id == id);
                    return ad;
                });

            this.RestaurantsRepositoryMock
                .Setup(r => r.Add(It.IsAny<Restaurant>()))
                .Callback((Restaurant restaurant) =>
                {
                    restaurant.Owner = this.UserRepositoryMock.Object.All().FirstOrDefault();
                    this.RestaurantFakeRepo.Add(restaurant);
                });
        }

        private void SetupFakeUsers()
        {
            var fakeUsers = new List<ApplicationUser>
            {
                new ApplicationUser() {UserName = "vanko1", Email = "vanko1@abv.bg"},
                new ApplicationUser() {UserName = "ivan", Email = "ivan@abv.bg"},
                new ApplicationUser() {UserName = "stefan", Email = "stefan@abv.bg"},
                new ApplicationUser() {UserName = "petar", Email = "petar@abv.bg"}
            };

            this.UserRepositoryMock = new Mock<IRepository<ApplicationUser>>();

            this.UserRepositoryMock
                .Setup(r => r.All())
                .Returns(fakeUsers.AsQueryable());
        }

        private void SetupFakeTowns()
        {
            var fakeTowns = new List<Town>
            {
                new Town {Id = 1, Name = "Sofia"},
                new Town {Id = 2, Name = "Varna"},
                new Town {Id = 3, Name = "Bourgas"}
            };

            this.TownsRepositoryMock = new Mock<IRepository<Town>>();

            this.TownsRepositoryMock
                .Setup(r => r.All())
                .Returns(fakeTowns.AsQueryable());
        }
    }
}
