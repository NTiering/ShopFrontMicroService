using System.Threading.Tasks;

namespace ShopFront.Cqrs.Queries
{
    public interface IQueryHandler
    {
        bool CanHandle(IQuery operation);

        Task<IQueryResult> Do(IQuery operation);
    }
}