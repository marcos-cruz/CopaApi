using System.Net;

namespace Bigai.CopaFilmes.Domain.Shared.Commands
{
    /// <summary>
    /// <see cref="CommandResult"/> represents the result of executing a command or action.
    /// </summary>
    public class CommandResult
    {
        #region Properties

        public bool Success { get; set; }

        public string Message { get; set; }

        public int StatusCode { get; set; }

        public object Data { get; set; }

        #endregion

        #region Constructor

        private CommandResult(bool success, HttpStatusCode statusCode, string message)
        {
            Success = success;
            StatusCode = (int)statusCode;
            Message = message.Replace("  ", " ").Replace(" .", ".");
            Data = null;
        }

        #endregion

        #region Public Methdos

        /// <summary>
        /// Execution occurred successfully, status code 200.
        /// </summary>
        /// <param name="message">Message to the requesting interface.</param>
        /// <returns>Execution occurred successfully, status code 200.</returns>
        public static CommandResult Ok(string message)
        {
            return new CommandResult(true, HttpStatusCode.OK, message);
        }

        /// <summary>
        /// Execution occurred successfully, status code 201.
        /// </summary>
        /// <param name="message">Message to the requesting interface.</param>
        /// <returns>Execution occurred successfully, status code 201.</returns>
        public static CommandResult Created(string message)
        {
            return new CommandResult(true, HttpStatusCode.Created, message);
        }

        /// <summary>
        /// Execution occurred successfully, status code 202.
        /// </summary>
        /// <param name="message">Message to the requesting interface.</param>
        /// <returns>Execution occurred successfully, status code 201.</returns>
        public static CommandResult Accepted(string message)
        {
            return new CommandResult(true, HttpStatusCode.Accepted, message);
        }

        /// <summary>
        /// An error occurred while executing the command, status code 400.
        /// </summary>
        /// <param name="message">Message to the requesting interface.</param>
        /// <returns>Occurred while executing the command, status code 400.</returns>
        public static CommandResult BadRequest(string message)
        {
            return new CommandResult(false, HttpStatusCode.BadRequest, message);
        }

        /// <summary>
        /// An error occurred while executing the command, status code 401.
        /// </summary>
        /// <param name="message">Message to the requesting interface.</param>
        /// <returns>Occurred while executing the command, status code 401.</returns>
        public static CommandResult Unauthorized(string message)
        {
            return new CommandResult(false, HttpStatusCode.Unauthorized, message);
        }

        /// <summary>
        /// An error occurred while executing the command, status code 403.
        /// </summary>
        /// <param name="message">Message to the requesting interface.</param>
        /// <returns>Occurred while executing the command, status code 401.</returns>
        public static CommandResult Forbidden(string message)
        {
            return new CommandResult(false, HttpStatusCode.Forbidden, message);
        }

        /// <summary>
        /// An error occurred while executing the command, status code 404.
        /// </summary>
        /// <param name="message">Message to the requesting interface.</param>
        /// <returns>Occurred while executing the command, status code 401.</returns>
        public static CommandResult NotFound(string message)
        {
            return new CommandResult(false, HttpStatusCode.NotFound, message);
        }

        /// <summary>
        /// An error occurred while executing the command, status code 405.
        /// </summary>
        /// <param name="message">Message to the requesting interface.</param>
        /// <returns>Occurred while executing the command, status code 401.</returns>
        public static CommandResult MethodNotAllowed(string message)
        {
            return new CommandResult(false, HttpStatusCode.MethodNotAllowed, message);
        }

        /// <summary>
        /// An error occurred while executing the command, status code 500.
        /// </summary>
        /// <param name="message">Message to the requesting interface.</param>
        /// <returns>Occurred while executing the command, status code 500.</returns>
        public static CommandResult InternalServerError(string message)
        {
            return new CommandResult(false, HttpStatusCode.InternalServerError, message);
        }

        /// <summary>
        /// An error occurred while executing the command, status code 503.
        /// </summary>
        /// <param name="message">Message to the requesting interface.</param>
        /// <returns>Occurred while executing the command, status code 503.</returns>
        public static CommandResult ServiceUnavailable(string message)
        {
            return new CommandResult(false, HttpStatusCode.ServiceUnavailable, message);
        }

        #endregion
    }
}
