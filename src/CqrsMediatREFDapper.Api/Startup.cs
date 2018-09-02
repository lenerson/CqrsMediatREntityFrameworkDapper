using CqrsMediatREFDapper.Infra.CrossCutting.IoC;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace CqrsMediatREFDapper.Api
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
            services.AddMvc();

            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "CQRS with MediatR, Entity Framework Core and Dapper",
                    Description = "CQRS with MediatR, Entity Framework Core and Dapper",
                    Contact = new Contact { Name = "Lenerson Velho Nunes", Email = "lenerson.nunes@gmail.com", Url = "https://dotnetcaxias.wordpress.com/2017/05/02/apresentacao-lenerson-velho-nunes/" },
                    License = new License { Name = "MIT", Url = "https://github.com/lenerson/CqrsMediatREntityFrameworkDapper/blob/master/LICENSE" }
                });
            });

            IoC.Configure(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();

            app.UseSwagger();
            app.UseSwaggerUI(s =>
            {
                s.SwaggerEndpoint("/swagger/v1/swagger.json", "CQRS with MediatR, Entity Framework Core and Dapper API v1.0");
            });
        }
    }
}
