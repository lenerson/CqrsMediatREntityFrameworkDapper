using System;

namespace CqrsMediatREFDapper.Domain.CourseContext.Commands
{
    public sealed class RemoveCourseCommand : CourseCommand
    {
        public static RemoveCourseCommand Create(Guid id) =>
            new RemoveCourseCommand { Id = id };
    }
}
