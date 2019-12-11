using System;
using System.Collections.Generic;

namespace DataBase.Models.Themoviedb
{
    public partial class TheMoviesDbConfiguracoesMapeamentosExecucoes
    {
        public long TheMovieDbConfiguracaoMapeamentoExecucao { get; set; }
        public long? TheMovieDbConfiguracaoMapeamento { get; set; }
        public int? ProcessamentoStatus { get; set; }
        public DateTime? DataHora { get; set; }
        public string ProcessamentoMensagem { get; set; }

        public virtual  ProcessamentosStatus ProcessamentoStatusNavigation { get; set; }
        public virtual TheMoviesDbConfiguracoesMapeamentos TheMovieDbConfiguracaoMapeamentoNavigation { get; set; }
    }
}
