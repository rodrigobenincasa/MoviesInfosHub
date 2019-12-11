using App;
using DataAccess.TheMovieDb;
using DataBase.Models.Themoviedb;
using System;
using System.Collections.Generic;

namespace TheMovieDb
{
    class Program
    {
        static void Main(string[] args)
        {
            ITheMoviesDbConfiguracoesRepository<TheMoviesDbConfiguracoesMapeamentosExecucoes> execucao = new TheMoviesDbConfiguracoesRepository<TheMoviesDbConfiguracoesMapeamentosExecucoes>();
            ITheMoviesDbConfiguracoesMapeamentosRepository<TheMoviesDbConfiguracoesMapeamentos> mapeamento = new TheMoviesDbConfiguracoesMapeamentosRepository<TheMoviesDbConfiguracoesMapeamentos>();
            execucao.Start();


            List<TheMoviesDbConfiguracoesMapeamentosExecucoes> execucoesProcessamento = execucao.GetStepsNaoProcessados();
            long? idConfig = null;

            foreach (var item in execucoesProcessamento)
            {
                try
                {
                    idConfig = mapeamento.GetIdByExecution(item.TheMovieDbConfiguracaoMapeamento);

                    switch (idConfig)
                    {
                        case 1:
                            Console.WriteLine("Start of aquiring Queue at {0} from {1}..."
                                , DateTime.Now, idConfig
                            );
                            TheMovieDbAccess.SetQueueNowPlaying();
                            break;
                        case 2:
                            Console.WriteLine("Start of aquiring Queue at {0} from {1}..."
                                , DateTime.Now, idConfig
                            );
                            TheMovieDbAccess.SetQueueUpcoming();
                            break;
                        case 3:
                            Console.WriteLine("Start of aquiring Queue at {0} from {1}..."
                                , DateTime.Now, idConfig
                            );
                            TheMovieDbAccess.SetQueueGenres();
                            break;
                        case 4:
                            Console.WriteLine("Start of aquiring Queue at {0} from {1}..."
                                , DateTime.Now, idConfig
                            );
                            TheMovieDbAccess.SetQueuProductionCompanies();
                            break;
                        case 5:
                            Console.WriteLine("Start of aquiring Queue at {0} from {1}..."
                                , DateTime.Now, idConfig
                            );
                            TheMovieDbAccess.SetQueuDirectors();
                            break;
                        case 6:
                            Console.WriteLine("Start processing Queue from data at {0}...", DateTime.Now);
                            TheMovieDbAccess.ExecQueue();
                            break;

                        default:
                            break;
                    }

                    execucao.SetStatusExecucao(item, 3, "Processado com sucesso.");
                }
                catch (Exception erro)
                {
                    execucao.SetStatusExecucao(item, 2, erro.Message);
                    continue;
                }
            }


            //Console.WriteLine("Start of aquiring Queue at {0}...", DateTime.Now);
            //TheMovieDbAccess.SetQueueNowPlaying();
            //TheMovieDbAccess.SetQueueUpcoming();
            //Console.WriteLine("End of aquiring Queue at {0}.", DateTime.Now);

            //Console.WriteLine("Start processing Queue at {0}...", DateTime.Now);
            //TheMovieDbAccess.ExecQueue();
            //Console.WriteLine("End processing Queue at {0}.", DateTime.Now);

            //Console.WriteLine("Start aquiring Queue from data at {0}...", DateTime.Now);
            //TheMovieDbAccess.SetQueueGenres();
            //TheMovieDbAccess.SetQueuProductionCompanies();
            ////TheMovieDbAccess.SetQueuDirectors();
            //Console.WriteLine("End aquiring Queue from data at {0}.", DateTime.Now);

            //Console.WriteLine("Start processing Queue from data at {0}...", DateTime.Now);
            //TheMovieDbAccess.ExecQueue();
            //Console.WriteLine("End processing Queue from data  at {0}.", DateTime.Now);
        }
    }
}
