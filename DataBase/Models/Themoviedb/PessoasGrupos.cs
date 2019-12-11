using System;
using System.Collections.Generic;

namespace DataBase.Models.Themoviedb
{
    public partial class PessoasGrupos
    {
        public long PessoaGrupo { get; set; }
        public long? Pessoa { get; set; }
        public int? IdOrigem { get; set; }
        public int? Grupo { get; set; }

        public Pessoas PessoaNavigation { get; set; }
    }
}
