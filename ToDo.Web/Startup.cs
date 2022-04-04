using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ToDo.Application;
using ToDo.Core.Options;
using ToDo.Core.Repository;
using ToDo.Repositorys.Mongo;
using ToDo.Web.Mutations;
using ToDo.Web.Querys;

namespace ToDo.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services
                .Configure<DatabaseOptions>(Configuration.GetSection("ToDoDatabase"));

            services
                .AddScoped<IRepository, MongoRepository>();

            services
                .AddMediatR(typeof(Configuration).Assembly);

            services
                .AddGraphQLServer()
                .AddQueryType<Query>()
                .AddMutationType<Mutation>()
                .AddFiltering()
                .AddSorting();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGraphQL("/graphql");
            });
        }
    }
}
