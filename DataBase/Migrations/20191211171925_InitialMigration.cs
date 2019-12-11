using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataBase.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Filmes");

            migrationBuilder.EnsureSchema(
                name: "FilmesStage");

            migrationBuilder.CreateTable(
                name: "ProcessamentosStatus",
                columns: table => new
                {
                    processamentoStatus = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    descricao = table.Column<string>(unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProcessamentosStatus", x => x.processamentoStatus);
                });

            migrationBuilder.CreateTable(
                name: "TheMoviesDbConfiguracoes",
                columns: table => new
                {
                    theMovieDbConfiguracao = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    nome = table.Column<string>(unicode: false, nullable: true),
                    url = table.Column<string>(unicode: false, nullable: true),
                    urlFiltro = table.Column<string>(unicode: false, nullable: true),
                    urlComplemento = table.Column<string>(unicode: false, nullable: true),
                    getDiretores = table.Column<bool>(nullable: true, defaultValueSql: "((0))"),
                    servico = table.Column<string>(unicode: false, nullable: true),
                    metodo = table.Column<string>(unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TheMoviesDbConfiguracoes", x => x.theMovieDbConfiguracao);
                });

            migrationBuilder.CreateTable(
                name: "CinemasStatus",
                schema: "Filmes",
                columns: table => new
                {
                    cinemaStatus = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    nome = table.Column<string>(unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CinemasStatus", x => x.cinemaStatus);
                });

            migrationBuilder.CreateTable(
                name: "Datas",
                schema: "Filmes",
                columns: table => new
                {
                    data = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    dia = table.Column<int>(nullable: true),
                    mes = table.Column<int>(nullable: true),
                    ano = table.Column<int>(nullable: true),
                    dataCompleta = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Datas", x => x.data);
                });

            migrationBuilder.CreateTable(
                name: "Detalhes",
                schema: "Filmes",
                columns: table => new
                {
                    filme = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    titulo = table.Column<string>(unicode: false, nullable: true),
                    idOrigem = table.Column<long>(nullable: true),
                    tituloOriginal = table.Column<string>(unicode: false, nullable: true),
                    posterUrl = table.Column<string>(unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Detalhes", x => x.filme);
                });

            migrationBuilder.CreateTable(
                name: "Generos",
                schema: "Filmes",
                columns: table => new
                {
                    genero = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    nome = table.Column<string>(unicode: false, nullable: true),
                    idOrigem = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Generos", x => x.genero);
                });

            migrationBuilder.CreateTable(
                name: "Paises",
                schema: "Filmes",
                columns: table => new
                {
                    pais = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    nome = table.Column<string>(unicode: false, nullable: true),
                    sigla = table.Column<string>(unicode: false, maxLength: 2, nullable: true),
                    idOrigem = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paises", x => x.pais);
                });

            migrationBuilder.CreateTable(
                name: "Pessoas",
                schema: "Filmes",
                columns: table => new
                {
                    pessoa = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    departamento = table.Column<string>(unicode: false, nullable: true),
                    id = table.Column<int>(nullable: true),
                    name = table.Column<string>(unicode: false, nullable: true),
                    profilePath = table.Column<string>(unicode: false, nullable: true),
                    idOrigem = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pessoas", x => x.pessoa);
                });

            migrationBuilder.CreateTable(
                name: "Produtoras",
                schema: "Filmes",
                columns: table => new
                {
                    produtora = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    descricao = table.Column<string>(unicode: false, nullable: true),
                    idOrigem = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtoras", x => x.produtora);
                });

            migrationBuilder.CreateTable(
                name: "FilmesFilasTipos",
                schema: "FilmesStage",
                columns: table => new
                {
                    filmeFilaTipo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    nome = table.Column<string>(unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilmesFilasTipos", x => x.filmeFilaTipo);
                });

            migrationBuilder.CreateTable(
                name: "FilmesThemoviedb",
                schema: "FilmesStage",
                columns: table => new
                {
                    filme = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    adult = table.Column<string>(unicode: false, nullable: true),
                    backdrop_path = table.Column<string>(unicode: false, nullable: true),
                    homepage = table.Column<string>(unicode: false, nullable: true),
                    id = table.Column<string>(unicode: false, nullable: true),
                    imdb_id = table.Column<string>(unicode: false, nullable: true),
                    original_language = table.Column<string>(unicode: false, maxLength: 2, nullable: true),
                    original_title = table.Column<string>(unicode: false, nullable: true),
                    overview = table.Column<string>(unicode: false, nullable: true),
                    popularity = table.Column<decimal>(type: "numeric(7, 3)", nullable: true),
                    poster_path = table.Column<string>(unicode: false, nullable: true),
                    release_date = table.Column<DateTime>(type: "date", nullable: true),
                    revenue = table.Column<int>(nullable: true),
                    runtime = table.Column<int>(nullable: true),
                    status = table.Column<string>(unicode: false, nullable: true),
                    tagline = table.Column<string>(unicode: false, nullable: true),
                    title = table.Column<string>(unicode: false, nullable: true),
                    video = table.Column<string>(unicode: false, nullable: true),
                    vote_average = table.Column<decimal>(type: "numeric(3, 1)", nullable: true),
                    vote_count = table.Column<int>(nullable: true),
                    budget = table.Column<double>(nullable: true),
                    cinemaStatus = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilmesThemoviedb", x => x.filme);
                });

            migrationBuilder.CreateTable(
                name: "FilmesCartazFila",
                schema: "FilmesStage",
                columns: table => new
                {
                    filemCartazFila = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    id = table.Column<string>(unicode: false, nullable: true),
                    processamentoStatus = table.Column<int>(nullable: true),
                    dataHora = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    processamentoMensagem = table.Column<string>(unicode: false, nullable: true),
                    origemServico = table.Column<string>(unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilmesCartazFila", x => x.filemCartazFila);
                    table.ForeignKey(
                        name: "FK__FilmesCar__proce__66603565",
                        column: x => x.processamentoStatus,
                        principalTable: "ProcessamentosStatus",
                        principalColumn: "processamentoStatus",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TheMoviesDbConfiguracoesMapeamentos",
                columns: table => new
                {
                    theMovieDbConfiguracaoMapeamento = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    theMovieDbConfiguracao = table.Column<long>(nullable: true),
                    ordenacao = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TheMoviesDbConfiguracoesMapeamentos", x => x.theMovieDbConfiguracaoMapeamento);
                    table.ForeignKey(
                        name: "FK__TheMovies__theMo__1EA48E88",
                        column: x => x.theMovieDbConfiguracao,
                        principalTable: "TheMoviesDbConfiguracoes",
                        principalColumn: "theMovieDbConfiguracao",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Fatos",
                schema: "Filmes",
                columns: table => new
                {
                    filme = table.Column<int>(nullable: false),
                    lancamentoData = table.Column<int>(nullable: true),
                    cinemaStatus = table.Column<int>(nullable: false),
                    producaoPaisGrupo = table.Column<int>(nullable: true),
                    generoGrupo = table.Column<int>(nullable: true),
                    produtoraGrupo = table.Column<int>(nullable: true),
                    orcamento = table.Column<decimal>(type: "decimal(18, 0)", nullable: true),
                    receita = table.Column<decimal>(type: "decimal(18, 0)", nullable: true),
                    lucro = table.Column<decimal>(type: "decimal(18, 0)", nullable: true),
                    receitaRank = table.Column<int>(nullable: true),
                    receitaProdutora = table.Column<decimal>(type: "decimal(18, 0)", nullable: true),
                    lucroProdutora = table.Column<decimal>(type: "decimal(18, 0)", nullable: true),
                    pessoaGrupo = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fatos", x => x.filme);
                    table.ForeignKey(
                        name: "FK__Fatos__cinemaSta__07C12930",
                        column: x => x.cinemaStatus,
                        principalSchema: "Filmes",
                        principalTable: "CinemasStatus",
                        principalColumn: "cinemaStatus",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Fatos__filme__08B54D69",
                        column: x => x.filme,
                        principalSchema: "Filmes",
                        principalTable: "Detalhes",
                        principalColumn: "filme",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Fatos__lancament__09A971A2",
                        column: x => x.lancamentoData,
                        principalSchema: "Filmes",
                        principalTable: "Datas",
                        principalColumn: "data",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GenerosGrupos",
                schema: "Filmes",
                columns: table => new
                {
                    generoGrupo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    genero = table.Column<int>(nullable: false),
                    idOrigem = table.Column<int>(nullable: true),
                    grupo = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenerosGrupos", x => x.generoGrupo);
                    table.ForeignKey(
                        name: "FK__GenerosGr__gener__7B5B524B",
                        column: x => x.genero,
                        principalSchema: "Filmes",
                        principalTable: "Generos",
                        principalColumn: "genero",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProducoesPaisesGrupos",
                schema: "Filmes",
                columns: table => new
                {
                    producaoPaisGrupo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    pais = table.Column<int>(nullable: false),
                    idOrigem = table.Column<int>(nullable: true),
                    grupo = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProducoesPaisesGrupos", x => x.producaoPaisGrupo);
                    table.ForeignKey(
                        name: "FK__ProducoesP__pais__787EE5A0",
                        column: x => x.pais,
                        principalSchema: "Filmes",
                        principalTable: "Paises",
                        principalColumn: "pais",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PessoasGrupos",
                schema: "Filmes",
                columns: table => new
                {
                    pessoaGrupo = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    pessoa = table.Column<long>(nullable: true),
                    idOrigem = table.Column<int>(nullable: true),
                    grupo = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PessoasGrupos", x => x.pessoaGrupo);
                    table.ForeignKey(
                        name: "FK__PessoasGr__pesso__160F4887",
                        column: x => x.pessoa,
                        principalSchema: "Filmes",
                        principalTable: "Pessoas",
                        principalColumn: "pessoa",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProdutorasGrupos",
                schema: "Filmes",
                columns: table => new
                {
                    produtoraGrupo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    produtora = table.Column<int>(nullable: false),
                    idOrigem = table.Column<int>(nullable: true),
                    grupo = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProdutorasGrupos", x => x.produtoraGrupo);
                    table.ForeignKey(
                        name: "FK__Produtora__produ__75A278F5",
                        column: x => x.produtora,
                        principalSchema: "Filmes",
                        principalTable: "Produtoras",
                        principalColumn: "produtora",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FilmesFilas",
                schema: "FilmesStage",
                columns: table => new
                {
                    filmeFila = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    id = table.Column<string>(unicode: false, nullable: true),
                    processamentoStatus = table.Column<int>(nullable: true),
                    dataHora = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    processamentoMensagem = table.Column<string>(unicode: false, nullable: true),
                    origemServico = table.Column<string>(unicode: false, nullable: true),
                    filmeFilaTipo = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilmesFilas", x => x.filmeFila);
                    table.ForeignKey(
                        name: "FK__FilmesFil__filme__5629CD9C",
                        column: x => x.filmeFilaTipo,
                        principalSchema: "FilmesStage",
                        principalTable: "FilmesFilasTipos",
                        principalColumn: "filmeFilaTipo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ColecoesThemoviedb",
                schema: "FilmesStage",
                columns: table => new
                {
                    colecao = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    filme = table.Column<long>(nullable: true),
                    id = table.Column<int>(nullable: false),
                    name = table.Column<string>(unicode: false, nullable: false),
                    poster_path = table.Column<string>(unicode: false, nullable: false),
                    backdrop_path = table.Column<string>(unicode: false, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ColecoesThemoviedb", x => x.colecao);
                    table.ForeignKey(
                        name: "FK__ColecoesT__filme__38996AB5",
                        column: x => x.filme,
                        principalSchema: "FilmesStage",
                        principalTable: "FilmesThemoviedb",
                        principalColumn: "filme",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CrewThemoviedb",
                schema: "FilmesStage",
                columns: table => new
                {
                    crew = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    filme = table.Column<long>(nullable: true),
                    credit_id = table.Column<string>(unicode: false, nullable: true),
                    department = table.Column<string>(unicode: false, nullable: true),
                    gender = table.Column<int>(nullable: true),
                    id = table.Column<int>(nullable: true),
                    job = table.Column<string>(unicode: false, nullable: true),
                    name = table.Column<string>(unicode: false, nullable: true),
                    profile_path = table.Column<string>(unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CrewThemoviedb", x => x.crew);
                    table.ForeignKey(
                        name: "FK__CrewThemo__filme__114A936A",
                        column: x => x.filme,
                        principalSchema: "FilmesStage",
                        principalTable: "FilmesThemoviedb",
                        principalColumn: "filme",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GenerosThemoviedb",
                schema: "FilmesStage",
                columns: table => new
                {
                    genero = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    filme = table.Column<long>(nullable: true),
                    id = table.Column<int>(nullable: true),
                    name = table.Column<string>(unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenerosThemoviedb", x => x.genero);
                    table.ForeignKey(
                        name: "FK__GenerosTh__filme__48CFD27E",
                        column: x => x.filme,
                        principalSchema: "FilmesStage",
                        principalTable: "FilmesThemoviedb",
                        principalColumn: "filme",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LinguasThemoviedb",
                schema: "FilmesStage",
                columns: table => new
                {
                    lingua = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    filme = table.Column<long>(nullable: true),
                    iso_639_1 = table.Column<string>(unicode: false, maxLength: 2, nullable: true),
                    name = table.Column<string>(unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LinguasThemoviedb", x => x.lingua);
                    table.ForeignKey(
                        name: "FK__LinguasTh__filme__45F365D3",
                        column: x => x.filme,
                        principalSchema: "FilmesStage",
                        principalTable: "FilmesThemoviedb",
                        principalColumn: "filme",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PaisesProducoesThemoviedb",
                schema: "FilmesStage",
                columns: table => new
                {
                    PaisProducao = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    filme = table.Column<long>(nullable: true),
                    iso_3166_1 = table.Column<string>(unicode: false, maxLength: 2, nullable: true),
                    name = table.Column<string>(unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaisesProducoesThemoviedb", x => x.PaisProducao);
                    table.ForeignKey(
                        name: "FK__PaisesPro__filme__4316F928",
                        column: x => x.filme,
                        principalSchema: "FilmesStage",
                        principalTable: "FilmesThemoviedb",
                        principalColumn: "filme",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProdutorasThemoviedb",
                schema: "FilmesStage",
                columns: table => new
                {
                    Produtora = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    filme = table.Column<long>(nullable: true),
                    id = table.Column<int>(nullable: true),
                    logo_path = table.Column<string>(unicode: false, nullable: true),
                    name = table.Column<string>(unicode: false, nullable: true),
                    origin_country = table.Column<string>(unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProdutorasThemoviedb", x => x.Produtora);
                    table.ForeignKey(
                        name: "FK__Produtora__filme__403A8C7D",
                        column: x => x.filme,
                        principalSchema: "FilmesStage",
                        principalTable: "FilmesThemoviedb",
                        principalColumn: "filme",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TheMoviesDbConfiguracoesMapeamentosExecucoes",
                columns: table => new
                {
                    theMovieDbConfiguracaoMapeamentoExecucao = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    theMovieDbConfiguracaoMapeamento = table.Column<long>(nullable: true),
                    processamentoStatus = table.Column<int>(nullable: true),
                    dataHora = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    processamentoMensagem = table.Column<string>(unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TheMoviesDbConfiguracoesMapeamentosExecucoes", x => x.theMovieDbConfiguracaoMapeamentoExecucao);
                    table.ForeignKey(
                        name: "FK__TheMovies__proce__22751F6C",
                        column: x => x.processamentoStatus,
                        principalTable: "ProcessamentosStatus",
                        principalColumn: "processamentoStatus",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__TheMovies__theMo__2180FB33",
                        column: x => x.theMovieDbConfiguracaoMapeamento,
                        principalTable: "TheMoviesDbConfiguracoesMapeamentos",
                        principalColumn: "theMovieDbConfiguracaoMapeamento",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TheMoviesDbConfiguracoesMapeamentos_theMovieDbConfiguracao",
                table: "TheMoviesDbConfiguracoesMapeamentos",
                column: "theMovieDbConfiguracao");

            migrationBuilder.CreateIndex(
                name: "IX_TheMoviesDbConfiguracoesMapeamentosExecucoes_processamentoStatus",
                table: "TheMoviesDbConfiguracoesMapeamentosExecucoes",
                column: "processamentoStatus");

            migrationBuilder.CreateIndex(
                name: "IX_TheMoviesDbConfiguracoesMapeamentosExecucoes_theMovieDbConfiguracaoMapeamento",
                table: "TheMoviesDbConfiguracoesMapeamentosExecucoes",
                column: "theMovieDbConfiguracaoMapeamento");

            migrationBuilder.CreateIndex(
                name: "IX_Fatos_cinemaStatus",
                schema: "Filmes",
                table: "Fatos",
                column: "cinemaStatus");

            migrationBuilder.CreateIndex(
                name: "IX_Fatos_lancamentoData",
                schema: "Filmes",
                table: "Fatos",
                column: "lancamentoData");

            migrationBuilder.CreateIndex(
                name: "IFK_Filmes_Genero",
                schema: "Filmes",
                table: "GenerosGrupos",
                column: "genero");

            migrationBuilder.CreateIndex(
                name: "IX_GenerosGrupos_idOrigem",
                schema: "Filmes",
                table: "GenerosGrupos",
                column: "idOrigem");

            migrationBuilder.CreateIndex(
                name: "IX_PessoasGrupos_pessoa",
                schema: "Filmes",
                table: "PessoasGrupos",
                column: "pessoa");

            migrationBuilder.CreateIndex(
                name: "IX_ProducoesPaisesGrupos_idOrigem",
                schema: "Filmes",
                table: "ProducoesPaisesGrupos",
                column: "idOrigem");

            migrationBuilder.CreateIndex(
                name: "ProducoesPaisesGrupos_FKIndex1",
                schema: "Filmes",
                table: "ProducoesPaisesGrupos",
                column: "pais");

            migrationBuilder.CreateIndex(
                name: "IX_ProdutorasGrupos_idOrigem",
                schema: "Filmes",
                table: "ProdutorasGrupos",
                column: "idOrigem");

            migrationBuilder.CreateIndex(
                name: "ProdutorasGrupo_FKIndex1",
                schema: "Filmes",
                table: "ProdutorasGrupos",
                column: "produtora");

            migrationBuilder.CreateIndex(
                name: "IX_ColecoesThemoviedb_filme",
                schema: "FilmesStage",
                table: "ColecoesThemoviedb",
                column: "filme");

            migrationBuilder.CreateIndex(
                name: "IX_CrewThemoviedb_filme",
                schema: "FilmesStage",
                table: "CrewThemoviedb",
                column: "filme");

            migrationBuilder.CreateIndex(
                name: "IX_FilmesCartazFila_processamentoStatus",
                schema: "FilmesStage",
                table: "FilmesCartazFila",
                column: "processamentoStatus");

            migrationBuilder.CreateIndex(
                name: "IX_FilmesFilas_filmeFilaTipo",
                schema: "FilmesStage",
                table: "FilmesFilas",
                column: "filmeFilaTipo");

            migrationBuilder.CreateIndex(
                name: "IX_GenerosThemoviedb_filme",
                schema: "FilmesStage",
                table: "GenerosThemoviedb",
                column: "filme");

            migrationBuilder.CreateIndex(
                name: "IX_LinguasThemoviedb_filme",
                schema: "FilmesStage",
                table: "LinguasThemoviedb",
                column: "filme");

            migrationBuilder.CreateIndex(
                name: "IX_PaisesProducoesThemoviedb_filme",
                schema: "FilmesStage",
                table: "PaisesProducoesThemoviedb",
                column: "filme");

            migrationBuilder.CreateIndex(
                name: "IX_ProdutorasThemoviedb_filme",
                schema: "FilmesStage",
                table: "ProdutorasThemoviedb",
                column: "filme");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TheMoviesDbConfiguracoesMapeamentosExecucoes");

            migrationBuilder.DropTable(
                name: "Fatos",
                schema: "Filmes");

            migrationBuilder.DropTable(
                name: "GenerosGrupos",
                schema: "Filmes");

            migrationBuilder.DropTable(
                name: "PessoasGrupos",
                schema: "Filmes");

            migrationBuilder.DropTable(
                name: "ProducoesPaisesGrupos",
                schema: "Filmes");

            migrationBuilder.DropTable(
                name: "ProdutorasGrupos",
                schema: "Filmes");

            migrationBuilder.DropTable(
                name: "ColecoesThemoviedb",
                schema: "FilmesStage");

            migrationBuilder.DropTable(
                name: "CrewThemoviedb",
                schema: "FilmesStage");

            migrationBuilder.DropTable(
                name: "FilmesCartazFila",
                schema: "FilmesStage");

            migrationBuilder.DropTable(
                name: "FilmesFilas",
                schema: "FilmesStage");

            migrationBuilder.DropTable(
                name: "GenerosThemoviedb",
                schema: "FilmesStage");

            migrationBuilder.DropTable(
                name: "LinguasThemoviedb",
                schema: "FilmesStage");

            migrationBuilder.DropTable(
                name: "PaisesProducoesThemoviedb",
                schema: "FilmesStage");

            migrationBuilder.DropTable(
                name: "ProdutorasThemoviedb",
                schema: "FilmesStage");

            migrationBuilder.DropTable(
                name: "TheMoviesDbConfiguracoesMapeamentos");

            migrationBuilder.DropTable(
                name: "CinemasStatus",
                schema: "Filmes");

            migrationBuilder.DropTable(
                name: "Detalhes",
                schema: "Filmes");

            migrationBuilder.DropTable(
                name: "Datas",
                schema: "Filmes");

            migrationBuilder.DropTable(
                name: "Generos",
                schema: "Filmes");

            migrationBuilder.DropTable(
                name: "Pessoas",
                schema: "Filmes");

            migrationBuilder.DropTable(
                name: "Paises",
                schema: "Filmes");

            migrationBuilder.DropTable(
                name: "Produtoras",
                schema: "Filmes");

            migrationBuilder.DropTable(
                name: "ProcessamentosStatus");

            migrationBuilder.DropTable(
                name: "FilmesFilasTipos",
                schema: "FilmesStage");

            migrationBuilder.DropTable(
                name: "FilmesThemoviedb",
                schema: "FilmesStage");

            migrationBuilder.DropTable(
                name: "TheMoviesDbConfiguracoes");
        }
    }
}
