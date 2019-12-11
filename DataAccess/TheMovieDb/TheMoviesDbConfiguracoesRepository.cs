using DataBase.Models.Themoviedb;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace DataAccess.TheMovieDb
{
    public class TheMoviesDbConfiguracoesRepository<T> : ITheMoviesDbConfiguracoesRepository<TheMoviesDbConfiguracoesMapeamentosExecucoes>
    {
        private TheMovieDbContext context = null;

        public TheMoviesDbConfiguracoesRepository()
        {
            context = new TheMovieDbContext();
        }

        public TheMoviesDbConfiguracoesRepository(TheMovieDbContext context)
        {
            this.context = context;
        }

        public List<TheMoviesDbConfiguracoesMapeamentosExecucoes> GetAll()
        {
            return context.TheMoviesDbConfiguracoesMapeamentosExecucoes.ToList();
        }

        public void Start()
        {
            using (var context = new TheMovieDbContext())
            {
                SqlConnection connection = (SqlConnection)context.Database.GetDbConnection();

                connection.Open();
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "TheMoviesDbConfiguracoesMapeamentosExecucoesInicia";

                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public List<TheMoviesDbConfiguracoesMapeamentosExecucoes> GetStepsNaoProcessados()
        {
            return context.TheMoviesDbConfiguracoesMapeamentosExecucoes
                            .Where(w => w.ProcessamentoStatus == 1)
                            .ToList();
        }

        public void SetStatusExecucao(TheMoviesDbConfiguracoesMapeamentosExecucoes execucao, int processamentoStatus, string processamentoMensagem)
        {
            execucao.ProcessamentoStatus   = processamentoStatus;
            execucao.ProcessamentoMensagem = processamentoMensagem;
            execucao.DataHora              = DateTime.Now;

            context.Update(execucao);
            context.SaveChanges();
        }
    }
}
