using System;
using System.Collections.Generic;

namespace DataBase.Models.Themoviedb
{
    public partial class GenerosGrupos
    {
        public int GeneroGrupo { get; set; }
        public int Genero { get; set; }
        public int? IdOrigem { get; set; }
        public int? Grupo { get; set; }

        public Generos GeneroNavigation { get; set; }
    }
}
