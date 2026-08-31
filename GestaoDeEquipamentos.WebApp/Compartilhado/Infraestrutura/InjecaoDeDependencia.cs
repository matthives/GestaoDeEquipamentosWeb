using GestaoDeEquipamentos.WebApp.Compartilhado.Infraestrutura.Arquivos;

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

    }
}