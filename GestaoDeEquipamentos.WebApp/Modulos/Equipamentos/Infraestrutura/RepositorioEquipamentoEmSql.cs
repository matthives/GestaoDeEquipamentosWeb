using Dapper;
using GestaoDeEquipamentos.WebApp.Modulos.Equipamentos.Dominio;
using Microsoft.Data.SqlClient;

namespace GestaoDeEquipamentos.WebApp.Modulos.Equipamentos.Infraestrutura;

public sealed class RepositoroEquipamentoEmSql : IRepositorioEquipamento
{
    private readonly string connectionString;

    public RepositoroEquipamentoEmSql(string connectionString)
    {
        this.connectionString = connectionString;
    }

    public void Cadastrar(Equipamento novoRegistro)
    {
        const string query =
            """
            INSERT INTO dbo.TBEquipamentos (Nome, PrecoAquisicao, DataFabricacao, FabricanteId)
            OUTPUT INSERTED.Id    
            VALUES (@Nome, @PrecoAquisicao, @DataFabricacao, @FabricanteId)
            """;
        using SqlConnection conexao = new(connectionString);

        novoRegistro.Id = conexao.QuerySingle<int>(query, new
        {
            novoRegistro.Nome,
            novoRegistro.PrecoAquisicao,
            novoRegistro.DataFabricacao,
            FabricanteId = novoRegistro.Fabricante.Id
        });
    }

    public bool Editar(int idSelecionado, Equipamento entidadeAtualizada)
    {
        throw new NotImplementedException();
    }

    public bool Excluir(int idSelecionado)
    {
        throw new NotImplementedException();
    }

    public Equipamento? SelecionarPorId(int idSelecionado)
    {
        throw new NotImplementedException();
    }

    public List<Equipamento> SelecionarTodos()
    {
        return [];
    }
}