using System;
using System.Collections.Generic;

namespace DataBase.Models.Themoviedb
{
    public partial class ProcessamentosStatus
    {
        public ProcessamentosStatus()
        {
            FilmesCartazFila = new HashSet<FilmesCartazFila>();
            TheMoviesDbConfiguracoesMapeamentosExecucoes = new HashSet<TheMoviesDbConfiguracoesMapeamentosExecucoes>();
        }

        public int ProcessamentoStatus { get; set; }
        public string Descricao { get; set; }

        public ICollection<FilmesCartazFila> FilmesCartazFila { get; set; }
        public ICollection<TheMoviesDbConfiguracoesMapeamentosExecucoes> TheMoviesDbConfiguracoesMapeamentosExecucoes { get; set; }
    }
}
