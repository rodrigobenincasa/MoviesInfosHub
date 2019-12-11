using DataBase.Models.Themoviedb;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.TheMovieDb
{
    public interface IFilmesThemoviedbRepository<FilmesThemoviedb>
    {
        List<FilmesThemoviedb> GetAll();
        long InsertFilmesThemoviedbReturnIdentity(FilmesThemoviedb filme);
    }
}
