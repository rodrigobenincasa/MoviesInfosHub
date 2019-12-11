using System.Collections.Generic;

namespace DataAccess.TheMovieDb
{
    public interface IGenresRepository<GenerosThemoviedb>
    {
        List<GenerosThemoviedb> GetAll();
        List<string> GetGenresListDistinct();
    }
}

