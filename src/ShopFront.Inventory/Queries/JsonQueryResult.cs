using ShopFront.Cqrs.Queries;
using System.Text.Json;

namespace ShopFront.Common
{
    public class JsonQueryResult : IQueryResult
    {
        internal JsonQueryResult(object jsonSource)
        {
            ThrowIf.Argument.IsNull(jsonSource, nameof(jsonSource));
            Json = JsonSerializer.Serialize(jsonSource);
        }
        public string Json { get; }
    }
}
