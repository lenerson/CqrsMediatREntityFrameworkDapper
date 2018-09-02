using CqrsMediatREFDapper.Domain.CourseContext.Commands;
using CqrsMediatREFDapper.Domain.CourseContext.Events;
using CqrsMediatREFDapper.Domain.CourseContext.Interfaces.Repositories;
using CqrsMediatREFDapper.Domain.CourseContext.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CqrsMediatREFDapper.Domain.CourseContext.CommandHandlers
{
    public sealed class CourseCommandHandler :
        IRequestHandler<RegisterCourseCommand>,
        IRequestHandler<UpdateCourseCommand>,
        IRequestHandler<RemoveCourseCommand>
    {
        private readonly IMediator mediator;
        private readonly ICourseWriteOnlyRepository courseWriteOnlyRepository;

        public CourseCommandHandler(IMediator mediator, ICourseWriteOnlyRepository courseWriteOnlyRepository)
        {
            this.mediator = mediator;
            this.courseWriteOnlyRepository = courseWriteOnlyRepository;
        }

        public async Task<Unit> Handle(RegisterCourseCommand request, CancellationToken cancellationToken)
        {
            await courseWriteOnlyRepository.Add(Course.CreateToInsert(request.Name, request.Description, request.Price, request.Video));
            await mediator.Publish(RegisteredCourseEvent.Create(request.Name, new string[] { "teste@teste.com" }), cancellationToken);

            return await Unit.Task;
        }

        public async Task<Unit> Handle(UpdateCourseCommand request, CancellationToken cancellationToken)
        {
            await courseWriteOnlyRepository.Update(
                Course.CreateToUpdate(request.Id, request.Name, request.Description, request.Price, request.Video)
            );

            return await Unit.Task;
        }

        public async Task<Unit> Handle(RemoveCourseCommand request, CancellationToken cancellationToken)
        {
            await courseWriteOnlyRepository.Remove(request.Id);
            return await Unit.Task;
        }
    }
}
