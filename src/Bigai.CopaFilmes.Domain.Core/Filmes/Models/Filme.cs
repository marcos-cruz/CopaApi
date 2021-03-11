namespace Bigai.CopaFilmes.Domain.Core.Filmes.Models
{
    public class Filme
    {
        #region Public Properties

        public string Id { get; private set; }
        public string Titulo { get; private set; }
        public int Ano { get; private set; }
        public decimal Nota { get; private set; }

        #endregion

        #region Constructor

        private Filme(string id, string titulo, int ano, decimal nota)
        {
            Id = id;
            Titulo = titulo;
            Ano = ano;
            Nota = nota;
        }

        /// <summary>
        /// Cria uma inatancia de <see cref="Filme"/>.
        /// </summary>
        /// <param name="id">Id que identifica o filme.</param>
        /// <param name="titulo">Título do filme.</param>
        /// <param name="ano">Ano de lançamento do filme.</param>
        /// <param name="nota">Nota atribuída ao filme no campeonato.</param>
        /// <returns>Intância de <see cref="Filme"/></returns>
        public static Filme CriarFilme(string id, string titulo, int ano, decimal nota)
        {
            return new Filme(id, titulo, ano, nota);
        }

        #endregion

        #region Public Methods

        public override bool Equals(object obj)
        {
            Filme filme = obj as Filme;

            return Id == filme.Id &&
                   Titulo == filme.Titulo &&
                   Ano == filme.Ano &&
                   Nota == filme.Nota;
        }

        public static bool operator ==(Filme objA, Filme objB)
        {
            if (ReferenceEquals(objA, null) && ReferenceEquals(objB, null))
            {
                return true;
            }

            if (ReferenceEquals(objA, null) || ReferenceEquals(objB, null))
            {
                return false;
            }

            return objA.Equals(objB);
        }

        public static bool operator !=(Filme objA, Filme objB)
        {
            return !(objA == objB);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        #endregion
    }
}
