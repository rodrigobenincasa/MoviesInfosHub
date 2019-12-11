using System;
using System.Collections.Generic;

namespace DataBase.Models.Themoviedb
{
    public partial class CrewThemoviedb
    {
        public long Crew { get; set; }
        public long? Filme { get; set; }
        public string CreditId { get; set; }
        public string Department { get; set; }
        public int? Gender { get; set; }
        public int? Id { get; set; }
        public string Job { get; set; }
        public string Name { get; set; }
        public string ProfilePath { get; set; }

        public FilmesThemoviedb FilmeNavigation { get; set; }
    }
}
