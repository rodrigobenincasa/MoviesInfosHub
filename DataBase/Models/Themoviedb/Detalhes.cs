using System;
using System.Collections.Generic;

namespace DataBase.Models.Themoviedb
{
    public partial class Detalhes
    {
        public int Filme { get; set; }
        public string Titulo { get; set; }
        public long? IdOrigem { get; set; }
        public string TituloOriginal { get; set; }
        public string PosterUrl { get; set; }

        public Fatos Fatos { get; set; }
    }
}
