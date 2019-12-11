using System;
using System.Collections.Generic;

namespace DataBase.Models.Themoviedb
{
    public partial class Fatos
    {
        public int Filme { get; set; }
        public int? LancamentoData { get; set; }
        public int CinemaStatus { get; set; }
        public int? ProducaoPaisGrupo { get; set; }
        public int? GeneroGrupo { get; set; }
        public int? ProdutoraGrupo { get; set; }
        public decimal? Orcamento { get; set; }
        public decimal? Receita { get; set; }
        public decimal? Lucro { get; set; }
        public int? ReceitaRank { get; set; }
        public decimal? ReceitaProdutora { get; set; }
        public decimal? LucroProdutora { get; set; }
        public int? PessoaGrupo { get; set; }

        public CinemasStatus CinemaStatusNavigation { get; set; }
        public Detalhes FilmeNavigation { get; set; }
        public Datas LancamentoDataNavigation { get; set; }
    }
}
