using MediatR;
using System.Collections.Generic;

namespace CqrsMediatREFDapper.Domain.CourseContext.Events
{
    public sealed class RegisteredCourseEvent : INotification
    {
        #region Properties

        public string Name { get; private set; }
        public IEnumerable<string> Emails { get; private set; }

        #endregion
        #region Constructor

        private RegisteredCourseEvent() { }

        #endregion
        #region Factory

        public static RegisteredCourseEvent Create(string name, IEnumerable<string> emails) =>
            new RegisteredCourseEvent
            {
                Name = name,
                Emails = emails
            };

        #endregion
    }
}
