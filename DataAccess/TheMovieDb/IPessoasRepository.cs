using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.TheMovieDb
{
    public interface IPessoasRepository<CrewThemoviedb>
    {
		List<CrewThemoviedb> GetAll();
		List<string> GetDirectoresFilmesListDistinct();
	}
}
