using System;

namespace CqrsMediatREFDapper.Domain.CourseContext.Commands
{
    public sealed class UpdateCourseCommand : CourseCommand
    {
        public static UpdateCourseCommand Create(Guid id, string name, string description, decimal price, string video) =>
            new UpdateCourseCommand
            {
                Id = id,
                Name = name,
                Description = description,
                Price = price,
                Video = video
            };
    }
}
