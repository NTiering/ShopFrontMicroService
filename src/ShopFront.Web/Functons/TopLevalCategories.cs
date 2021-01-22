using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using ShopFront.Common;
using ShopFront.Cqrs.Queries;
using ShopFront.Inventory.Queries.Categories;
using System.Threading.Tasks;

namespace ShopFront.Api.ProdCat.Functons
{
    public class TopLevalCategories
    {
        private readonly IQueryMediator _queryMediator;

        public TopLevalCategories(IQueryMediator queryMediator)
        {
            _queryMediator = queryMediator;
        }

        [FunctionName("TopLevalCategories")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "Categories")]
            HttpRequest req,
            ILogger log)
        {
            log.LogInformation($"TopLevalCategories {req.Path} started");

            var qry = new TopLevalCategoriesQuery();
            var respose = await _queryMediator.Do(qry);
            return new OkObjectResult(respose.As<JsonQueryResult>().Json);
        }
    }
}