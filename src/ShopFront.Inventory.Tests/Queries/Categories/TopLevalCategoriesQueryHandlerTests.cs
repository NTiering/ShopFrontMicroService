using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShopFront.Common;
using ShopFront.Cqrs.Queries;
using ShopFront.Inventory.Queries.Categories;
using System;
using System.Collections.Generic;

namespace ShopFront.Inventory.Tests
{

    [TestClass]
    public class TopLevalCategoriesQueryHandlerTests
    {
        private readonly IQueryHandler Subject = new TopLevalCategoriesQueryHandler();

        [TestMethod]
        public void CanBeConstructed()
        {
            Assert.IsNotNull(Subject);
        }

        [TestMethod]
        public void CanHandleQueries()
        {
            Assert.IsTrue(Subject.CanHandle(new TopLevalCategoriesQuery()));
        }

        
    }
}
