using StarisApi.Models.People;
using StarisApi.Models.Films;

namespace StarisApi.Models.PeopleFilms;

public class PersonFilm
{
    public int Id { get; set; }
    public int PersonId { get; set; }
    public int FilmId { get; set; }
    public Person Person { get; set; } = null!;
    public Film Film { get; set; } = null!;
}
