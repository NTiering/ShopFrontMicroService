using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using ShopFront.Api.ProdCat;
using ShopFront.Cqrs.Queries;
using ShopFront.Inventory.Queries.Categories;
using ShopFront.Inventory.Queries.Products;

[assembly: FunctionsStartup(typeof(Startup))]

namespace ShopFront.Api.ProdCat
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            ConfigureServices(builder.Services).BuildServiceProvider(true);
        }

        private IServiceCollection ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IQueryMediator, QueryMediator>();
            services.AddSingleton<IQueryHandler, ChildCategoriesQueryHandler>();
            services.AddSingleton<IQueryHandler, TopLevalCategoriesQueryHandler>();
            services.AddSingleton<IQueryHandler, ProductsByCategoryQueryHandler>();
            return services;
        }
    }
}