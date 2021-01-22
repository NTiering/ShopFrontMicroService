using ShopFront.Cqrs.Queries;

namespace ShopFront.Inventory.Queries.Products
{
    public class ProductsByCategoryQuery : PaginatedQuery
    {
        public ProductsByCategoryQuery(int categoryId, int pageCount, int pageSize)
        {
            CategoryId = categoryId;
            PageCount = pageCount;
            PageSize = pageSize;
        }

        public int CategoryId { get; }
    }
}