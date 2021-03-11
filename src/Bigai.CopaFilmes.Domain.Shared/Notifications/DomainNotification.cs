using System;

namespace Bigai.CopaFilmes.Domain.Shared.Notifications
{
    public class DomainNotification
    {
        #region Public Properties

        public string Id { get; private set; }

        public Notification Notification { get; private set; }

        #endregion

        #region Constructor

        public DomainNotification(string key, string value)
        {
            Id = Guid.NewGuid().ToString();

            Notification = new Notification(key, value);
        }

        #endregion
    }
}
