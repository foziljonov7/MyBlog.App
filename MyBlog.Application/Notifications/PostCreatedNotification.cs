using MediatR;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Application.Notifications
{
    public class PostCreatedNotification : INotification
    {
        public int Id { get; set; }
    }

    public class PostNotoficationHandler : INotificationHandler<PostCreatedNotification>
    {
        public async Task Handle(PostCreatedNotification notification, CancellationToken cancellationToken)
        {
            Debug.Print($"{notification.Id.ToString()}");
        }
    }
}
