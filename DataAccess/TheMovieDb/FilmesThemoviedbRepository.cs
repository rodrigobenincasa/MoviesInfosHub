using DataBase.Models.Themoviedb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.TheMovieDb
{
    public class FilmesThemoviedbRepository<T> : IFilmesThemoviedbRepository<FilmesThemoviedb>
    {
        private TheMovieDbContext context = null;

        public FilmesThemoviedbRepository()
        {
            context = new TheMovieDbContext();
        }

        public FilmesThemoviedbRepository(TheMovieDbContext context)
        {
            this.context = context;
        }

        public List<FilmesThemoviedb> GetAll()
        {
            return context.FilmesThemoviedb.ToList();
        }

        public long InsertFilmesThemoviedbReturnIdentity(FilmesThemoviedb filme)
        {
            context.Add(filme);
            context.SaveChanges();

            return filme.Filme;
        }
    }
}
