using GestaoDeEquipamentos.WebApp.Compartilhado.Infraestrutura;
using GestaoDeEquipamentos.WebApp.Compartilhado.Apresentacao;

var builder = WebApplication.CreateBuilder(args);

// Configurar a infraestrutura (Arquivos, Banco de Dados ...)
builder.Services.AdicionarCamadaDeInfraestrutura(builder.Configuration);

// Configurar o MVC / Apresentação
builder.Services.AdicionarCamadaDeApresentacao();

var app = builder.Build();

// Middlewares
app.UseRouting();
app.MapDefaultControllerRoute();

app.UseStaticFiles();

// Executa o servidor

app.Run();
