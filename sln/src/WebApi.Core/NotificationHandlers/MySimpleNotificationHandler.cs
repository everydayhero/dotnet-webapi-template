namespace WebApi.Core.NotificationHandlers
{
    using System.Threading;
    using System.Threading.Tasks;
    using MediatR;
    using WebApi.Core.Notifications;

    public class MySimpleNotificationHandler : INotificationHandler<MySimpleNotification>
    {
        public Task Handle(MySimpleNotification notification, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}