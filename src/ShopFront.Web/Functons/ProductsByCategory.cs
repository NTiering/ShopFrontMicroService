using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using ShopFront.Cqrs.Queries;
using ShopFront.Common;
using ShopFront.Inventory.Queries.Products;
using ShopFront.Web.Ext;
namespace ShopFront.Web.Functons
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
                    categoryId: categoryId.ToInt(defaultValue:-1), 
                    pageCount: pageCount.ToInt(defaultValue:0), 
                    pageSize : pageSize.ToInt(25)
                );
            var respose = await _queryMediator.Do(qry);
            return new OkObjectResult(respose.As<JsonQueryResult>().Json);
        }
    }
}
