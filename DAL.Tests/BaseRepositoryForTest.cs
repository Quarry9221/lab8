using System;
using DAL.EF;
using Microsoft.EntityFrameworkCore;
using Xunit;
using DAL.Entities;
using DAL.Repositories.Impl;
using Moq;

namespace DAL.Tests
{
    class TestStreetRepository
        : BaseRepository<Street>
    {
        public TestStreetRepository(DbContext context)
            : base(context)
        {
        }
        
    }

    public class BaseRepositoryForTest
    {
        [Fact]
        public void Create_InputStreetInstance_CalledAddMethodOFDBSetWithStreetInstance()
        {
            DbContextOptions opt = new DbContextOptionsBuilder<OSNContext>().Options;
            var mockContext = new Mock<OSNContext>(opt);
            var mockDbSet = new Mock<DbSet<Street>>();
            mockContext.Setup(context => context.Set<Street>()).Returns(mockDbSet.Object);
            var repository = new TestStreetRepository(mockContext.Object);
            Street expectedStreet = new Mock<Street>().Object;

            repository.Create(expectedStreet);
            
            mockDbSet.Verify(dbSet => dbSet.Add(expectedStreet), Times.Once());
            
        }
        [Fact]
        public void Delete_InputId_CalledFindAndRemoveMethodsOfDBSetWithCorrectArg()
        {
            DbContextOptions opt = new DbContextOptionsBuilder<OSNContext>().Options;
            var mockContext = new Mock<OSNContext>(opt);
            var mockDbSet = new Mock<DbSet<Street>>();
            mockContext.Setup(context => context.Set<Street>()).Returns(mockDbSet.Object);
            var repository = new TestStreetRepository(mockContext.Object);
            Street expectedStreet = new Street() { StreetID = 1};
            
            mockDbSet.Setup(mock => mock.Find(expectedStreet.StreetID)).Returns(expectedStreet);
            
            repository.Delete(expectedStreet.StreetID);
            
            mockDbSet.Verify(dbSet => dbSet.Find(expectedStreet.StreetID), Times.Once());
            mockDbSet.Verify(dbSet => dbSet.Remove(expectedStreet), Times.Once());
        }
        [Fact]
        public void Get_InputId_CalledFindMethodOfDBSetWithCorrectId()
        {
            DbContextOptions opt = new DbContextOptionsBuilder<OSNContext>()
                .Options;
            var mockContext = new Mock<OSNContext>(opt);
            var mockDbSet = new Mock<DbSet<Street>>();
            mockContext.Setup(context => context.Set<Street>()).Returns(mockDbSet.Object);

            Street expectedStreet = new Street() { StreetID = 1 };
            mockDbSet.Setup(mock => mock.Find(expectedStreet.StreetID)).Returns(expectedStreet);
            var repository = new TestStreetRepository(mockContext.Object);
            
            var actualStreet = repository.Get(expectedStreet.StreetID);
            
            mockDbSet.Verify(dbSet => dbSet.Find(expectedStreet.StreetID), Times.Once());
            Assert.Equal(expectedStreet, actualStreet);
        }
    }
}