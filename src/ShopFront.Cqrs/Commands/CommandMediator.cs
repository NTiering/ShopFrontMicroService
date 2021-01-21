using ShopFront.Common;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ShopFront.Cqrs.Commands
{
    public class CommandMediator : ICommandMediator
    {
        private readonly ICommandHandler[] _commandHandlers;

        public CommandMediator(ICommandHandler[] commandHandlers)
        {
            _commandHandlers = commandHandlers;
        }

        public async Task<ICommandResult[]> Do(ICommand operation)
        {
            ThrowIf.Argument.IsNull(operation, nameof(operation));
            return await GetHandlers(operation).Do(operation);
        }

        private AggregateCommandHandler GetHandlers(ICommand operation)
        {
            var handlers = _commandHandlers.Where(x => x.CanHandle(operation)).OrderBy(x => x.Priority);
            if (handlers.Any() == false)
            {
                throw new InvalidOperationException($"No handler found for operation type {operation.GetType().FullName}");
            }
            return new AggregateCommandHandler(handlers);
        }
    }
}