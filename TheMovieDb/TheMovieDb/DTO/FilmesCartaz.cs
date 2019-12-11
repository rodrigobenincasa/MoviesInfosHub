using DataAccess.GenericRepository;
using DataBase.Models.Themoviedb;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace App.DTO
{
    [DataContract]
    public class FilmesCartaz
    {
        #region Atributos        
        [DataContract]
        public class Result
        {
            [DataMember]
            public double? popularity { get; set; }
            [DataMember]
            public int? vote_count { get; set; }
            [DataMember]
            public bool video { get; set; }
            [DataMember]
            public string poster_path { get; set; }
            [DataMember]
            public int id { get; set; }
            [DataMember]
            public bool adult { get; set; }
            [DataMember]
            public string backdrop_path { get; set; }
            [DataMember]
            public string original_language { get; set; }
            [DataMember]
            public string original_title { get; set; }
            [DataMember]
            public List<int> genre_ids { get; set; }
            [DataMember]
            public string title { get; set; }
            [DataMember]
            public double? vote_average { get; set; }
            [DataMember]
            public string overview { get; set; }
            [DataMember]
            public string release_date { get; set; }
        }

        [DataContract]
        public class Dates
        {
            [DataMember]
            public string maximum { get; set; }
            [DataMember]
            public string minimum { get; set; }
        }

        [DataContract]
        public class RootObject
        {
            [DataMember]
            public List<Result> results { get; set; }
            [DataMember]
            public int page { get; set; }
            [DataMember]
            public int total_results { get; set; }
            [DataMember]
            public Dates dates { get; set; }
            [DataMember]
            public int total_pages { get; set; }
        }
        #endregion

        public static void SetQueues(string response, string origemServico, out int totalPage, out int currentPage)
        {
            FilmesCartaz.RootObject filmesCartaz = JsonConvert.DeserializeObject<FilmesCartaz.RootObject>(response);
            List<Result> resultados = filmesCartaz.results;

            totalPage   = filmesCartaz.total_pages;
            currentPage = filmesCartaz.page;

            IGenericRepository<FilmesCartazFila> repository = new GenericRepository<FilmesCartazFila>();
            List<FilmesCartazFila> filmesCartazFilas        = new List<FilmesCartazFila>();

            foreach (var item in resultados)
            {
                filmesCartazFilas.Add(new FilmesCartazFila { 
                    Id = item.id.ToString(), 
                    ProcessamentoStatus = 1, 
                    OrigemServico = origemServico 
                });
            }

            repository.BulkInsert(filmesCartazFilas);
        }

    }

}
