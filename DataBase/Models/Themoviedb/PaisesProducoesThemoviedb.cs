using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace DataBase.Models.Themoviedb
{
    public partial class PaisesProducoesThemoviedb
    {
        public long PaisProducao { get; set; }
        public long? Filme { get; set; }
        [JsonProperty("iso_3166_1")]
        public string Iso31661 { get; set; }
        public string Name { get; set; }

        public FilmesThemoviedb FilmeNavigation { get; set; }
    }
}
