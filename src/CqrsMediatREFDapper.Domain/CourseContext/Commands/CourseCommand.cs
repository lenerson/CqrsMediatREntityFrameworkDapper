using MediatR;
using System;

namespace CqrsMediatREFDapper.Domain.CourseContext.Commands
{
    public abstract class CourseCommand : IRequest
    {
        #region Properties

        public Guid Id { get; protected set; }
        public string Name { get; protected set; }
        public string Description { get; protected set; }
        public Decimal Price { get; protected set; }
        public byte[] Video { get; protected set; }

        #endregion
        #region Constructor

        protected CourseCommand() { }

        #endregion
    }
}
