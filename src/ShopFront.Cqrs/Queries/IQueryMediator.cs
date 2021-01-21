using System.Threading.Tasks;

namespace ShopFront.Cqrs.Queries
{
    public interface IQueryMediator
    {
        Task<IQueryResult> Do(IQuery operation);
    }
}