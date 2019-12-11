using DataAccess.GenericRepository;
using DataBase.Models.Themoviedb;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace App.TheMovieDb.DTO
{
    public class FilmesCreditos
    {
        #region Atributos
        [DataContract]
        public class Cast
        {
            [DataMember]
            public int? cast_id { get; set; }
            [DataMember]
            public string character { get; set; }
            [DataMember]
            public string credit_id { get; set; }
            [DataMember]
            public int? gender { get; set; }
            [DataMember]
            public int? id { get; set; }
            [DataMember]
            public string name { get; set; }
            [DataMember]
            public int? order { get; set; }
            [DataMember]
            public string profile_path { get; set; }
        }

        [DataContract]
        public class Crew
        {
            [DataMember]
            public string credit_id { get; set; }
            [DataMember]
            public string department { get; set; }
            [DataMember]
            public int? gender { get; set; }
            [DataMember]
            public int? id { get; set; }
            [DataMember]
            public string job { get; set; }
            [DataMember]
            public string name { get; set; }
            [DataMember]
            public string profile_path { get; set; }
        }

        [DataContract]
        public class RootObject
        {
            [DataMember]
            public int id { get; set; }
            [DataMember]
            public List<Cast> cast { get; set; }
            [DataMember]
            public List<Crew> crew { get; set; }
        }
        #endregion

        public static List<CrewThemoviedb> FilmesCreditosToCrewDirector(RootObject creditos, long idFilme)
        {            
            List<CrewThemoviedb> diretorLista = new List<CrewThemoviedb>();
            CrewThemoviedb diretor = null;

            foreach (var item in creditos.crew)
            {
                if(item.job == "Director")
                {
                    diretor = new CrewThemoviedb();

                    diretor.Filme = idFilme;
                    diretor.CreditId = item.credit_id;
                    diretor.Department = item.department;
                    diretor.Gender = item.gender;
                    diretor.Id = item.id;
                    diretor.Job = item.job;
                    diretor.Name = item.name;
                    diretor.ProfilePath = item.profile_path;

                    diretorLista.Add(diretor);
                }              
                
            }

            return diretorLista;
        }
    }
}
