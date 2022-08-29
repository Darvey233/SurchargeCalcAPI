using GoFreightAPI.Controllers;
using GoFreightAPI.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Security.Principal;
using System.Web.Http;
using System.Web.Http.Results;

namespace GoFreightTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Test1()
        {
            // Arrange
            String CustomerID = "asd";

            Assert.AreNotEqual(5, CustomerID);
        }

        [TestMethod]
        public void Test2()
        {
            var map = new Dictionary<long, double>
            {
                { 1, 5 },
                { 2, 10 },
                { 3, 7 },
                { 4, 4.25 }
            };

            double Subtotal = 100;

            double SurchargeAmount = map[1] * Subtotal / 100;
            double Total = Subtotal + SurchargeAmount;

            Assert.AreEqual(105, Total);
            //Assert.ThrowsExceptionAsync<KeyNotFoundException>();
            //Assert.Fail("The expected exception was not thrown.");
        }


        //[TestMethod]
        //public void PostMethodSetsLocationHeader()
        //{
        //    // Arrange
        //    var mockRepository = new Mock<IGoFreightContext>();
        //    var controller = new GoFreightController(mockRepository.Object);

        //    // Act
        //    IHttpActionResult actionResult = (IHttpActionResult)controller.PostItem(new GoFreightItem { CustomerID = 10});
        //    var createdResult = actionResult as CreatedAtRouteNegotiatedContentResult<GoFreightItem>;

        //    // Assert
        //    Assert.IsNotNull(createdResult);
        //    Assert.AreEqual("DefaultApi", createdResult.RouteName);
        //    Assert.AreEqual(10, createdResult.RouteValues["id"]);
        //}

    }
}