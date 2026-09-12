using GestaoDeEquipamentos.WebApp.Compartilhado.Infraestrutura.Arquivos;
using GestaoDeEquipamentos.WebApp.Modulos.Fabricantes.Infraestrutura;
using GestaoDeEquipamentos.WebApp.Modulos.Equipamentos.Infraestrutura;
using GestaoDeEquipamentos.WebApp.Modulos.Chamados.Infraestrutura;
using GestaoDeEquipamentos.WebApp.Modulos.Fabricantes.Dominio;

namespace GestaoDeEquipamentos.WebApp.Compartilhado.Infraestrutura;

public static class InjecaoDeDependencia
{
    public static void AdicionarCamadaDeInfraestrutura(this IServiceCollection services)
    {
        // Configurar o contexto de dados
        services.AddScoped(services =>
        {
            ContextoJson contexto = new ContextoJson();
            contexto.Carregar();

            return contexto;
        });

        // Configurar os repositórios
        services.AddScoped<IRepositorioFabricante, RepositorioFabricanteEmSql>();
        services.AddScoped<RepositorioEquipamentoEmArquivo>();
        services.AddScoped<RepositorioChamadoEmArquivo>();

    }
}