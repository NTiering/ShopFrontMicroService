using ShopFront.Common;
using ShopFront.Cqrs.Queries;
using ShopFront.Inventory.DataModels;
using System.Linq;
using System.Threading.Tasks;

namespace ShopFront.Inventory.Queries.Categories
{
    public class TopLevalCategoriesQueryHandler : IQueryHandler
    {
        public bool CanHandle(IQuery operation)
        {
            return operation is TopLevalCategoriesQuery;
        }

        public async Task<IQueryResult> Do(IQuery operation)
        {
            var qry = operation.As<TopLevalCategoriesQuery>();

            // todo : go to data store
            //using var db = new DataContext();
            using var db = new TempDataContext();

            var data = db.Category
                .Where(x => x.ParentCategoryId == null)
                .OrderBy(x => x.Name)
                .Select(x => new
                {
                    x.Name,
                    Id = x.CategoryId,
                    ProductCount = db.Products.Count(p => p.CategoryId == x.CategoryId)
                }).ToArray(); // todo : change to async

            return new JsonQueryResult(data);
        }
    }
}