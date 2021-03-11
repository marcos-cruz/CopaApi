using Bigai.CopaFilmes.Domain.Core.Filmes.Interfaces;
using Bigai.CopaFilmes.Domain.Core.Filmes.Models;
using Bigai.CopaFilmes.Domain.Shared.Commands;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bigai.CopaFilmes.Domain.Core.Filmes.Services
{
    public class FilmeService : IFilmeService
    {
        public FilmeService() { }

        public async Task<CommandResult> GerarCampeonato(List<Filme> filmes)
        {
            filmes = OrdernarFilmes(filmes);
            
            while(filmes.Count != 2)
            {
                filmes = await Task.Run(() => Competir(filmes));
            }

            var commandResult = CommandResult.Ok("Saiu o campeão.");

            commandResult.Data = filmes;

            return commandResult;
        }

        private List<Filme> OrdernarFilmes(List<Filme> filmes)
        {
            filmes.Sort(delegate (Filme x, Filme y)
            {
                if (x.Titulo == null && y.Titulo == null) return 0;
                else if (x.Titulo == null) return -1;
                else if (y.Titulo == null) return 1;
                else return x.Titulo.CompareTo(y.Titulo);
            });

            return filmes;
        }

        private List<Filme> Competir(List<Filme> filmes)
        {
            var faseElimitoria = new List<Filme>();

            for (int i = 0, j = filmes.Count - 1, k = filmes.Count / 2; i < k; i++, j--)
            {
                var vencedor = filmes[i].Nota >= filmes[j].Nota ? filmes[i] : filmes[j];
                faseElimitoria.Add(vencedor);
            }

            return faseElimitoria;
        }
    }
}
