using DataBase.Models.Themoviedb;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.TheMovieDb
{
    public class ProductionCompaniesRepository<T> : IProductionCompaniesRepository<ProdutorasThemoviedb>
    {
        private TheMovieDbContext context = null;

        public ProductionCompaniesRepository()
        {
            context = new TheMovieDbContext();
        }

        public ProductionCompaniesRepository(TheMovieDbContext context)
        {
            this.context = context;
        }

        public List<ProdutorasThemoviedb> GetAll()
        {
            return context.ProdutorasThemoviedb.ToList();
        }

        public List<string> GetProductionCompaniesListDistinct()
        {
            return context.ProdutorasThemoviedb.Select(s => s.Id.ToString()).Distinct().ToList();
        }
    }
}
