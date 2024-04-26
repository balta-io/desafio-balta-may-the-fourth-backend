namespace MayTheFourth.Helpers.Validations;

public static class ValidateFilme
{
    public static List<string> ValidateFilm(Dtos.Filme filme)
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