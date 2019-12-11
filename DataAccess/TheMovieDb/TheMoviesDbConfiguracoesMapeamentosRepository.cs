using DataBase.Models.Themoviedb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.TheMovieDb
{
    public class TheMoviesDbConfiguracoesMapeamentosRepository<T> : ITheMoviesDbConfiguracoesMapeamentosRepository<TheMoviesDbConfiguracoesMapeamentos>
    {
        private TheMovieDbContext context = null;

        public TheMoviesDbConfiguracoesMapeamentosRepository()
        {
            context = new TheMovieDbContext();
        }

        public TheMoviesDbConfiguracoesMapeamentosRepository(TheMovieDbContext context)
        {
            this.context = context;
        }

        public List<TheMoviesDbConfiguracoesMapeamentos> GetAll()
        {
            return context.TheMoviesDbConfiguracoesMapeamentos.ToList();
        }

        public long? GetIdByExecution(long? idExecucao)
        {
            TheMoviesDbConfiguracoesMapeamentos execucao = context.TheMoviesDbConfiguracoesMapeamentos.Find(idExecucao);
            return execucao.TheMovieDbConfiguracao;
        }
    }
}
