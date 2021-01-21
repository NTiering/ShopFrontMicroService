using ShopFront.Common;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopFront.Cqrs.Commands
{
    internal class AggregateCommandHandler
    {
        private IEnumerable<ICommandHandler> _handlers;

        public AggregateCommandHandler(IEnumerable<ICommandHandler> handlers)
        {
            _handlers = handlers;
        }

        public async Task<ICommandResult[]> Do(ICommand operation)
        {
            ThrowIf.Argument.IsNull(operation, nameof(operation));

            var results = new List<ICommandResult>();
            foreach (var h in _handlers)
            {
                results.Add(await h.Do(operation));
            }
            return results.ToArray();
        }
    }
}