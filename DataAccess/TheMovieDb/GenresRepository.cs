using DataBase.Models.Themoviedb;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.TheMovieDb
{
    public class GenresRepository<T> : IGenresRepository<GenerosThemoviedb>
    {
        private TheMovieDbContext context = null;

        public GenresRepository()
        {
            context = new TheMovieDbContext();
        }

        public GenresRepository(TheMovieDbContext context)
        {
            this.context = context;
        }

        public List<GenerosThemoviedb> GetAll()
        {
            return context.GenerosThemoviedb.ToList();
        }

        public List<string> GetGenresListDistinct()
        {
            return context.GenerosThemoviedb.Select(s => s.Id.ToString()).Distinct().ToList();
        }
    }
}
