using Bigai.CopaFilmes.Api.Controllers.V1.Abstracts;
using Bigai.CopaFilmes.Api.Mappers;
using Bigai.CopaFilmes.Api.Requests;
using Bigai.CopaFilmes.Domain.Core.Filmes.Interfaces;
using Bigai.CopaFilmes.Domain.Shared.Commands;
using Bigai.CopaFilmes.Domain.Shared.Interfaces;
using Bigai.CopaFilmes.Domain.Shared.Notifications;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Bigai.CopaFilmes.Api.Controllers.V1
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/filmes")]
    public class FilmesController : MainController
    {
        #region Private Variables

        private IHttpClientFactory _clientFactory;
        private readonly ILogger<FilmesController> _logger;
        private readonly string _urlFilmes = "http://copafilmes.azurewebsites.net/api/filmes";
        private readonly IFilmeService _filmeService;

        #endregion

        #region Constructor

        public FilmesController(IHttpClientFactory clientFactory,
                               ILogger<FilmesController> logger,
                               IDomainNotificationHandler domainNotificationHandler,
                               IFilmeService filmeService) : base(domainNotificationHandler)
        {
            _logger = logger;
            _clientFactory = clientFactory;
            _filmeService = filmeService;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Obtém uma lista com os filmes que participam da Copa de Filmes.
        /// </summary>
        [AllowAnonymous]
        [HttpGet]
        [ProducesResponseType(typeof(CommandResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(CommandResponse), (int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> ObterFilmes()
        {
            HttpClient client = _clientFactory.CreateClient();

            CommandResult result;

            try
            {
                FilmeRequest[] filmes = await client.GetFromJsonAsync<FilmeRequest[]>(_urlFilmes);
                result = CommandResult.Ok("Filmes obtidos com sucesso.");
                result.Data = filmes;
            }
            catch (Exception ex)
            {
                result = CommandResult.NotFound("Ocorreu um erro ao obter a lista de filmes.");
                _notificationHandler.NotifyError(new DomainNotification("GetFilmes", ex.Message));
            }

            CommandResponse response = FormatResponse(result);

            return StatusCode(response.StatusCode, response);
        }

        /// <summary>
        ///  Monta o chaveamento do Campeonato de Filmes.
        /// </summary>
        /// <param name="request">Lista contendo 8 filmes para a geração do campeonato.</param>
        [AllowAnonymous]
        [HttpPost]
        [ProducesResponseType(typeof(CommandResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(CommandResponse), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GerarCampeonato([FromBody] FilmeRequest[] request)
        {
            CommandResponse response;
            CommandResult result = null;

            if (request == null || request.Length != 8)
            {
                result = CommandResult.BadRequest("Você deve selecionar 8 filmes para o campeonato.");
            }
            else
            {
                result = await _filmeService.GerarCampeonato(request.ToDomain());
            }

            response = FormatResponse(result);

            return StatusCode(response.StatusCode, response);
        }

        #endregion
    }
}
