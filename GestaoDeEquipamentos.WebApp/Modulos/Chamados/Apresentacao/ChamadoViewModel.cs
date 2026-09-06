using System.ComponentModel.DataAnnotations;

using GestaoDeEquipamentos.WebApp.Modulos.Equipamentos.Apresentacao;
using GestaoDeEquipamentos.WebApp.Modulos.Equipamentos.Dominio;

namespace GestaoDeEquipamentos.WebApp.Modulos.Chamados.Apresentacao;


public record ListarChamadoViewModel(
    int Id,
    string Titulo,
    string Descricao,
    int EquipamentoId,
    DateTime DataAbertura

);

public record SelecionarChamadoViewModel(int Id, string titulo, string descricao, int equipamentoId, DateTime dataAbertura);
public record SelecionarEquipamentosModel(int Id, string Nome);

public record CadastrarChamadoViewModel(

    [Required(ErrorMessage = "O campo \"Título do Chamado\" é obrigatório.")]
    [StringLength(100, MinimumLength = 6,
        ErrorMessage = "O campo \"Título do Chamado\" deve conter entre 6 e 100 caracteres.")]
    string? Titulo,

    [Required(ErrorMessage = "O campo \"Descrição do Chamado\" é obrigatório.")]
    [StringLength(200, MinimumLength = 10,
        ErrorMessage = "O campo \"Descrição do Chamado\" deve conter entre 10 e 200 caracteres.")]
    string? Descricao,

    [Required(ErrorMessage = "O campo \"Equipamento\" é obrigatório.")]
    int EquipamentoId,

    [Required(ErrorMessage = "O campo \"Data de abertura\" é obrigatório.")]
    [DataType(DataType.Date)]
    DateTime DataAbertura,

    List<SelecionarEquipamentosModel>? EquipamentosDisponiveis
);

public record EditarChamadoViewModel(
    int Id,

    [Required(ErrorMessage = "O campo \"Título do Chamado\" é obrigatório.")]
    [StringLength(100, MinimumLength = 6,
        ErrorMessage = "O campo \"Título do Chamado\" deve conter entre 6 e 100 caracteres.")]
    string? Titulo,

    [Required(ErrorMessage = "O campo \"Descrição do Chamado\" é obrigatório.")]
    [StringLength(200, MinimumLength = 10,
        ErrorMessage = "O campo \"Descrição do Chamado\" deve conter entre 10 e 200 caracteres.")]
    string? Descricao,

    [Required(ErrorMessage = "O campo \"Equipamento\" é obrigatório.")]
    int EquipamentoId,

    [Required(ErrorMessage = "O campo \"Data de abertura\" é obrigatório.")]
    [DataType(DataType.Date)]
    DateTime DataAbertura,

    List<SelecionarEquipamentosModel>? EquipamentosDisponiveis

);

public record ExcluirChamadoViewModel(
    int Id,
    string Titulo
);