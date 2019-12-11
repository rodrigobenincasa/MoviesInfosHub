using App.DTO;
using App.TheMovieDb.DTO;
using DataAccess.GenericRepository;
using DataAccess.TheMovieDb;
using DataBase.Models.Themoviedb;
using Newtonsoft.Json;
using QueueAdm;
using System;
using System.Collections.Generic;
using TheMovieDb.RestApi;

namespace App
{
    public class TheMovieDbAccess
    {
        #region Constroi Objetos

        public static FilmesThemoviedb FilmeFromJson(string response)
        {
            Filme.RootObject filmesCartaz = JsonConvert.DeserializeObject<Filme.RootObject>(response);

            FilmesThemoviedb filme = JsonConvert.DeserializeObject<FilmesThemoviedb>(response);

            return filme;
        }

        public static long FilmeSaveFromJson(string response)
        {
            FilmesThemoviedb filme = FilmeFromJson(response);

            IFilmesThemoviedbRepository<FilmesThemoviedb> repository = new FilmesThemoviedbRepository<FilmesThemoviedb>();
            return repository.InsertFilmesThemoviedbReturnIdentity(filme);
        }

        public static List<CrewThemoviedb> DiretorFromJson(string response, long filme)
        {
            FilmesCreditos.RootObject crew = JsonConvert.DeserializeObject<FilmesCreditos.RootObject>(response);
            List<CrewThemoviedb> diretorLista = FilmesCreditos.FilmesCreditosToCrewDirector(crew, filme);

            IGenericRepository<CrewThemoviedb> repository = new GenericRepository<CrewThemoviedb>();
            repository.BulkInsert(diretorLista);

            return diretorLista;
        }
        #endregion

        #region CreateQueue

        public static List<string> GetGenresIds()
        {
            IGenresRepository<GenerosThemoviedb> genresRepository = new GenresRepository<GenerosThemoviedb>();
            return genresRepository.GetGenresListDistinct();
        }

        public static List<string> GetProductionCompaniesIds()
        {
            IProductionCompaniesRepository<ProdutorasThemoviedb> ProdutorasThemoviedbRepository = new ProductionCompaniesRepository<ProdutorasThemoviedb>();
            return ProdutorasThemoviedbRepository.GetProductionCompaniesListDistinct();
		}

		public static List<string> GetDiretoresIds()
		{
			IPessoasRepository<CrewThemoviedb> diretoresThemoviedbRepository = new PessoasRepository<CrewThemoviedb>();
			return diretoresThemoviedbRepository.GetDirectoresFilmesListDistinct();
		}

		public static void SetQueueNowPlaying()
        {
            int pageTotal = 1;
            int page = 1;

            string url = $"https://api.themoviedb.org/3/movie/";
            string urlApiKey = "?api_key=447064b4e3b332a6262a607318328cd3";
            string urlRegion = "&region=US";
            string urlPage = "&page=";
            string headers = "";
            string metodo = "Get";
            string servico = "now_playing";

            string urlNowPlaying = url + servico + urlApiKey + urlRegion + urlPage;

            TheMovieDbAccess.SetQueue(servico, pageTotal, page, urlNowPlaying, metodo, headers);
        }

        public static void SetQueueUpcoming()
        {
            int pageTotal = 1;
            int page = 1;

            string url = $"https://api.themoviedb.org/3/movie/";
            string urlApiKey = "?api_key=447064b4e3b332a6262a607318328cd3";
            string urlRegion = "&region=US";
            string urlPage = "&page=";
            string headers = "";
            string metodo = "Get";
            string servico = "upcoming";

            string urlNowPlaying = url + servico + urlApiKey + urlRegion + urlPage;

            TheMovieDbAccess.SetQueue(servico, pageTotal, page, urlNowPlaying, metodo, headers);
        }

