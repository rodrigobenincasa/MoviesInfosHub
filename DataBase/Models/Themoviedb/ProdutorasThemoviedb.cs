using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace DataBase.Models.Themoviedb
{
    public partial class ProdutorasThemoviedb
    {
        public long Produtora { get; set; }
        public long? Filme { get; set; }
        public int? Id { get; set; }
        [JsonProperty("logo_path")]
        public string LogoPath { get; set; }
        public string Name { get; set; }
        [JsonProperty("origin_country")]
        public string OriginCountry { get; set; }

        public FilmesThemoviedb FilmeNavigation { get; set; }
    }
}
