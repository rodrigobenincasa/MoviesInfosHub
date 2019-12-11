using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.TheMovieDb
{
    public interface ITheMoviesDbConfiguracoesMapeamentosRepository<TheMoviesDbConfiguracoesMapeamentos>
    {
        List<TheMoviesDbConfiguracoesMapeamentos> GetAll();
        long? GetIdByExecution(long? idExecution);
    }
}
