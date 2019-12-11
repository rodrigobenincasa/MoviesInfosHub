using DataBase.Models.Themoviedb;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace QueueAdm
{
    public class Queue
    {
        public static List<FilmesCartazFila> GetPending()
        {
            using (var context = new TheMovieDbContext())
            {
                List<FilmesCartazFila> filmesCartasFila = context.FilmesCartazFila
                                                            .Where(w => w.ProcessamentoStatus == 1)
                                                            .ToList();

                return filmesCartasFila;
            }              
        }

        public static void QueueDedup()
        {
            using (var context = new TheMovieDbContext())
            {
                SqlConnection connection = (SqlConnection)context.Database.GetDbConnection();

                connection.Open();
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "FilmesCartazFilaDedup";

                command.ExecuteNonQuery();
                connection.Close();
            }                
        }

        public static void QueueResult(FilmesCartazFila queue, int processamentoStatus, string processamentoMensagem)
        {
            using (var context = new TheMovieDbContext())
            {
                queue.ProcessamentoStatus   = processamentoStatus;
                queue.ProcessamentoMensagem = processamentoMensagem;
                context.Update(queue);
                context.SaveChanges();
             }
        }
    }
}
