using System;
using System.Collections.Generic;

namespace DataBase.Models.Themoviedb
{
    public partial class Produtoras
    {
        public Produtoras()
        {
            ProdutorasGrupos = new HashSet<ProdutorasGrupos>();
        }

        public int Produtora { get; set; }
        public string Descricao { get; set; }
        public int? IdOrigem { get; set; }

        public ICollection<ProdutorasGrupos> ProdutorasGrupos { get; set; }
    }
}
