namespace ShopFront.Cqrs.Queries
{
    public abstract class PaginatedQuery : IQuery
    {
        public int PageSize { get; set; }
        public int PageCount { get; set; }
    }
}