using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.TheMovieDb
{
    public interface ITheMoviesDbConfiguracoesRepository<TheMoviesDbConfiguracoesMapeamentosExecucoes>
    {
        List<TheMoviesDbConfiguracoesMapeamentosExecucoes> GetAll();
        void Start();
        List<TheMoviesDbConfiguracoesMapeamentosExecucoes> GetStepsNaoProcessados();
        void SetStatusExecucao(TheMoviesDbConfiguracoesMapeamentosExecucoes execucao, int processamentoStatus, string processamentoMensagem);
    }
}
