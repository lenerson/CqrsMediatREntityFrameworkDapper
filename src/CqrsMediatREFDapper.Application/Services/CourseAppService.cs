using CqrsMediatREFDapper.Application.InputModels;
using CqrsMediatREFDapper.Application.Interfaces;
using CqrsMediatREFDapper.Application.QueryModels.Output;
using CqrsMediatREFDapper.Domain.CourseContext.Commands;
using CqrsMediatREFDapper.Domain.CourseContext.Interfaces.Repositories;
using Mediator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CqrsMediatREFDapper.Application.Services
{
    public sealed class CourseAppService : ICourseAppService
    {
        private readonly IMediator mediator;
        private readonly ICourseReadOnlyRepository courseReadOnlyRepository;

        public CourseAppService(IMediator mediator, ICourseReadOnlyRepository courseReadOnlyRepository)
        {
            this.mediator = mediator;
            this.courseReadOnlyRepository = courseReadOnlyRepository;
        }

        public async Task Register(CourseInputModel courseInputModel) =>
            await mediator.Send(RegisterCourseCommand.Create(
                courseInputModel.Name, courseInputModel.Description, courseInputModel.Price, courseInputModel.Video));

        public async Task Update(CourseInputModel courseInputModel) =>
            await mediator.Send(UpdateCourseCommand.Create(
                courseInputModel.Id, courseInputModel.Name, courseInputModel.Description, courseInputModel.Price, courseInputModel.Video));

        public async Task Remove(Guid courseId) => await mediator.Send(RemoveCourseCommand.Create(courseId));

        public async Task<IEnumerable<CourseListQueryOutput>> GetAllCourses()
        {
            var list = await courseReadOnlyRepository.GetAll();
            return list.Select(x => CourseListQueryOutput.Create(x.Id, x.Name, x.Description, x.Price));
        }

        public async Task<WatchCourseVideoQueryOutput> WatchCourse(Guid courseId)
        {
            var courseModel = await courseReadOnlyRepository.GetById(courseId);
            if (courseModel != null)
                return WatchCourseVideoQueryOutput.Create(courseModel.Video);
            return await Task.FromResult<WatchCourseVideoQueryOutput>(null);
        }
    }
}
