using ShopFront.Common;
using System.Collections.Generic;

namespace ShopFront.Cqrs.Queries
{
    public abstract class PaginatedQueryResult<T> : IQueryResult
        where T :class
    {
        public PaginatedQueryResult(int pageSize, int pageCount, int totalRecords, IEnumerable<T> results)
        {
            ThrowIf.Argument.IsNull(results, nameof(results));
            PageSize = pageSize;
            PageCount = pageCount;
            TotalRecords = totalRecords;
            Results = results;
        }

        public int PageSize { get; }
        public int PageCount { get; }
        public int TotalRecords { get; }
        public IEnumerable<T> Results { get; }
    }
}