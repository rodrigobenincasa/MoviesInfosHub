using System;
using System.Collections.Generic;

namespace DataBase.Models.Themoviedb
{
    public partial class ProducoesPaisesGrupos
    {
        public int ProducaoPaisGrupo { get; set; }
        public int Pais { get; set; }
        public int? IdOrigem { get; set; }
        public int? Grupo { get; set; }

        public Paises PaisNavigation { get; set; }
    }
}
