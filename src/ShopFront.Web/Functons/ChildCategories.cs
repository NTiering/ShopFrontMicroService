using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using ShopFront.Cqrs.Queries;
using ShopFront.Inventory.Queries.Categories;
using ShopFront.Common;
using ShopFront.Web.Ext;

namespace ShopFront.Web.Functons
{
    public class ChildCategories
    {
        private readonly IQueryMediator _queryMediator;

        public ChildCategories(IQueryMediator queryMediator)
        {
            _queryMediator = queryMediator;

        }
        [FunctionName("ChildCategories")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "Categories/{categoryId}")]
            HttpRequest req,
            string categoryId,
            ILogger log)
        {
            log.LogInformation($"ChildCategories {req.Path} started");

            if (string.IsNullOrEmpty(categoryId) == false)
            {
                var qry = new ChildCategoriesQuery(categoryId.ToInt(-1));
                var respose = await _queryMediator.Do(qry);
                return new OkObjectResult(respose.As<JsonQueryResult>().Json);
            }
            else
            {
                return new NotFoundResult();
            }
        }
    }
}
