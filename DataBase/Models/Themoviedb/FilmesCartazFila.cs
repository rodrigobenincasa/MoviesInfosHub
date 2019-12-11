using System;
using System.Collections.Generic;

namespace DataBase.Models.Themoviedb
{
    public partial class FilmesCartazFila
    {
        public long FilemCartazFila { get; set; }
        public string Id { get; set; }
        public int? ProcessamentoStatus { get; set; }
        public DateTime? DataHora { get; set; }
        public string ProcessamentoMensagem { get; set; }
        public string OrigemServico { get; set; }

        public ProcessamentosStatus ProcessamentoStatusNavigation { get; set; }
    }
}
