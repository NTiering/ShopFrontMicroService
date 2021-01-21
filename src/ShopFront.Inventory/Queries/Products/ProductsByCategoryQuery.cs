using System;
using System.Collections.Generic;
using ShopFront.Cqrs.Queries;

namespace ShopFront.Inventory.Queries.Products
{
    public class ProductsByCategoryQuery : PaginatedQuery
    {
        public int CategoryId { get; }
        public ProductsByCategoryQuery(int categoryId, int pageCount, int pageSize)
        {
            CategoryId = categoryId;
            PageCount = pageCount;
            PageSize = pageSize;
        }

    }
}
