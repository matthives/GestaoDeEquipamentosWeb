using GestaoDeEquipamentos.WebApp.Compartilhado.Infraestrutura.Arquivos;
using GestaoDeEquipamentos.WebApp.Modulos.Fabricantes.Infraestrutura;
using GestaoDeEquipamentos.WebApp.Modulos.Equipamentos.Infraestrutura;
using GestaoDeEquipamentos.WebApp.Modulos.Chamados.Infraestrutura;
using GestaoDeEquipamentos.WebApp.Modulos.Fabricantes.Dominio;

namespace GestaoDeEquipamentos.WebApp.Compartilhado.Infraestrutura;

public static class InjecaoDeDependencia
{
    public static void AdicionarCamadaDeInfraestrutura(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        // Configurar o contexto de dados
        services.AddScoped(services =>
        {
            ContextoJson contexto = new ContextoJson();
            contexto.Carregar();

            return contexto;
        });

        string connectionString = configuration.GetConnectionString("SqlServerDocker")
        ?? throw new InvalidOperationException("A string de conexão \"SqlServerDocker\" não foi configurada.");

        // Configurar os repositórios
        services.AddScoped<IRepositorioFabricante>(_ =>
        {
            return new RepositorioFabricanteEmSql(connectionString);
        });

        services.AddScoped<RepositorioEquipamentoEmArquivo>();
        services.AddScoped<RepositorioChamadoEmArquivo>();

    }
}