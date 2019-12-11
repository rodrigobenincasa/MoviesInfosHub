using System;
using System.Collections.Generic;

namespace DataBase.Models.Themoviedb
{
    public partial class ProdutorasGrupos
    {
        public int ProdutoraGrupo { get; set; }
        public int Produtora { get; set; }
        public int? IdOrigem { get; set; }
        public int? Grupo { get; set; }

        public Produtoras ProdutoraNavigation { get; set; }
    }
}
