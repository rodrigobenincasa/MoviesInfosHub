using DataBase.Models.Themoviedb;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.TheMovieDb
{
	public class PessoasRepository<T> : IPessoasRepository<CrewThemoviedb>
	{
		private TheMovieDbContext context = null;

		public PessoasRepository()
		{
			context = new TheMovieDbContext();
		}

		public PessoasRepository(TheMovieDbContext context)
		{
			this.context = context;
		}

		public List<CrewThemoviedb> GetAll()
		{
			return context.CrewThemoviedb.ToList();
		}

		public List<string> GetDirectoresFilmesListDistinct()
		{
			return context.CrewThemoviedb.Where(w => w.Job == "Director").Select(s => s.Id.ToString()).Distinct().ToList();
		}
	}
}
