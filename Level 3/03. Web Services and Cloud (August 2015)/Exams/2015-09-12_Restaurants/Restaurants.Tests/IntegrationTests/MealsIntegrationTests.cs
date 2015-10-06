namespace Restaurants.Tests.IntegrationTests
{
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Threading;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Services;
    using System.Web.Http;
    using Data;
    using Microsoft.Owin.Testing;
    using Owin;
    using EntityFramework.Extensions;
    using Models;
    using Restauranteur.Models;
    using Services.Models.Meals;

    [TestClass]
    public class MealsIntegrationTests
    {
        private MealType[] mealTypes;
        private ApplicationUser[] users;
        private Town[] towns;
        private int restaurantId;
        private int mealId;

        private TestServer httpTestServer;
        private HttpClient httpClient;

        [TestInitialize]
        public void TestInit()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

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

            //Clean Users and News tables from Db
            CleanDatabase();
            this.SeedDatabase();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            this.httpTestServer.Dispose();
        }

        [TestMethod]
        public void EditMeal_ExistingId_RestaurantOwner_ValidAuthorizationToken_ShouldReturn_200OkAndEditedMeal()
        {
            var editModel = new EditMealBindingModel
            {
                Name = "New meal name",
                TypeId = this.mealTypes.Last().Id,
                Price = 100.50M
            };

            var mealContent = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("name", editModel.Name),
                new KeyValuePair<string, string>("typeId", editModel.TypeId.ToString()),
                new KeyValuePair<string, string>("price", editModel.Price.ToString())
            });

            var loginData = this.Login();
            this.httpClient.DefaultRequestHeaders.Add(
                   "Authorization", "Bearer " + loginData.Access_Token);
            var httpResponse = this.httpClient.PutAsync("api/meals/" + this.mealId, mealContent).Result;
            var responseContent = httpResponse.Content.ReadAsAsync<MealViewModel>().Result;

            Assert.AreEqual(HttpStatusCode.OK, httpResponse.StatusCode);
            Assert.AreEqual(editModel.Name, responseContent.Name);
            Assert.AreEqual(editModel.Price, responseContent.Price);
        }

        [TestMethod]
        public void EditMeal_ExistingId_InValidAuthorizationToken_ShouldReturn_401Unauthorized()
        {
            var editModel = new EditMealBindingModel
            {
                Name = "New meal name",
                TypeId = this.mealTypes.Last().Id,
                Price = 100.50M
            };

            var mealContent = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("name", editModel.Name),
                new KeyValuePair<string, string>("typeId", editModel.TypeId.ToString()),
                new KeyValuePair<string, string>("price", editModel.Price.ToString())
            });
            
            var httpResponse = this.httpClient.PutAsync("api/meals/" + this.mealId, mealContent).Result;
            
            Assert.AreEqual(HttpStatusCode.Unauthorized, httpResponse.StatusCode);
        }

        [TestMethod]
        public void EditMeal_ExistingId_ValidAuthorizationToken_EmptyModel_ShouldReturn_400BadRequest()
        {
            var loginData = this.Login();
            this.httpClient.DefaultRequestHeaders.Add(
                   "Authorization", "Bearer " + loginData.Access_Token);
            var httpResponse = this.httpClient.PutAsync("api/meals/" + this.mealId, null).Result;

            Assert.AreEqual(HttpStatusCode.BadRequest, httpResponse.StatusCode);
        }

        [TestMethod]
        public void EditMeal_NonExistingId_ValidAuthorizationToken_ShouldReturn_404NotFound()
        {
            var editModel = new EditMealBindingModel
            {
                Name = "New meal name",
                TypeId = this.mealTypes.Last().Id,
                Price = 100.50M
            };

            var mealContent = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("name", editModel.Name),
                new KeyValuePair<string, string>("typeId", editModel.TypeId.ToString()),
                new KeyValuePair<string, string>("price", editModel.Price.ToString())
            });
            var loginData = this.Login();
            this.httpClient.DefaultRequestHeaders.Add(
                   "Authorization", "Bearer " + loginData.Access_Token);
            var httpResponse = this.httpClient.PutAsync("api/meals/" + this.mealId + 1, mealContent).Result;

            Assert.AreEqual(HttpStatusCode.NotFound, httpResponse.StatusCode);
        }

        [TestMethod]
        public void EditMeal_ExistingId_InvalidModel_ValidAuthorizationToken_ShouldReturn_400BadRequest()
        {
            var editModel = new EditMealBindingModel
            {
                Name = "New meal name",
                TypeId = this.mealTypes.Last().Id + 100,
                Price = 100.50M
            };

            var mealContent = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("name", editModel.Name),
                new KeyValuePair<string, string>("typeId", editModel.TypeId.ToString()),
                new KeyValuePair<string, string>("price", editModel.Price.ToString())
            });

            var loginData = this.Login();
            this.httpClient.DefaultRequestHeaders.Add(
                   "Authorization", "Bearer " + loginData.Access_Token);
            var httpResponse = this.httpClient.PutAsync("api/meals/" + this.mealId, mealContent).Result;
            
            Assert.AreEqual(HttpStatusCode.BadRequest, httpResponse.StatusCode);
        }

        [TestMethod]
        public void EditMeal_ExistingId_NotRestaurantOwner_ShouldReturn_401Unauthorized()
        {
            var secondRegistrationContent = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("username", "stefan1"),
                new KeyValuePair<string, string>("password", "stefan1"),
                new KeyValuePair<string, string>("confirmPassword", "stefan1"),
                new KeyValuePair<string, string>("email", "stefan1@email.aa")
            });

            var registrationHttpResponse = this.httpClient.PostAsync("api/account/register", secondRegistrationContent).Result;
            Assert.AreEqual(HttpStatusCode.OK, registrationHttpResponse.StatusCode);

            var loginContent = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("username", "stefan1"),
                new KeyValuePair<string, string>("password", "stefan1"),
                new KeyValuePair<string, string>("grant_type", "password")
            });

            var loginHttpResponse = this.httpClient.PostAsync("api/account/login", loginContent).Result;
            var newLoginData = loginHttpResponse.Content.ReadAsAsync<LoginData>().Result;
            Assert.AreEqual(HttpStatusCode.OK, loginHttpResponse.StatusCode);

            var editModel = new EditMealBindingModel
            {
                Name = "New meal name",
                TypeId = this.mealTypes.Last().Id,
                Price = 100.50M
            };

            var mealContent = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("name", editModel.Name),
                new KeyValuePair<string, string>("typeId", editModel.TypeId.ToString()),
                new KeyValuePair<string, string>("price", editModel.Price.ToString())
            });

            var loginData = this.Login();
            this.httpClient.DefaultRequestHeaders.Add(
                   "Authorization", "Bearer " + newLoginData.Access_Token);
            var httpResponse = this.httpClient.PutAsync("api/meals/" + this.mealId, mealContent).Result;

            Assert.AreEqual(HttpStatusCode.Unauthorized, httpResponse.StatusCode);
        }

        private static void CleanDatabase()
        {
            // Clean all data in all database tables
            using (var dbContext = new RestaurantsContext())
            {
                dbContext.Meals.Delete();
                dbContext.Restaurants.Delete();
                dbContext.Users.Delete();
                dbContext.MealTypes.Delete();
                dbContext.Towns.Delete();
                dbContext.SaveChanges();
            }
        }

        private LoginData Login()
        {
            var loginContent = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("username", "stefan"),
                new KeyValuePair<string, string>("password", "stefan"),
                new KeyValuePair<string, string>("grant_type", "password")
            });

            var httpResponse = this.httpClient.PostAsync("api/account/login", loginContent).Result;

            if (!httpResponse.IsSuccessStatusCode)
            {
                // Nothing to return, throw a proper exception + message
                throw new HttpRequestException(
                    httpResponse.Content.ReadAsStringAsync().Result);
            }

            return httpResponse.Content.ReadAsAsync<LoginData>().Result;
        }

        private void Register()
        {
            var registerContent = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("username", "stefan"),
                new KeyValuePair<string, string>("password", "stefan"),
                new KeyValuePair<string, string>("confirmPassword", "stefan"),
                new KeyValuePair<string, string>("email", "stefan@email.aa")
            });

            var httpResponse = this.httpClient.PostAsync("api/account/register", registerContent).Result;

            if (!httpResponse.IsSuccessStatusCode)
            {
                // Nothing to return, throw a proper exception + message
                throw new HttpRequestException(
                    httpResponse.Content.ReadAsStringAsync().Result);
            }
        }

        private void SeedDatabase()
        {
            this.Register();
            this.SeedMealTypes();
            this.SeedTowns();
            var loginData = this.Login();
            this.SeedRestaurants(loginData);
            this.SeedMeal(loginData);

            //var newsContent = new FormUrlEncodedContent(new[]
            //{
            //    new KeyValuePair<string, string>("title", news.Title),
            //    new KeyValuePair<string, string>("content", news.Content),
            //    new KeyValuePair<string, string>("publishDate", news.PublishDate.ToString())
            //});

            //// Act
            //this.httpClient.DefaultRequestHeaders.Add(
            //       "Authorization", "Bearer " + loginData.Access_Token);
            //var httpResponse = this.httpClient.PostAsync("api/news", newsContent).Result;
            //this.httpClient.DefaultRequestHeaders.Remove("Authorization");

            //if (!httpResponse.IsSuccessStatusCode)
            //{
            //    // Nothing to return, throw a proper exception + message
            //    throw new HttpRequestException(
            //        httpResponse.Content.ReadAsStringAsync().Result);
            //}

            //var dbNews = httpResponse.Content.ReadAsAsync<News>().Result;

            //return dbNews.Id;
        }
        
        private void SeedMeal(LoginData loginData)
        {
            var mealContent = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("name", "Musaka"),
                new KeyValuePair<string, string>("restaurantId", this.restaurantId.ToString()),
                new KeyValuePair<string, string>("typeId", this.mealTypes.FirstOrDefault().Id.ToString()),
                new KeyValuePair<string, string>("price", "4.5")
            });

            
            this.httpClient.DefaultRequestHeaders.Add(
                   "Authorization", "Bearer " + loginData.Access_Token);
            var httpResponse = this.httpClient.PostAsync("api/meals", mealContent).Result;
            this.httpClient.DefaultRequestHeaders.Remove("Authorization");

            this.mealId = httpResponse.Content.ReadAsAsync<MealData>().Result.Id;
        }

        private void SeedRestaurants(LoginData loginData)
        {
            var restaurantContent = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("name", "Krachmata na kaka Ginka"),
                new KeyValuePair<string, string>("townId", this.towns.FirstOrDefault().Id.ToString())
            });

            // Act
            this.httpClient.DefaultRequestHeaders.Add(
                   "Authorization", "Bearer " + loginData.Access_Token);
            var httpResponse = this.httpClient.PostAsync("api/restaurants", restaurantContent).Result;
            this.httpClient.DefaultRequestHeaders.Remove("Authorization");

            this.restaurantId = httpResponse.Content.ReadAsAsync<RestaurantData>().Result.Id;
        }

        private void SeedMealTypes()
        {
            using (var context = new RestaurantsContext())
            {
                this.mealTypes = new[]
                {
                    new MealType {Name = "Salad", Order = 10},
                    new MealType {Name = "Soup", Order = 20},
                    new MealType {Name = "Main", Order = 30},
                    new MealType {Name = "Dessert", Order = 40}
                };

                foreach (var mealType in mealTypes)
                {
                    context.MealTypes.Add(mealType);
                }

                context.SaveChanges();
            }
        }

        private void SeedTowns()
        {
            using (var context = new RestaurantsContext())
            {
                this.towns = new[]
                {
                    new Town {Name = "Sofia"},
                    new Town {Name = "Varna"},
                    new Town {Name = "Bourgas"},
                };

                foreach (var town in this.towns)
                {
                    context.Towns.Add(town);
                }

                context.SaveChanges();
            }
        }
    }
}