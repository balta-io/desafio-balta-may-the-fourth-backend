using FluentValidation;

namespace MayTheFourth.Application.Features.Filmes
{
    public record FilmesRequestBase
    {
        public int FilmeId { get; set; }
        public string Title { get; set; } = null!;
        public string Episode { get; set; } = null!;
        public string OpeningCrawl { get; set; } = null!;
        public string Director { get; set; } = null!;
        public string Producer { get; set; } = null!;
        public DateTime ReleaseDate { get; set; }
    }

    public class ClientRequestBaseValidator<T> : AbstractValidator<T> where T : FilmesRequestBase
    {
        public ClientRequestBaseValidator()
        {
            RuleFor(x => x.FilmeId).NotEmpty().NotNull();
            RuleFor(x => x.Title).NotEmpty().NotNull();
            RuleFor(x => x.Episode).NotEmpty().NotNull();
            RuleFor(x => x.OpeningCrawl).NotEmpty().NotNull();
            RuleFor(x => x.Director).NotEmpty().NotNull();
            RuleFor(x => x.Producer).NotEmpty().NotNull();
            RuleFor(x => x.ReleaseDate).Must(BeValidDateTime);
        }

        private bool BeValidDateTime(DateTime date) => !date.Equals(default);
    }
}
