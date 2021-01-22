using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using ShopFront.Api.ProdCat.Ext;
using ShopFront.Common;
using ShopFront.Cqrs.Queries;
using ShopFront.Inventory.Queries.Products;
using System.Threading.Tasks;

namespace ShopFront.Api.ProdCat.Functons
{
    public class ProductsByCategory
    {
        private readonly IQueryMediator _queryMediator;

        public ProductsByCategory(IQueryMediator queryMediator)
        {
            _queryMediator = queryMediator;
        }

        [FunctionName("ProductsByCategory")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "Products/{categoryId}/{pageSize}/{pageCount}")]
            HttpRequest req,
            string categoryId,
            string pageSize,
            string pageCount,

            ILogger log)
        {
            log.LogInformation($"ProductsByCategory {req.Path} started");

            var qry = new ProductsByCategoryQuery
                (
                    categoryId: categoryId.ToInt(defaultValue: -1),
                    pageCount: pageCount.ToInt(defaultValue: 0),
                    pageSize: pageSize.ToInt(25)
                );
            var respose = await _queryMediator.Do(qry);
            return new OkObjectResult(respose.As<JsonQueryResult>().Json);
        }
    }
}