using CqrsMediatREFDapper.Application.Interfaces;
using CqrsMediatREFDapper.Application.Services;
using CqrsMediatREFDapper.Domain.CourseContext.Interfaces.Repositories;
using CqrsMediatREFDapper.Domain.CourseContext.Models;
using CqrsMediatREFDapper.Infra.Data.Repository.Dapper;
using CqrsMediatREFDapper.Infra.Data.Repository.EntityFramework;
using Mediator;
using Microsoft.Extensions.DependencyInjection;

namespace CqrsMediatREFDapper.Infra.CrossCutting.IoC
{
    public sealed class IoC
    {
        public static void Configure(IServiceCollection services)
        {
            // Application Services
            services.AddScoped<ICourseAppService, CourseAppService>();

            // Repositories
            services.AddTransient<ICourseWriteOnlyRepository, CourseWriteOnlyRepository>();
            services.AddTransient<ICourseReadOnlyRepository, CourseReadOnlyRepository>();

            // Add Mediator service
            services.AddMediator((MediatorOptions options) => options.Assemblies = [typeof(Course)]);
        }
    }
}
