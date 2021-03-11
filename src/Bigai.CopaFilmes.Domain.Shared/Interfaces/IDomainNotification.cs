using Bigai.CopaFilmes.Domain.Shared.Notifications;
using FluentValidation.Results;
using System.Collections.Generic;

namespace Bigai.CopaFilmes.Domain.Shared.Interfaces
{
    public interface IDomainNotificationHandler
    {
        bool HasNotification();

        List<DomainNotification> GetNotifications();

        void NotifyError(DomainNotification domainNotification);

        void NotifyError(ValidationResult validationResult);
    }
}
