namespace MayTheFourth.Helpers.Validations;

/// <summary>
/// Fornece métodos estáticos para validar as informações de um filme antes de sua persistência no banco de dados.
/// </summary>
public static class ValidateFilme
{
    /// <summary>
    /// Valida os dados de um filme, retornando uma lista de erros encontrados.
    /// </summary>
    /// <param name="filme">O DTO do filme a ser validado.</param>
    /// <returns>Uma lista de strings contendo mensagens de erro relacionadas à validação dos dados do filme.</returns>
    public static List<string> ValidateFilm(Filme filme)
    {
        var errors = new List<string>();

        if (string.IsNullOrWhiteSpace(filme.Titulo))
            errors.Add("O título do filme é obrigatório.");

        if (filme.Episodio <= 0)
            errors.Add("O episódio deve ser maior que zero.");

        if (string.IsNullOrWhiteSpace(filme.Diretor))
            errors.Add("O nome do diretor é obrigatório.");

        if (string.IsNullOrWhiteSpace(filme.Produtor))
            errors.Add("O nome do produtor é obrigatório.");

        if (filme.DataLancamento == DateTime.MinValue)
            errors.Add("A data de lançamento é inválida.");

        return errors;
    }
}