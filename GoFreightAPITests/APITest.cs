//namespace GoFreightAPI.Models;
//using static System.Net.Mime.MediaTypeNames;
//using Moq;
//using Xunit;
//using Microsoft.AspNetCore.Mvc;
//using FluentAssertions;
//using GoFreightAPI.Controllers;
//using global::GoFreightAPITests.MockData;

//    public class APITest
//    {
//        [Fact]
//        public async Task SaveAsync_ShouldCall_IGoFreightContext_SaveAsync_AtleastOnce()

//        {
//            var datatest = new Mock<GoFreightContext>();
//            var newData = MockData.NewData();
//            var sut = new GoFreightController(datatest.Object);

//            var result = await sut.SaveAsync(newData);

//            datatest.Verify(_ => _.SaveAsync(newData),Times.Exactly(1));
//        }
//    }