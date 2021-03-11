using Bigai.CopaFilmes.Domain.Shared.Notifications;
using System.Collections.Generic;

namespace Bigai.CopaFilmes.Domain.Shared.Commands
{
    /// <summary>
    /// <see cref="CommandResponse"/> represents the reponse of request.
    /// </summary>
    public class CommandResponse
    {
        #region Properties

        /// <summary>
        /// Determines whether the request has been successfully executed.
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// Message returned by request.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Response code, according to http status code.
        /// </summary>
        public int StatusCode { get; set; }

        /// <summary>
        /// Data produced by the request.
        /// </summary>
        public object Data { get; set; }

        /// <summary>
        /// Errors found in the request, if it has not been successfully completed.
        /// </summary>
        public List<Notification> Errors { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Return a instance of <see cref="CommandResponse"/>.
        /// </summary>
        public CommandResponse()
        {
            Success = false;
            Message = null;
            StatusCode = 0;
            Errors = new List<Notification>();
        }

        #endregion
    }
}
