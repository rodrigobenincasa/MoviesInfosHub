using System;
using System.Collections.Generic;

namespace DataBase.Models.Themoviedb
{
    public partial class GenerosThemoviedb
    {
        public long Genero { get; set; }
        public long? Filme { get; set; }
        public int? Id { get; set; }
        public string Name { get; set; }

        public FilmesThemoviedb FilmeNavigation { get; set; }
    }
}
