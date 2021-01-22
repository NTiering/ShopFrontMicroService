using ShopFront.Cqrs.Queries;

namespace ShopFront.Inventory.Queries.Categories
{
    public class ChildCategoriesQuery : IQuery
    {
        public ChildCategoriesQuery(int parentCatId)
        {
            ParentCatId = parentCatId;
        }

        public int ParentCatId { get; }
    }
}