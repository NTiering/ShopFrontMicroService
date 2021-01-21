using System.Threading.Tasks;

namespace ShopFront.Cqrs.Commands
{
    public interface ICommandHandler
    {
        CommandHandlerPriority Priority { get; }

        bool CanHandle(ICommand operation);

        Task<ICommandResult> Do(ICommand operation);
    }
}