using Bigai.CopaFilmes.Domain.Shared.Interfaces;
using FluentValidation.Results;
using System.Collections.Generic;

namespace Bigai.CopaFilmes.Domain.Shared.Notifications
{
    public class DomainNotificationHandler : IDomainNotificationHandler
    {
        #region Private Variables

        private List<DomainNotification> _notifications;

        #endregion

        #region Constructor

        public DomainNotificationHandler()
        {
            _notifications = new List<DomainNotification>();
        }

        #endregion

        #region Public Methods

        public bool HasNotification()
        {
            return _notifications != null && _notifications.Count > 0;
        }

        public List<DomainNotification> GetNotifications()
        {
            return _notifications;
        }

        public void NotifyError(DomainNotification notification)
        {
            _notifications.Add(notification);
        }

        public void NotifyError(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
            {
                NotifyError(new DomainNotification(error.PropertyName, error.ErrorMessage));
            }
        }

        #endregion

        #region Dispose

        public void Dispose()
        {
            _notifications = new List<DomainNotification>();
        }

        #endregion
    }
}
