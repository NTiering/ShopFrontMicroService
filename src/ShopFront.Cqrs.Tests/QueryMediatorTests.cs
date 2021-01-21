using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShopFront.Cqrs.Queries;
using System;
using System.Threading.Tasks;

namespace ShopFron.Cqrs.Tests
{
    [TestClass]
    public class QueryMediatorTests
    {
       
        private IQueryMediator QueryMediator => GetTestSubject();

        [TestMethod]
        public void CanBeConstructed()
        {
            Assert.IsNotNull(QueryMediator);
        }

        [TestMethod]
        public async Task CanHandleQuery()
        {
            var result = await QueryMediator.Do(new TestQuery());
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public async Task CanHandleQueryAndReturnCorrectType()
        {
            var result = (TestQueryResult)await QueryMediator.Do(new TestQuery());
            Assert.IsNotNull(result);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public async Task ThrowsException()
        {
            await QueryMediator.Do(new OtherTestQuery());
        }

        
        // ++++++++++++++++++++++++++++++++++++
        // helpers
        // ++++++++++++++++++++++++++++++++++++

        private IQueryMediator GetTestSubject()
        {
            var subject = new QueryMediator(new IQueryHandler[] { new TestQueryHandler() });
            return subject;
        }

        private class OtherTestQuery : IQuery { }

        private class TestQuery : IQuery { }

        private class TestQueryHandler : IQueryHandler
        {
            public bool CanHandle(IQuery operation)
            {
                return operation is TestQuery;
            }

            public Task<IQueryResult> Do(IQuery operation)
            {
                return Task.FromResult<IQueryResult>(new TestQueryResult());
            }
        }

        private class TestQueryResult : IQueryResult { }

    }
}