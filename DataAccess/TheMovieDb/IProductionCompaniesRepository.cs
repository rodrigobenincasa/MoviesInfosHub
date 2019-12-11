using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.TheMovieDb
{
    public interface IProductionCompaniesRepository<ProdutorasThemoviedb>
    {
        List<ProdutorasThemoviedb> GetAll();
        List<string> GetProductionCompaniesListDistinct();
    }
}
