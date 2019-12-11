using System;
using System.Collections.Generic;

namespace DataBase.Models.Themoviedb
{
    public partial class Datas
    {
        public Datas()
        {
            Fatos = new HashSet<Fatos>();
        }

        public int Data { get; set; }
        public int? Dia { get; set; }
        public int? Mes { get; set; }
        public int? Ano { get; set; }
        public DateTime? DataCompleta { get; set; }

        public ICollection<Fatos> Fatos { get; set; }
    }
}
