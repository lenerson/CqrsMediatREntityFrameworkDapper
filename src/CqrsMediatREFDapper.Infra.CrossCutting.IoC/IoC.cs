using CqrsMediatREFDapper.Application.Interfaces;
using CqrsMediatREFDapper.Application.Services;
using CqrsMediatREFDapper.Domain.CourseContext.Interfaces.Repositories;
using CqrsMediatREFDapper.Domain.CourseContext.Models;
using CqrsMediatREFDapper.Infra.Data.Repository.Dapper;
using CqrsMediatREFDapper.Infra.Data.Repository.EntityFramework;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace CqrsMediatREFDapper.Infra.CrossCutting.IoC
{
    public class IoC
    {
        public static void Configure(IServiceCollection services)
        {
            // Application Services
            services.AddScoped<ICourseAppService, CourseAppService>();

            // Repositories
            services.AddTransient<ICourseWriteOnlyRepository, CourseWriteOnlyRepository>();
            services.AddTransient<ICourseReadOnlyRepository, CourseReadOnlyRepository>();

            // MediatR service
            services.AddMediatR(c => c.RegisterServicesFromAssembly(typeof(Course).GetTypeInfo().Assembly));
        }
    }
}
