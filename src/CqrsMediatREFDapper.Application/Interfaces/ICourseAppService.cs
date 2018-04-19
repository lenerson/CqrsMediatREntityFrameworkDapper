using CqrsMediatREFDapper.Application.InputModels;
using CqrsMediatREFDapper.Application.QueryModels.Output;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CqrsMediatREFDapper.Application.Interfaces
{
    public interface ICourseAppService
    {
        Task Register(CourseInputModel courseInputModel);
        Task Update(CourseInputModel courseInputModel);
        Task Remove(Guid courseId);
        Task<IEnumerable<CourseListQueryOutput>> GetAllCourses();
        Task<WatchCourseVideoQueryOutput> WatchCourse(Guid courseId);
    }
}
