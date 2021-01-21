using ShopFront.Common;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ShopFront.Cqrs.Queries
{
    public class QueryMediator : IQueryMediator
    {
        private readonly IQueryHandler[] _queryHandlers;

        public QueryMediator(IQueryHandler[] queryHandlers)
        {
            _queryHandlers = queryHandlers;
        }

        public async Task<IQueryResult> Do(IQuery operation)
        {
            ThrowIf.Argument.IsNull(operation, nameof(operation));
            return await GetHandler(operation).Do(operation);
        }

        private IQueryHandler GetHandler(IQuery operation)
        {
            var handler = _queryHandlers.FirstOrDefault(x => x.CanHandle(operation));
            if (handler == null)
            {
                throw new InvalidOperationException($"No handler found for operation type {operation.GetType().FullName}");
            }
            return handler;
        }
    }
}