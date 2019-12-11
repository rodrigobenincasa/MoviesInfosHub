using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DataBase.Models.Themoviedb
{
    public partial class TheMovieDbContext : DbContext
    {
        public TheMovieDbContext()
        {
        }

        public TheMovieDbContext(DbContextOptions<TheMovieDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CinemasStatus> CinemasStatus { get; set; }
        public virtual DbSet<ColecoesThemoviedb> ColecoesThemoviedb { get; set; }
        public virtual DbSet<CrewThemoviedb> CrewThemoviedb { get; set; }
        public virtual DbSet<Datas> Datas { get; set; }
        public virtual DbSet<Detalhes> Detalhes { get; set; }
        public virtual DbSet<Fatos> Fatos { get; set; }
        public virtual DbSet<FilmesCartazFila> FilmesCartazFila { get; set; }
        public virtual DbSet<FilmesFilas> FilmesFilas { get; set; }
        public virtual DbSet<FilmesFilasTipos> FilmesFilasTipos { get; set; }
        public virtual DbSet<FilmesThemoviedb> FilmesThemoviedb { get; set; }
        public virtual DbSet<Generos> Generos { get; set; }
        public virtual DbSet<GenerosGrupos> GenerosGrupos { get; set; }
        public virtual DbSet<GenerosThemoviedb> GenerosThemoviedb { get; set; }
        public virtual DbSet<LinguasThemoviedb> LinguasThemoviedb { get; set; }
        public virtual DbSet<Paises> Paises { get; set; }
        public virtual DbSet<PaisesProducoesThemoviedb> PaisesProducoesThemoviedb { get; set; }
        public virtual DbSet<Pessoas> Pessoas { get; set; }
        public virtual DbSet<PessoasGrupos> PessoasGrupos { get; set; }
        public virtual DbSet<ProcessamentosStatus> ProcessamentosStatus { get; set; }
        public virtual DbSet<ProducoesPaisesGrupos> ProducoesPaisesGrupos { get; set; }
        public virtual DbSet<Produtoras> Produtoras { get; set; }
        public virtual DbSet<ProdutorasGrupos> ProdutorasGrupos { get; set; }
        public virtual DbSet<ProdutorasThemoviedb> ProdutorasThemoviedb { get; set; }
        public virtual DbSet<TheMoviesDbConfiguracoes> TheMoviesDbConfiguracoes { get; set; }
        public virtual DbSet<TheMoviesDbConfiguracoesMapeamentos> TheMoviesDbConfiguracoesMapeamentos { get; set; }
        public virtual DbSet<TheMoviesDbConfiguracoesMapeamentosExecucoes> TheMoviesDbConfiguracoesMapeamentosExecucoes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=den1.mssql8.gear.host;Initial Catalog=moviesinfohub;Persist Security Info=True;User ID=moviesinfohub;Password=Qb9g3!~267sQ");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CinemasStatus>(entity =>
            {
                entity.HasKey(e => e.CinemaStatus);

                entity.ToTable("CinemasStatus", "Filmes");

                entity.Property(e => e.CinemaStatus).HasColumnName("cinemaStatus");

                entity.Property(e => e.Nome)
                    .HasColumnName("nome")
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ColecoesThemoviedb>(entity =>
            {
                entity.HasKey(e => e.Colecao);

                entity.ToTable("ColecoesThemoviedb", "FilmesStage");

                entity.Property(e => e.Colecao).HasColumnName("colecao");

                entity.Property(e => e.BackdropPath)
                    .IsRequired()
                    .HasColumnName("backdrop_path")
                    .IsUnicode(false);

                entity.Property(e => e.Filme).HasColumnName("filme");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .IsUnicode(false);

                entity.Property(e => e.PosterPath)
                    .IsRequired()
                    .HasColumnName("poster_path")
                    .IsUnicode(false);

                entity.HasOne(d => d.FilmeNavigation)
                    .WithMany(p => p.ColecoesThemoviedb)
                    .HasForeignKey(d => d.Filme)
                    .HasConstraintName("FK__ColecoesT__filme__38996AB5");
            });

            modelBuilder.Entity<CrewThemoviedb>(entity =>
            {
                entity.HasKey(e => e.Crew);

                entity.ToTable("CrewThemoviedb", "FilmesStage");

                entity.Property(e => e.Crew).HasColumnName("crew");

                entity.Property(e => e.CreditId)
                    .HasColumnName("credit_id")
                    .IsUnicode(false);

                entity.Property(e => e.Department)
                    .HasColumnName("department")
                    .IsUnicode(false);

                entity.Property(e => e.Filme).HasColumnName("filme");

                entity.Property(e => e.Gender).HasColumnName("gender");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Job)
                    .HasColumnName("job")
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .IsUnicode(false);

                entity.Property(e => e.ProfilePath)
                    .HasColumnName("profile_path")
                    .IsUnicode(false);

                entity.HasOne(d => d.FilmeNavigation)
                    .WithMany(p => p.CrewThemoviedb)
                    .HasForeignKey(d => d.Filme)
                    .HasConstraintName("FK__CrewThemo__filme__114A936A");
            });

            modelBuilder.Entity<Datas>(entity =>
            {
                entity.HasKey(e => e.Data);

                entity.ToTable("Datas", "Filmes");

                entity.Property(e => e.Data).HasColumnName("data");

                entity.Property(e => e.Ano).HasColumnName("ano");

                entity.Property(e => e.DataCompleta)
                    .HasColumnName("dataCompleta")
                    .HasColumnType("date");

                entity.Property(e => e.Dia).HasColumnName("dia");

                entity.Property(e => e.Mes).HasColumnName("mes");
            });

            modelBuilder.Entity<Detalhes>(entity =>
            {
                entity.HasKey(e => e.Filme);

                entity.ToTable("Detalhes", "Filmes");

                entity.Property(e => e.Filme).HasColumnName("filme");

                entity.Property(e => e.IdOrigem).HasColumnName("idOrigem");

                entity.Property(e => e.PosterUrl)
                    .HasColumnName("posterUrl")
                    .IsUnicode(false);

                entity.Property(e => e.Titulo)
                    .HasColumnName("titulo")
                    .IsUnicode(false);

                entity.Property(e => e.TituloOriginal)
                    .HasColumnName("tituloOriginal")
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Fatos>(entity =>
            {
                entity.HasKey(e => e.Filme);

                entity.ToTable("Fatos", "Filmes");

                entity.Property(e => e.Filme)
                    .HasColumnName("filme")
                    .ValueGeneratedNever();

                entity.Property(e => e.CinemaStatus).HasColumnName("cinemaStatus");

                entity.Property(e => e.GeneroGrupo).HasColumnName("generoGrupo");

                entity.Property(e => e.LancamentoData).HasColumnName("lancamentoData");

                entity.Property(e => e.Lucro)
                    .HasColumnName("lucro")
                    .HasColumnType("decimal(18, 0)");

                entity.Property(e => e.LucroProdutora)
                    .HasColumnName("lucroProdutora")
                    .HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Orcamento)
                    .HasColumnName("orcamento")
                    .HasColumnType("decimal(18, 0)");

                entity.Property(e => e.PessoaGrupo).HasColumnName("pessoaGrupo");

                entity.Property(e => e.ProducaoPaisGrupo).HasColumnName("producaoPaisGrupo");

                entity.Property(e => e.ProdutoraGrupo).HasColumnName("produtoraGrupo");

                entity.Property(e => e.Receita)
                    .HasColumnName("receita")
                    .HasColumnType("decimal(18, 0)");

                entity.Property(e => e.ReceitaProdutora)
                    .HasColumnName("receitaProdutora")
                    .HasColumnType("decimal(18, 0)");

                entity.Property(e => e.ReceitaRank).HasColumnName("receitaRank");

                entity.HasOne(d => d.CinemaStatusNavigation)
                    .WithMany(p => p.Fatos)
                    .HasForeignKey(d => d.CinemaStatus)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Fatos__cinemaSta__07C12930");

                entity.HasOne(d => d.FilmeNavigation)
                    .WithOne(p => p.Fatos)
                    .HasForeignKey<Fatos>(d => d.Filme)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Fatos__filme__08B54D69");

                entity.HasOne(d => d.LancamentoDataNavigation)
                    .WithMany(p => p.Fatos)
                    .HasForeignKey(d => d.LancamentoData)
                    .HasConstraintName("FK__Fatos__lancament__09A971A2");
            });

            modelBuilder.Entity<FilmesCartazFila>(entity =>
            {
                entity.HasKey(e => e.FilemCartazFila);

                entity.ToTable("FilmesCartazFila", "FilmesStage");

                entity.Property(e => e.FilemCartazFila).HasColumnName("filemCartazFila");

                entity.Property(e => e.DataHora)
                    .HasColumnName("dataHora")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .IsUnicode(false);

                entity.Property(e => e.OrigemServico)
                    .HasColumnName("origemServico")
                    .IsUnicode(false);

                entity.Property(e => e.ProcessamentoMensagem)
                    .HasColumnName("processamentoMensagem")
                    .IsUnicode(false);

                entity.Property(e => e.ProcessamentoStatus).HasColumnName("processamentoStatus");

                entity.HasOne(d => d.ProcessamentoStatusNavigation)
                    .WithMany(p => p.FilmesCartazFila)
                    .HasForeignKey(d => d.ProcessamentoStatus)
                    .HasConstraintName("FK__FilmesCar__proce__66603565");
            });

            modelBuilder.Entity<FilmesFilas>(entity =>
            {
                entity.HasKey(e => e.FilmeFila);

                entity.ToTable("FilmesFilas", "FilmesStage");

                entity.Property(e => e.FilmeFila).HasColumnName("filmeFila");

                entity.Property(e => e.DataHora)
                    .HasColumnName("dataHora")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FilmeFilaTipo).HasColumnName("filmeFilaTipo");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .IsUnicode(false);

                entity.Property(e => e.OrigemServico)
                    .HasColumnName("origemServico")
                    .IsUnicode(false);

                entity.Property(e => e.ProcessamentoMensagem)
                    .HasColumnName("processamentoMensagem")
                    .IsUnicode(false);

                entity.Property(e => e.ProcessamentoStatus).HasColumnName("processamentoStatus");

                entity.HasOne(d => d.FilmeFilaTipoNavigation)
                    .WithMany(p => p.FilmesFilas)
                    .HasForeignKey(d => d.FilmeFilaTipo)
                    .HasConstraintName("FK__FilmesFil__filme__5629CD9C");
            });

            modelBuilder.Entity<FilmesFilasTipos>(entity =>
            {
                entity.HasKey(e => e.FilmeFilaTipo);

                entity.ToTable("FilmesFilasTipos", "FilmesStage");

                entity.Property(e => e.FilmeFilaTipo).HasColumnName("filmeFilaTipo");

                entity.Property(e => e.Nome)
                    .HasColumnName("nome")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<FilmesThemoviedb>(entity =>
            {
                entity.HasKey(e => e.Filme);

                entity.ToTable("FilmesThemoviedb", "FilmesStage");

                entity.Property(e => e.Filme).HasColumnName("filme");

                entity.Property(e => e.Adult)
                    .HasColumnName("adult")
                    .IsUnicode(false);

                entity.Property(e => e.BackdropPath)
                    .HasColumnName("backdrop_path")
                    .IsUnicode(false);

                entity.Property(e => e.Budget).HasColumnName("budget");

                entity.Property(e => e.CinemaStatus).HasColumnName("cinemaStatus");

                entity.Property(e => e.Homepage)
                    .HasColumnName("homepage")
                    .IsUnicode(false);

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .IsUnicode(false);

                entity.Property(e => e.ImdbId)
                    .HasColumnName("imdb_id")
                    .IsUnicode(false);

                entity.Property(e => e.OriginalLanguage)
                    .HasColumnName("original_language")
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.OriginalTitle)
                    .HasColumnName("original_title")
                    .IsUnicode(false);

                entity.Property(e => e.Overview)
                    .HasColumnName("overview")
                    .IsUnicode(false);

                entity.Property(e => e.Popularity)
                    .HasColumnName("popularity")
                    .HasColumnType("numeric(7, 3)");

                entity.Property(e => e.PosterPath)
                    .HasColumnName("poster_path")
                    .IsUnicode(false);

                entity.Property(e => e.ReleaseDate)
                    .HasColumnName("release_date")
                    .HasColumnType("date");

                entity.Property(e => e.Revenue).HasColumnName("revenue");

                entity.Property(e => e.Runtime).HasColumnName("runtime");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .IsUnicode(false);

                entity.Property(e => e.Tagline)
                    .HasColumnName("tagline")
                    .IsUnicode(false);

                entity.Property(e => e.Title)
                    .HasColumnName("title")
                    .IsUnicode(false);

                entity.Property(e => e.Video)
                    .HasColumnName("video")
                    .IsUnicode(false);

                entity.Property(e => e.VoteAverage)
                    .HasColumnName("vote_average")
                    .HasColumnType("numeric(3, 1)");

                entity.Property(e => e.VoteCount).HasColumnName("vote_count");
            });

            modelBuilder.Entity<Generos>(entity =>
            {
                entity.HasKey(e => e.Genero);

                entity.ToTable("Generos", "Filmes");

                entity.Property(e => e.Genero).HasColumnName("genero");

                entity.Property(e => e.IdOrigem).HasColumnName("idOrigem");

                entity.Property(e => e.Nome)
                    .HasColumnName("nome")
                    .IsUnicode(false);
            });

            modelBuilder.Entity<GenerosGrupos>(entity =>
            {
                entity.HasKey(e => e.GeneroGrupo);

                entity.ToTable("GenerosGrupos", "Filmes");

                entity.HasIndex(e => e.Genero)
                    .HasName("IFK_Filmes_Genero");

                entity.HasIndex(e => e.IdOrigem);

                entity.Property(e => e.GeneroGrupo).HasColumnName("generoGrupo");

                entity.Property(e => e.Genero).HasColumnName("genero");

                entity.Property(e => e.Grupo).HasColumnName("grupo");

                entity.Property(e => e.IdOrigem).HasColumnName("idOrigem");

                entity.HasOne(d => d.GeneroNavigation)
                    .WithMany(p => p.GenerosGrupos)
                    .HasForeignKey(d => d.Genero)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__GenerosGr__gener__7B5B524B");
            });

            modelBuilder.Entity<GenerosThemoviedb>(entity =>
            {
                entity.HasKey(e => e.Genero);

                entity.ToTable("GenerosThemoviedb", "FilmesStage");

                entity.Property(e => e.Genero).HasColumnName("genero");

                entity.Property(e => e.Filme).HasColumnName("filme");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .IsUnicode(false);

                entity.HasOne(d => d.FilmeNavigation)
                    .WithMany(p => p.GenerosThemoviedb)
                    .HasForeignKey(d => d.Filme)
                    .HasConstraintName("FK__GenerosTh__filme__48CFD27E");
            });

            modelBuilder.Entity<LinguasThemoviedb>(entity =>
            {
                entity.HasKey(e => e.Lingua);

                entity.ToTable("LinguasThemoviedb", "FilmesStage");

                entity.Property(e => e.Lingua).HasColumnName("lingua");

                entity.Property(e => e.Filme).HasColumnName("filme");

                entity.Property(e => e.Iso6391)
                    .HasColumnName("iso_639_1")
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .IsUnicode(false);

                entity.HasOne(d => d.FilmeNavigation)
                    .WithMany(p => p.LinguasThemoviedb)
                    .HasForeignKey(d => d.Filme)
                    .HasConstraintName("FK__LinguasTh__filme__45F365D3");
            });

            modelBuilder.Entity<Paises>(entity =>
            {
                entity.HasKey(e => e.Pais);

                entity.ToTable("Paises", "Filmes");

                entity.Property(e => e.Pais).HasColumnName("pais");

                entity.Property(e => e.IdOrigem).HasColumnName("idOrigem");

                entity.Property(e => e.Nome)
                    .HasColumnName("nome")
                    .IsUnicode(false);

                entity.Property(e => e.Sigla)
                    .HasColumnName("sigla")
                    .HasMaxLength(2)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PaisesProducoesThemoviedb>(entity =>
            {
                entity.HasKey(e => e.PaisProducao);

                entity.ToTable("PaisesProducoesThemoviedb", "FilmesStage");

                entity.Property(e => e.Filme).HasColumnName("filme");

                entity.Property(e => e.Iso31661)
                    .HasColumnName("iso_3166_1")
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .IsUnicode(false);

                entity.HasOne(d => d.FilmeNavigation)
                    .WithMany(p => p.PaisesProducoesThemoviedb)
                    .HasForeignKey(d => d.Filme)
                    .HasConstraintName("FK__PaisesPro__filme__4316F928");
            });

            modelBuilder.Entity<Pessoas>(entity =>
            {
                entity.HasKey(e => e.Pessoa);

                entity.ToTable("Pessoas", "Filmes");

                entity.Property(e => e.Pessoa).HasColumnName("pessoa");

                entity.Property(e => e.Departamento)
                    .HasColumnName("departamento")
                    .IsUnicode(false);

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IdOrigem).HasColumnName("idOrigem");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .IsUnicode(false);

                entity.Property(e => e.ProfilePath)
                    .HasColumnName("profilePath")
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PessoasGrupos>(entity =>
            {
                entity.HasKey(e => e.PessoaGrupo);

                entity.ToTable("PessoasGrupos", "Filmes");

                entity.Property(e => e.PessoaGrupo).HasColumnName("pessoaGrupo");

                entity.Property(e => e.Grupo).HasColumnName("grupo");

                entity.Property(e => e.IdOrigem).HasColumnName("idOrigem");

                entity.Property(e => e.Pessoa).HasColumnName("pessoa");

                entity.HasOne(d => d.PessoaNavigation)
                    .WithMany(p => p.PessoasGrupos)
                    .HasForeignKey(d => d.Pessoa)
                    .HasConstraintName("FK__PessoasGr__pesso__160F4887");
            });

            modelBuilder.Entity<ProcessamentosStatus>(entity =>
            {
                entity.HasKey(e => e.ProcessamentoStatus);

                entity.Property(e => e.ProcessamentoStatus).HasColumnName("processamentoStatus");

                entity.Property(e => e.Descricao)
                    .HasColumnName("descricao")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ProducoesPaisesGrupos>(entity =>
            {
                entity.HasKey(e => e.ProducaoPaisGrupo);

                entity.ToTable("ProducoesPaisesGrupos", "Filmes");

                entity.HasIndex(e => e.IdOrigem);

                entity.HasIndex(e => e.Pais)
                    .HasName("ProducoesPaisesGrupos_FKIndex1");

                entity.Property(e => e.ProducaoPaisGrupo).HasColumnName("producaoPaisGrupo");

                entity.Property(e => e.Grupo).HasColumnName("grupo");

                entity.Property(e => e.IdOrigem).HasColumnName("idOrigem");

                entity.Property(e => e.Pais).HasColumnName("pais");

                entity.HasOne(d => d.PaisNavigation)
                    .WithMany(p => p.ProducoesPaisesGrupos)
                    .HasForeignKey(d => d.Pais)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ProducoesP__pais__787EE5A0");
            });

            modelBuilder.Entity<Produtoras>(entity =>
            {
                entity.HasKey(e => e.Produtora);

                entity.ToTable("Produtoras", "Filmes");

                entity.Property(e => e.Produtora).HasColumnName("produtora");

                entity.Property(e => e.Descricao)
                    .HasColumnName("descricao")
                    .IsUnicode(false);

                entity.Property(e => e.IdOrigem).HasColumnName("idOrigem");
            });

            modelBuilder.Entity<ProdutorasGrupos>(entity =>
            {
                entity.HasKey(e => e.ProdutoraGrupo);

                entity.ToTable("ProdutorasGrupos", "Filmes");

                entity.HasIndex(e => e.IdOrigem);

                entity.HasIndex(e => e.Produtora)
                    .HasName("ProdutorasGrupo_FKIndex1");

                entity.Property(e => e.ProdutoraGrupo).HasColumnName("produtoraGrupo");

                entity.Property(e => e.Grupo).HasColumnName("grupo");

                entity.Property(e => e.IdOrigem).HasColumnName("idOrigem");

                entity.Property(e => e.Produtora).HasColumnName("produtora");

                entity.HasOne(d => d.ProdutoraNavigation)
                    .WithMany(p => p.ProdutorasGrupos)
                    .HasForeignKey(d => d.Produtora)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Produtora__produ__75A278F5");
            });

            modelBuilder.Entity<ProdutorasThemoviedb>(entity =>
            {
                entity.HasKey(e => e.Produtora);

                entity.ToTable("ProdutorasThemoviedb", "FilmesStage");

                entity.Property(e => e.Filme).HasColumnName("filme");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.LogoPath)
                    .HasColumnName("logo_path")
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .IsUnicode(false);

                entity.Property(e => e.OriginCountry)
                    .HasColumnName("origin_country")
                    .IsUnicode(false);

                entity.HasOne(d => d.FilmeNavigation)
                    .WithMany(p => p.ProdutorasThemoviedb)
                    .HasForeignKey(d => d.Filme)
                    .HasConstraintName("FK__Produtora__filme__403A8C7D");
            });

            modelBuilder.Entity<TheMoviesDbConfiguracoes>(entity =>
            {
                entity.HasKey(e => e.TheMovieDbConfiguracao);

                entity.Property(e => e.TheMovieDbConfiguracao).HasColumnName("theMovieDbConfiguracao");

                entity.Property(e => e.GetDiretores)
                    .HasColumnName("getDiretores")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Metodo)
                    .HasColumnName("metodo")
                    .IsUnicode(false);

                entity.Property(e => e.Nome)
                    .HasColumnName("nome")
                    .IsUnicode(false);

                entity.Property(e => e.Servico)
                    .HasColumnName("servico")
                    .IsUnicode(false);

                entity.Property(e => e.Url)
                    .HasColumnName("url")
                    .IsUnicode(false);

                entity.Property(e => e.UrlComplemento)
                    .HasColumnName("urlComplemento")
                    .IsUnicode(false);

                entity.Property(e => e.UrlFiltro)
                    .HasColumnName("urlFiltro")
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TheMoviesDbConfiguracoesMapeamentos>(entity =>
            {
                entity.HasKey(e => e.TheMovieDbConfiguracaoMapeamento);

                entity.Property(e => e.TheMovieDbConfiguracaoMapeamento).HasColumnName("theMovieDbConfiguracaoMapeamento");

                entity.Property(e => e.Ordenacao).HasColumnName("ordenacao");

                entity.Property(e => e.TheMovieDbConfiguracao).HasColumnName("theMovieDbConfiguracao");

                entity.HasOne(d => d.TheMovieDbConfiguracaoNavigation)
                    .WithMany(p => p.TheMoviesDbConfiguracoesMapeamentos)
                    .HasForeignKey(d => d.TheMovieDbConfiguracao)
                    .HasConstraintName("FK__TheMovies__theMo__1EA48E88");
            });

            modelBuilder.Entity<TheMoviesDbConfiguracoesMapeamentosExecucoes>(entity =>
            {
                entity.HasKey(e => e.TheMovieDbConfiguracaoMapeamentoExecucao);

                entity.Property(e => e.TheMovieDbConfiguracaoMapeamentoExecucao).HasColumnName("theMovieDbConfiguracaoMapeamentoExecucao");

                entity.Property(e => e.DataHora)
                    .HasColumnName("dataHora")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ProcessamentoMensagem)
                    .HasColumnName("processamentoMensagem")
                    .IsUnicode(false);

                entity.Property(e => e.ProcessamentoStatus).HasColumnName("processamentoStatus");

                entity.Property(e => e.TheMovieDbConfiguracaoMapeamento).HasColumnName("theMovieDbConfiguracaoMapeamento");

                entity.HasOne(d => d.ProcessamentoStatusNavigation)
                    .WithMany(p => p.TheMoviesDbConfiguracoesMapeamentosExecucoes)
                    .HasForeignKey(d => d.ProcessamentoStatus)
                    .HasConstraintName("FK__TheMovies__proce__22751F6C");

                entity.HasOne(d => d.TheMovieDbConfiguracaoMapeamentoNavigation)
                    .WithMany(p => p.TheMoviesDbConfiguracoesMapeamentosExecucoes)
                    .HasForeignKey(d => d.TheMovieDbConfiguracaoMapeamento)
                    .HasConstraintName("FK__TheMovies__theMo__2180FB33");
            });
        }
    }
}
