using Bigai.CopaFilmes.Domain.Shared.Commands;
using Bigai.CopaFilmes.Domain.Shared.Interfaces;
using Bigai.CopaFilmes.Domain.Shared.Notifications;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Linq;

namespace Bigai.CopaFilmes.Api.Controllers.V1.Abstracts
{
    [Produces("application/json")]
    [ApiController]
    public abstract class MainController : ControllerBase
    {
        #region Protected Variables

        protected readonly IDomainNotificationHandler _notificationHandler;

        #endregion

        #region Constructor

        protected MainController(IDomainNotificationHandler domainNotificationHandler)
        {
            _notificationHandler = domainNotificationHandler ?? throw new ArgumentNullException(nameof(domainNotificationHandler));
        }

        #endregion

        #region Protected Methods

        protected CommandResponse NotifyInvalidErrorModel(ModelStateDictionary modelState)
        {
            CommandResult commandResut = CommandResult.BadRequest("Ação não pode ser executada, existem erros.");
            var errors = ModelState.Where(m => m.Value.Errors.Count() > 0);
            foreach (var error in errors)
            {
                _notificationHandler.NotifyError(new DomainNotification(error.Key, error.Value.Errors[0].ErrorMessage));
            }

            return FormatResponse(commandResut);
        }

        protected CommandResponse FormatResponse(CommandResult commandResut)
        {
            CommandResponse commandResponse = new CommandResponse
            {
                Success = commandResut.Success,
                Message = commandResut.Message,
                Data = commandResut.Data,
                StatusCode = commandResut.StatusCode
            };

            if (!commandResut.Success || _notificationHandler.HasNotification())
            {
                commandResponse.Errors = _notificationHandler.GetNotifications().Select(e => e.Notification).ToList();
            }

            return commandResponse;
        }

        #endregion
    }
}
