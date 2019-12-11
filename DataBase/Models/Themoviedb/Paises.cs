using System;
using System.Collections.Generic;

namespace DataBase.Models.Themoviedb
{
    public partial class Paises
    {
        public Paises()
        {
            ProducoesPaisesGrupos = new HashSet<ProducoesPaisesGrupos>();
        }

        public int Pais { get; set; }
        public string Nome { get; set; }
        public string Sigla { get; set; }
        public long? IdOrigem { get; set; }

        public ICollection<ProducoesPaisesGrupos> ProducoesPaisesGrupos { get; set; }
    }
}