        public static void SetQueueGenres()
        {
            int pageTotal = 1;
            int page      = 1;

            string url        = $"https://api.themoviedb.org/3/discover/movie";
            string urlApiKey  = "?api_key=447064b4e3b332a6262a607318328cd3";
            string urlRegion  = "&region=US";
            string urlPage    = "&page=";
            string headers    = "";
            string metodo     = "Get";
            string servico    = "Genres";
            string urlFiltros = null;
            string urlGenres  = null;

            List<string> genresList = GetGenresIds();

            foreach (var item in genresList)
            {
                urlFiltros = $"&with_genres={item}&primary_release_date.gte=2016-01-01";
                urlGenres  = url + urlApiKey + urlRegion + urlFiltros + urlPage;

                TheMovieDbAccess.SetQueue(servico, pageTotal, page, urlGenres, metodo, headers);
            }            
        }

        public static void SetQueuProductionCompanies()
        {
            int pageTotal = 1;
            int page      = 1;

            string url        = $"https://api.themoviedb.org/3/discover/movie";
            string urlApiKey  = "?api_key=447064b4e3b332a6262a607318328cd3";
            string urlRegion  = "&region=US";
            string urlPage    = "&page=";
            string headers    = "";
            string metodo     = "Get";
            string servico    = "ProductionCompanies";
            string urlFiltros = null;
            string urlProductionCompanies = null;

            List<string> productionCompaniesList = GetProductionCompaniesIds();

            foreach (var item in productionCompaniesList)
            {
                urlFiltros = $"&with_companies={item}&primary_release_date.gte=2009-01-01";
                urlProductionCompanies = url + urlApiKey + urlRegion + urlFiltros + urlPage;

                TheMovieDbAccess.SetQueue(servico, pageTotal, page, urlProductionCompanies, metodo, headers);
            }
        }

		public static void SetQueuDirectors()
		{
			int pageTotal = 1;
			int page = 1;

			string url = $"https://api.themoviedb.org/3/discover/movie";
			string urlApiKey = "?api_key=447064b4e3b332a6262a607318328cd3";
			string urlRegion = "&region=US";
			string urlPage = "&page=";
			string headers = "";
			string metodo = "Get";
			string servico = "Directors";
			string urlFiltros = null;
			string urlProductionCompanies = null;

			List<string> diretoresList = GetDiretoresIds();

			foreach (var item in diretoresList)
			{
				urlFiltros = $"&with_cast={item}&primary_release_date.gte=1999-01-01";
				urlProductionCompanies = url + urlApiKey + urlRegion + urlFiltros + urlPage;

				TheMovieDbAccess.SetQueue(servico, pageTotal, page, urlProductionCompanies, metodo, headers);
			}
		}

		#endregion

		#region Queue Control        
		public static void SetQueue(string servico, int pageTotal, int page, string url, string metodo, string headers)
        {
            RestApiResult apiResult = null;

            do
            {
                apiResult = null;
                apiResult = RestApiCommunications.CommunicationWebService(url + page.ToString(), metodo, headers, null, apiResult);

                FilmesCartaz.SetQueues(apiResult.response, servico, out pageTotal, out page);

                page += 1;

            }
            while (pageTotal >= page);
        }

        public static void ExecQueue()
        {
            string url       = $"https://api.themoviedb.org/3/movie/";
            string urlApiKey = "?api_key=447064b4e3b332a6262a607318328cd3";
            string urlRegion = "&region=US";
            string headers   = "";
            string metodo    = "Get";

            string urlBase       = url;
            string urlParametros = urlApiKey + urlRegion;

            long filme = 0;

            Queue.QueueDedup();
            List<FilmesCartazFila> queues = Queue.GetPending();

            RestApiResult apiResult = null;

            foreach (var item in queues)
            {
                try
                {
                    apiResult = RestApiCommunications.CommunicationWebService(urlBase + item.Id + urlParametros, metodo, headers, null, apiResult);
                    filme = FilmeSaveFromJson(apiResult.response);

                    if(item.OrigemServico == "now_playing" || item.OrigemServico == "upcoming")
                    {
                        apiResult = RestApiCommunications.CommunicationWebService(urlBase + item.Id + "/credits" + urlParametros, metodo, headers, null, apiResult);
                        DiretorFromJson(apiResult.response, filme);
                    }

                    Queue.QueueResult(item, 3, "Processado com sucesso.");
                }
                catch (Exception erro)
                {
                    Queue.QueueResult(item, 2, erro.Message);
                    continue;
                }
            }
        }
        #endregion
    }
}
