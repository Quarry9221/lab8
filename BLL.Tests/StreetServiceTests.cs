using System;
using System.Collections.Generic;
using System.Linq;
using BLL.Services.Impl;
using BLL.Services.Interfaces;
using CCL.Security;
using CCL.Security.Identity;
using DAL.Entities;
using DAL.Repositories.Interfaces;
using DAL.UnitOfWork;
using Xunit;
using Moq;
using Microsoft.EntityFrameworkCore;
namespace Bll.Tests
{
    public class StreetServiceTests
    {
        [Fact]
        public void Ctor_InputNull_ThrowArgumentNullException()
        {
            // Arrange
            IUnitOfWork nullUnitOfWork = null;

            // Act
            // Assert
            Assert.Throws<ArgumentNullException>(() => new StreetService(nullUnitOfWork));
        }

        [Fact]
        public void GetStreets_UserIsAdmin_ThrowMethodException()
        {
            User user = new Admin(1, "test", 1);
            SecurityContext.SetUser(user);
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            IStreetService streetService = new StreetService(mockUnitOfWork.Object);

            Assert.Throws<MethodAccessException>(() => streetService.GetStreets(0));
        }

        [Fact]
        public void GetStreets_StreetFromDAL_CorrectMappingToStreetDTO()
        {
            User user = new Director(1, "test", 1);
            SecurityContext.SetUser(user);
            var streetService = GetStreetService();
            var actualStreetDto = streetService.GetStreets(0).First();
            
            Assert.True(
                actualStreetDto.StreetID == 1
                && actualStreetDto.Name == "testN"
            );
        }

        IStreetService GetStreetService()
        {
            var mockContext = new Mock<IUnitOfWork>();
            var excpectedStreet = new Street()
            {
                StreetID = 1,
                Name = "testN",
            };
            var mockDbSet = new Mock<IStreetRepository>();
            mockDbSet
                .Setup(z =>
                    z.Find(
                        It.IsAny<Func<Street, bool>>(),
                        It.IsAny<int>(),
                        It.IsAny<int>()))
                .Returns(
                    new List<Street>() {excpectedStreet});
            mockContext
                .Setup(context =>
                    context.Streets)
                .Returns(mockDbSet.Object);
            IStreetService streetService = new StreetService(mockContext.Object);
            return streetService;
        }
    }
}