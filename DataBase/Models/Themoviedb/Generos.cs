using System;
using System.Collections.Generic;

namespace DataBase.Models.Themoviedb
{
    public partial class Generos
    {
        public Generos()
        {
            GenerosGrupos = new HashSet<GenerosGrupos>();
        }

        public int Genero { get; set; }
        public string Nome { get; set; }
        public int? IdOrigem { get; set; }

        public ICollection<GenerosGrupos> GenerosGrupos { get; set; }
    }
}
