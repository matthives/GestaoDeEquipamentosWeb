using GestaoDeEquipamentos.WebApp.Compartilhado.Infraestrutura.Arquivos;

namespace GestaoDeEquipamentos.WebApp.Compartilhado.Apresentacao;

public static class InjecaoDeDependencia
{
    public static void AdicionarCamadaDeApresentacao(this IServiceCollection services)
    {
        // Razor = CSHTML
        services.AddControllersWithViews().AddRazorOptions(options =>
        {
            // Reseta o mecaniscmo de busca de views
            options.ViewLocationFormats.Clear();

            // Configura Localização das views compartilhados
            options.ViewLocationFormats.Add("/Compartilhado/Apresentacao/Views/{0}.cshtml");

            // Configura Localização das views de cada módulo
            options.ViewLocationFormats.Add("/Modulos/{1}s/Apresentacao/Views/{0}.cshtml");
        });
    }
}