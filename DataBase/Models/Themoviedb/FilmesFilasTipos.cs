using System;
using System.Collections.Generic;

namespace DataBase.Models.Themoviedb
{
    public partial class FilmesFilasTipos
    {
        public FilmesFilasTipos()
        {
            FilmesFilas = new HashSet<FilmesFilas>();
        }

        public int FilmeFilaTipo { get; set; }
        public string Nome { get; set; }

        public ICollection<FilmesFilas> FilmesFilas { get; set; }
    }
}
