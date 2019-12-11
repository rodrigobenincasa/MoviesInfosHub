using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace DataBase.Models.Themoviedb
{
    public partial class LinguasThemoviedb
    {
        public long Lingua { get; set; }
        public long? Filme { get; set; }
        [JsonProperty("iso_639_1")]
        public string Iso6391 { get; set; }
        public string Name { get; set; }

        public FilmesThemoviedb FilmeNavigation { get; set; }
    }
}
