using CqrsMediatREFDapper.Domain.SharedContext.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace CqrsMediatREFDapper.Domain.CourseContext.Models
{
    public class Course
    {
        #region Properties

        public Guid Id { get; private set; }
        public Text Name { get; private set; }
        public Text Description { get; private set; }
        public Decimal Price { get; private set; }
        public Media Video { get; private set; }

        #endregion
        #region Constructor

        private Course() { }

        #endregion
        #region Factories

        public static Course CreateToInsert(string name, string description, Decimal price, byte[] video) =>
            new Course
            {
                Id = Guid.NewGuid(),
                Name = new Text { Value = name },
                Description = new Text { Value = description },
                Price = price,
                Video = new Media { Value = video }
            };

        public static Course CreateToUpdate(Guid id, string name, string description, Decimal price, byte[] video) =>
            new Course
            {
                Id = id,
                Name = new Text { Value = name },
                Description = new Text { Value = description },
                Price = price,
                Video = new Media { Value = video }
            };

        #endregion
    }
}
