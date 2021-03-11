namespace Bigai.CopaFilmes.Domain.Shared.Notifications
{
    public class Notification
    {
        #region Public Properties

        public string Key { get; private set; }

        public string Value { get; private set; }

        #endregion

        #region Constructor

        public Notification(string key, string value)
        {
            Key = key;
            Value = value;
        }

        #endregion
    }
}
