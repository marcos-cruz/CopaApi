using Bigai.CopaFilmes.Domain.Core.Filmes.Models;
using Bigai.CopaFilmes.Domain.Shared.Commands;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bigai.CopaFilmes.Domain.Core.Filmes.Interfaces
{
    public interface IFilmeService
    {
        Task<CommandResult> GerarCampeonato(List<Filme> filmes);
    }
}
