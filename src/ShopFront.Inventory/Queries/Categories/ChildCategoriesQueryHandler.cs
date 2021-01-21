using Microsoft.EntityFrameworkCore;
using ShopFront.Common;
using ShopFront.Cqrs.Queries;
using ShopFront.Inventory.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopFront.Inventory.Queries.Categories
{
    public class ChildCategoriesQueryHandler : IQueryHandler
    {
        public bool CanHandle(IQuery operation)
        {
            return operation is ChildCategoriesQuery;
        }

        public async Task<IQueryResult> Do(IQuery operation)
        {
            var qry = operation.As<ChildCategoriesQuery>();

            // todo : go to data store
            //using var db = new DataContext();
            using var db = new TempDataContext();

            var childCategories = db.Category
                .Where(x => x.ParentCategoryId == qry.ParentCatId)
                .OrderBy(x => x.Name)
                .Select(x => new
                {
                    x.Name,
                    Id = x.CategoryId,
                    ProductCount = db.Products.Count(p => p.CategoryId == x.CategoryId)
                }).ToArray(); // todo : change to async

            var data = new
            {
                catagory = db.Category.FirstOrDefault(x=>x.CategoryId == qry.ParentCatId),
                childCategories
            };

            return new JsonQueryResult(data);
        }


    }
}
