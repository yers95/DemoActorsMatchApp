using MatchActors.Application.Notifications;
using MediatR;

namespace MatchActors.Application.NotificationHandlers
{
    internal sealed class LoggerMatchNotificationHandler : INotificationHandler<MatchNotification>
    {
        private readonly ILogger<LoggerMatchNotificationHandler> _logger;

        public LoggerMatchNotificationHandler(ILogger<LoggerMatchNotificationHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(MatchNotification notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation(@"{notification}", notification);

            return Task.CompletedTask;
        }
    }
}
