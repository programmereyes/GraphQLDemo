using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using DAL.Context;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using DAL.Repositories.Contracts;
using DAL.Repositories;
using BAL.Schemas;
using GraphQL;
using GraphQL.Server;
using GraphQL.Server.Ui.Playground;
using GraphQL.DataLoader;
using UI.Authentications;
using UI.Authorizations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using BAL.Services;
using GraphQL.Server.Internal;

namespace UI
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthentication("customauth")
                .AddScheme<CustomAuthenticationSchemeOptions, CustomAuthenticationHandler>("customauth",(op)=>{ });
         
            services.AddScoped<IAuthorizationHandler, CustomAuthorizationRequirementHandler>();

            services.AddAuthorization(options =>
            {
                var policyBuilder = new AuthorizationPolicyBuilder("customauth").AddRequirements(new CustomAuthorizationRequirement("customclaim", "customvalue"));
                options.DefaultPolicy = policyBuilder.Build();
            });
            services.AddDbContext<AdventureWorksDbContext>(options =>
            {
                options.UseSqlServer(_configuration.GetConnectionString("GraphQLDBtest"));
            }, ServiceLifetime.Transient);
            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddTransient<ISupplierRepository, SupplierRepository>();
            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddTransient<IShipperRepository, ShipperRepository>();
            services.AddScoped<Func<IOrderRepository>>(x => x.GetRequiredService<IOrderRepository>);
            services.AddScoped<Func<ICustomerRepository>>(x => x.GetRequiredService<ICustomerRepository>);
            services.AddScoped<Func<ISupplierRepository>>(x => x.GetRequiredService<ISupplierRepository>);
            services.AddScoped<Func<IShipperRepository>>(x => x.GetRequiredService<IShipperRepository>);
            services.AddScoped<IDependencyResolver>(x => new FuncDependencyResolver(x.GetRequiredService));
            services.AddScoped<CustomerSchema>();
            services.AddScoped<SupplierSchema>();
            services.AddSingleton<IDataLoaderContextAccessor, DataLoaderContextAccessor>();
            services.AddSingleton<DataLoaderDocumentListener>();
            services.AddScoped<CustomerAddedMessageService>();
            services.AddGraphQL(options =>
            {
                options.ExposeExceptions = true;
                
            }).AddGraphTypes(typeof(CustomerSchema).Assembly, ServiceLifetime.Scoped)
            .AddDataLoader()
            .AddUserContextBuilder(httpcontext=> httpcontext.User)
            .AddWebSockets();
            services.Configure<IISServerOptions>(config =>
            {
                config.AllowSynchronousIO = true;
            });
           //services.AddCors();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseCors(policy =>
            //{
            //    policy.AllowAnyOrigin();
            //});
            app.UseRouting();
            //var listner = serviceProvider.GetRequiredService<DataLoaderDocumentListener>();
            //var executor = new DocumentExecuter();
            //var result= executor.ExecuteAsync(opts =>
            //{
            //    opts.Listeners.Add(listner);
            //});
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseWebSockets();
            app.UseGraphQLWebSockets<CustomerSchema>("/graphql/customer");
            app.UseGraphQL<CustomerSchema>("/graphql/customer");
            app.UseGraphQL<SupplierSchema>("/graphql/supplier");
            app.UseGraphQLPlayground(new GraphQLPlaygroundOptions() { GraphQLEndPoint= "/graphql/customer"});
            app.UseGraphQLPlayground(new GraphQLPlaygroundOptions() { GraphQLEndPoint="/graphql/supplier"});
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
            });
        }
    }
}
