﻿using CqrsMediatREFDapper.Domain.CourseContext.Events;
using Mediator;
using System.Threading;
using System.Threading.Tasks;

namespace CqrsMediatREFDapper.Domain.CourseContext.EventHandlers
{
    public sealed class CourseEventHandler : INotificationHandler<RegisteredCourseEvent>
    {
        public async ValueTask Handle(RegisteredCourseEvent notification, CancellationToken cancellationToken)
        {
            //notification.Emails.ForEach(e => SendMail(e));


            await Task.CompletedTask;
        }
    }
}
