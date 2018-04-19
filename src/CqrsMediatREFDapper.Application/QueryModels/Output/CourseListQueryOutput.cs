using System;

namespace CqrsMediatREFDapper.Application.QueryModels.Output
{
    public sealed class CourseListQueryOutput
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public Decimal Price { get; private set; }

        public static CourseListQueryOutput Create(Guid id, string name, string description, decimal price) =>
            new CourseListQueryOutput
            {
                Id = id,
                Name = name,
                Description = description,
                Price = price
            };
    }
}
