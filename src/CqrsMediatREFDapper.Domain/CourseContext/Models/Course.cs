using System;

namespace CqrsMediatREFDapper.Domain.CourseContext.Models
{
    public class Course
    {
        #region Properties

        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public byte[] Video { get; private set; }

        #endregion
        #region Constructor

        private Course() { }

        #endregion
        #region Factory Methods

        public static Course CreateToInsert(string name, string description, decimal price, byte[] video) =>
            new Course
            {
                Id = Guid.NewGuid(),
                Name = name,
                Description = description,
                Price = price,
                Video = video
            };

        public static Course CreateToUpdate(Guid id, string name, string description, Decimal price, byte[] video) =>
            new Course
            {
                Id = id,
                Name = name,
                Description = description,
                Price = price,
                Video = video
            };

        #endregion
    }
}
