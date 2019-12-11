using System;
using System.Collections.Generic;

namespace DataBase.Models.Themoviedb
{
    public partial class ColecoesThemoviedb
    {
        public long Colecao { get; set; }
        public long? Filme { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string PosterPath { get; set; }
        public string BackdropPath { get; set; }

        public FilmesThemoviedb FilmeNavigation { get; set; }
    }
}
