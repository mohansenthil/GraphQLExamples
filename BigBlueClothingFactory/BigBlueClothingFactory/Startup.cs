using BigBlueClothingFactory.DataAccess;
using BigBlueClothingFactory.DataAccess.Implementation;
using BigBlueClothingFactory.GraphQLTypes;
using BigBlueClothingFactory.Mutation;
using BigBlueClothingFactory.Queries;
using BigBlueClothingFactory.Schema;
using GraphiQl;
using GraphQL;
using GraphQL.Types;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BigBlueClothingFactory
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddScoped<IClothesRepository, ClothsRepository>();
            services.AddSingleton<IDocumentExecuter, DocumentExecuter>();
            services.AddSingleton<ClothesType>();
            services.AddSingleton<ManufacturerType>();
            services.AddSingleton<ClothesInputType>();
            services.AddSingleton<BigBlueStoreQuery>();
            services.AddSingleton<BigBlueMutation>();
            services.AddSingleton<IDependencyResolver>(new FuncDependencyResolver(type => services.BuildServiceProvider().GetService(type)));
            services.AddSingleton<ISchema, BigBlueSchema>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseGraphiQl();
            app.UseMvc();
        }
    }
}
