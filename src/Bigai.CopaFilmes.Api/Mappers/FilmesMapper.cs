using Bigai.CopaFilmes.Api.Requests;
using Bigai.CopaFilmes.Domain.Core.Filmes.Models;
using System.Collections.Generic;

namespace Bigai.CopaFilmes.Api.Mappers
{
    public static class FilmesMapper
    {
        internal static List<Filme> ToDomain(this IEnumerable<FilmeRequest> filmes)
        {
            if (filmes == null) return null;

            var retorno = new List<Filme>();

            foreach (var filme in filmes)
                retorno.Add(filme.ToDomain());

            return retorno;
        }

        internal static Filme ToDomain(this FilmeRequest filme)
        {
            if (filme == null) return null;

            return Filme.CriarFilme(filme.Id, filme.Titulo, filme.Ano, filme.Nota);
        }
    }
}
