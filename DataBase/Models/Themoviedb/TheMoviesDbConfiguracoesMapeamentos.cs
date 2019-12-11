using System;
using System.Collections.Generic;

namespace DataBase.Models.Themoviedb
{
    public partial class TheMoviesDbConfiguracoesMapeamentos
    {
        public TheMoviesDbConfiguracoesMapeamentos()
        {
            TheMoviesDbConfiguracoesMapeamentosExecucoes = new HashSet<TheMoviesDbConfiguracoesMapeamentosExecucoes>();
        }

        public long TheMovieDbConfiguracaoMapeamento { get; set; }
        public long? TheMovieDbConfiguracao { get; set; }
        public int Ordenacao { get; set; }

        public virtual  TheMoviesDbConfiguracoes TheMovieDbConfiguracaoNavigation { get; set; }
        public virtual ICollection<TheMoviesDbConfiguracoesMapeamentosExecucoes> TheMoviesDbConfiguracoesMapeamentosExecucoes { get; set; }
    }
}
