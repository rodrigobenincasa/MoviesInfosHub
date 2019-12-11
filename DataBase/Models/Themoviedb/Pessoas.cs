using System;
using System.Collections.Generic;

namespace DataBase.Models.Themoviedb
{
    public partial class Pessoas
    {
        public Pessoas()
        {
            PessoasGrupos = new HashSet<PessoasGrupos>();
        }

        public long Pessoa { get; set; }
        public string Departamento { get; set; }
        public int? Id { get; set; }
        public string Name { get; set; }
        public string ProfilePath { get; set; }
        public int? IdOrigem { get; set; }

        public ICollection<PessoasGrupos> PessoasGrupos { get; set; }
    }
}
