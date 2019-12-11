using System;
using System.Collections.Generic;

namespace DataBase.Models.Themoviedb
{
    public partial class CinemasStatus
    {
        public CinemasStatus()
        {
            Fatos = new HashSet<Fatos>();
        }

        public int CinemaStatus { get; set; }
        public string Nome { get; set; }

        public ICollection<Fatos> Fatos { get; set; }
    }
}
