using Dapper;
using Microsoft.Data.SqlClient;
using GestaoDeEquipamentos.WebApp.Modulos.Fabricantes.Dominio;

namespace GestaoDeEquipamentos.WebApp.Modulos.Fabricantes.Infraestrutura;

public sealed class RepositorioFabricanteEmSql : IRepositorioFabricante
{
    private readonly string connectionString;

    public RepositorioFaricanteEmSql(string connectionString)
    {
        this.connectionString = connectionString;
    }
    public void Cadastrar(Fabricante novoRegistro)
    {
        const string query =
            """
            INSERT INTO dbo.TBFabricantes (Nome, Email, Telefone)
            OUTPUT INSERTED.Id    
            VALUES (@Nome, @Email, @Telefone)
            """;

        using SqlConnection conexao = new(connectionString);

        novoRegistro.Id = conexao.QuerySingle<int>(query, novoRegistro);

    }

    public bool Editar(int idSelecionado, Fabricante entidadeAtualizada)
    {
        throw new NotImplementedException();
    }

    public bool Excluir(int idSelecionado)
    {
        throw new NotImplementedException();
    }

    public Fabricante? SelecionarPorId(int idSelecionado)
    {
        throw new NotImplementedException();
    }

    public List<Fabricante> SelecionarTodos()
    {
        const string query =
            """
            SELECT Id, Nome, Email, Telefone
            FROM dbo.TBFabricantes
            ORDER BY id
            """;

        using SqlConnection conexao = new(connectionString);

        // Query = Consulta no banco (SQL = Structured Query Language)
        return conexao.Query<Fabricante>(query).ToList();
    }
}
