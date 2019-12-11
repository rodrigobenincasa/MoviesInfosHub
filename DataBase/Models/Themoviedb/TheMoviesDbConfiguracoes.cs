using System;
using System.Collections.Generic;

namespace DataBase.Models.Themoviedb
{
    public partial class TheMoviesDbConfiguracoes
    {
        public TheMoviesDbConfiguracoes()
        {
            TheMoviesDbConfiguracoesMapeamentos = new HashSet<TheMoviesDbConfiguracoesMapeamentos>();
        }

        public long TheMovieDbConfiguracao { get; set; }
        public string Nome { get; set; }
        public string Url { get; set; }
        public string UrlFiltro { get; set; }
        public string UrlComplemento { get; set; }
        public bool? GetDiretores { get; set; }
        public string Servico { get; set; }
        public string Metodo { get; set; }

        public virtual ICollection<TheMoviesDbConfiguracoesMapeamentos> TheMoviesDbConfiguracoesMapeamentos { get; set; }
    }
}
