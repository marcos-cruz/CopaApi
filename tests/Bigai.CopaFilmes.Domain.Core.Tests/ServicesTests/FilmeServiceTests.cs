using Bigai.CopaFilmes.Domain.Core.Filmes.Models;
using Bigai.CopaFilmes.Domain.Core.Filmes.Services;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using Xunit;

namespace Bigai.CopaFilmes.Domain.Core.Tests.ServicesTests
{
    public class FilmeServiceTests
    {
        [Fact]
        public async Task GerarCampeonato_DeveRetornarOsCampeoes()
        {
            //
            // Arrange
            //
            FilmeService service = new FilmeService();

            var filmesSelecionados = new List<Filme>()
            {
                { Filme.CriarFilme("tt3606756", "Os Incríveis 2", 2018, decimal.Parse("8.5", CultureInfo.InvariantCulture)) },
                { Filme.CriarFilme("tt4881806", "Jurassic World: Reino Ameaçado", 2018, decimal.Parse("6.7", CultureInfo.InvariantCulture)) },
                { Filme.CriarFilme("tt5164214", "Oito Mulheres e um Segredo", 2018, decimal.Parse("6.3", CultureInfo.InvariantCulture)) },
                { Filme.CriarFilme("tt7784604", "Hereditário", 2018, decimal.Parse("7.8", CultureInfo.InvariantCulture)) },
                { Filme.CriarFilme("tt4154756", "Vingadores: Guerra Infinita", 2018, decimal.Parse("8.8", CultureInfo.InvariantCulture)) },
                { Filme.CriarFilme("tt5463162", "Deadpool 2", 2018, decimal.Parse("8.1", CultureInfo.InvariantCulture)) },
                { Filme.CriarFilme("tt3778644", "Han Solo: Uma História Star Wars", 2018, decimal.Parse("7.2", CultureInfo.InvariantCulture)) },
                { Filme.CriarFilme("tt3501632", "Thor: Ragnarok", 2017, decimal.Parse("7.9", CultureInfo.InvariantCulture)) },
            };

            var filmesCampeoes = new List<Filme>()
            {
                { Filme.CriarFilme("tt4154756", "Vingadores: Guerra Infinita", 2018, decimal.Parse("8.8", CultureInfo.InvariantCulture)) },
                { Filme.CriarFilme("tt3606756", "Os Incríveis 2", 2018, decimal.Parse("8.5", CultureInfo.InvariantCulture)) }
            };

            //
            // Act
            //
            var result = await service.GerarCampeonato(filmesSelecionados);
            List<Filme> filmesResult = (List<Filme>)result.Data;

            //
            // Assert
            //
            Assert.True(result.Success);
            Assert.True(filmesResult != null && filmesResult[0] == filmesCampeoes[0]);
            Assert.True(filmesResult != null && filmesResult[1] == filmesCampeoes[1]);
        }
    }
}
