using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace DataBase.Models.Themoviedb
{
    public partial class FilmesThemoviedb
    {
        public FilmesThemoviedb()
        {
            ColecoesThemoviedb = new HashSet<ColecoesThemoviedb>();
            CrewThemoviedb = new HashSet<CrewThemoviedb>();
            GenerosThemoviedb = new HashSet<GenerosThemoviedb>();
            LinguasThemoviedb = new HashSet<LinguasThemoviedb>();
            PaisesProducoesThemoviedb = new HashSet<PaisesProducoesThemoviedb>();
            ProdutorasThemoviedb = new HashSet<ProdutorasThemoviedb>();
        }

        public long Filme { get; set; }
        public string Adult { get; set; }
        [JsonProperty("backdrop_path")]
        public string BackdropPath { get; set; }
        public string Homepage { get; set; }
        public string Id { get; set; }
        [JsonProperty("imdb_id")]
        public string ImdbId { get; set; }
        [JsonProperty("original_language")]
        public string OriginalLanguage { get; set; }
        [JsonProperty("original_title")]
        public string OriginalTitle { get; set; }
        public string Overview { get; set; }
        public decimal? Popularity { get; set; }
        [JsonProperty("poster_path")]
        public string PosterPath { get; set; }
        [JsonProperty("release_date")]
        public DateTime? ReleaseDate { get; set; }
        public int? Revenue { get; set; }
        public int? Runtime { get; set; }
        public string Status { get; set; }
        public string Tagline { get; set; }
        public string Title { get; set; }
        public string Video { get; set; }
        [JsonProperty("vote_average")]
        public decimal? VoteAverage { get; set; }
        [JsonProperty("vote_count")]
        public int? VoteCount { get; set; }
        public double? Budget { get; set; }
        public int? CinemaStatus { get; set; }

        public ICollection<ColecoesThemoviedb> ColecoesThemoviedb { get; set; }
        public ICollection<CrewThemoviedb> CrewThemoviedb { get; set; }
        [JsonProperty("genres")]
        public ICollection<GenerosThemoviedb> GenerosThemoviedb { get; set; }
        [JsonProperty("spoken_languages")]
        public ICollection<LinguasThemoviedb> LinguasThemoviedb { get; set; }
        [JsonProperty("production_countries")]
        public ICollection<PaisesProducoesThemoviedb> PaisesProducoesThemoviedb { get; set; }
        [JsonProperty("production_companies")]
        public ICollection<ProdutorasThemoviedb> ProdutorasThemoviedb { get; set; }
    }
}
