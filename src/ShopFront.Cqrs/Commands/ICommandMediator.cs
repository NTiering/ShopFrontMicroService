using System.Threading.Tasks;

namespace ShopFront.Cqrs.Commands
{
    public interface ICommandMediator
    {
        Task<ICommandResult[]> Do(ICommand operation);
    }
}