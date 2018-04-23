using CqrsMediatREFDapper.Application.Interfaces;
using CqrsMediatREFDapper.Application.Services;
using CqrsMediatREFDapper.Domain.CourseContext.Interfaces.Repositories;
using CqrsMediatREFDapper.Domain.CourseContext.Models;
using CqrsMediatREFDapper.Infra.Data.Repository.Dapper;
using CqrsMediatREFDapper.Infra.Data.Repository.EntityFramework;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace CqrsMediatREFDapper.Infra.CrossCutting.IoC
{
    public class IoC
    {
        public static void Configure(IServiceCollection services)
        {
            // Application Services
            services.AddScoped(typeof(ICourseAppService), typeof(CourseAppService));

            // Repositories
            services.AddTransient(typeof(ICourseWriteOnlyRepository), typeof(CourseWriteOnlyRepository));
            services.AddTransient(typeof(ICourseReadOnlyRepository), typeof(CourseReadOnlyRepository));

            // MediatR service
            services.AddMediatR(typeof(Course).GetTypeInfo().Assembly);
        }
    }
}
