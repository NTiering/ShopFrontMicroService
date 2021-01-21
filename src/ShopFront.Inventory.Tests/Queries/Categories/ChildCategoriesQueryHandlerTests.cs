using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShopFront.Cqrs.Queries;
using ShopFront.Inventory.Queries.Categories;
using System;

namespace ShopFront.Inventory.Tests
{
    [TestClass]
    public class ChildCategoriesQueryHandlerTests
    {
        private readonly IQueryHandler Subject = new ChildCategoriesQueryHandler();

        [TestMethod]
        public void CanBeConstructed()
        {         
            Assert.IsNotNull(Subject);
        }

        [TestMethod]
        public void CanHandleQueries()
        {
            Assert.IsTrue(Subject.CanHandle(new ChildCategoriesQuery(44)));
        }
    }
}
