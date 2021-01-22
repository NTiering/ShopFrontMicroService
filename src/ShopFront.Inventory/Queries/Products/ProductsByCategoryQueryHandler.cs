using ShopFront.Common;
using ShopFront.Cqrs.Queries;
using ShopFront.Inventory.DataModels;
using System.Linq;
using System.Threading.Tasks;

namespace ShopFront.Inventory.Queries.Products
{
    public class ProductsByCategoryQueryHandler : IQueryHandler
    {
        public bool CanHandle(IQuery operation)
        {
            return operation is ProductsByCategoryQuery;
        }

        public async Task<IQueryResult> Do(IQuery operation)
        {
            var qry = operation.As<ProductsByCategoryQuery>();

            // todo : go to data store
            //using var db = new DataContext();
            using var db = new TempDataContext();

            var category = db.Category.FirstOrDefault(x => x.CategoryId == qry.CategoryId);

            var records = db.Products
                .Where(x => x.CategoryId == qry.CategoryId)
                .Where(x => x.IsVisible)
                .OrderBy(x => x.Title)
                .Select(x => new
                {
                    x.Title,
                    x.SubTitle,
                    x.ProductId,
                    x.Price
                })
                .Skip(qry.PageSize * qry.PageCount)
                .Take(qry.PageSize)
                .ToArray(); // todo : change to async

            var data = new
            {
                qry.PageCount,
                qry.PageSize,
                records,
                category
            };

            return new JsonQueryResult(data);
        }
    }
}