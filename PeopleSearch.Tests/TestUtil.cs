using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Runtime.Serialization;
using Moq;
using PeopleSearch.Services.Interfaces;

namespace PeopleSearch.Tests
{
    public static class TestUtil
    {
        public static Mock<IDataContext> GetDataContextMock<T>(IEnumerable<T> collection) where T : class
        {
            var data = new List<T>();
            data.AddRange(collection);
            var dataQueryable = data.AsQueryable();

            var mockSet = new Mock<DbSet<T>>();
            mockSet.As<IQueryable<T>>().Setup(m => m.Provider).Returns(dataQueryable.Provider);
            mockSet.As<IQueryable<T>>().Setup(m => m.Expression).Returns(dataQueryable.Expression);
            mockSet.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(dataQueryable.ElementType);
            mockSet.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(dataQueryable.GetEnumerator());
            
            var mockContext = new Mock<IDataContext>();
            mockContext.Setup(m => m.Set<T>()).Returns(mockSet.Object);

            var objectContext = (ObjectContext)FormatterServices.GetUninitializedObject(typeof(ObjectContext));

            mockContext.As<IObjectContextAdapter>().SetupGet(m => m.ObjectContext).Returns(objectContext);

            return mockContext;
        }
    }
}