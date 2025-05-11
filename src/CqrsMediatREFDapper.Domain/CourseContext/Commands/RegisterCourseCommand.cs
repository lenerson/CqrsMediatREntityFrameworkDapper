namespace CqrsMediatREFDapper.Domain.CourseContext.Commands
{
    public sealed class RegisterCourseCommand : CourseCommand
    {
        public static RegisterCourseCommand Create(string name, string description, decimal price, string video) =>
            new RegisterCourseCommand
            {
                Name = name,
                Description = description,
                Price = price,
                Video = video
            };
    }
}
