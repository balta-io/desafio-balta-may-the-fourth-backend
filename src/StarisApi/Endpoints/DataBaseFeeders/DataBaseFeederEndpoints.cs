using StarisApi.DbContexts;
using StarisApi.Models.Characters;
using StarisApi.Models.CharactersMovies;
using StarisApi.Models.Movies;
using StarisApi.Repository;
using System.Runtime.CompilerServices;
using System.Text.Json;

namespace StarisApi.Endpoints.DataBaseFeeders;

public static class DataBaseFeederEndpoints
{
    public static IEndpointRouteBuilder MapDatabaseFeederEndpoits(this IEndpointRouteBuilder app)
    {
        app.MapGet("/dbFeederCharacter", async (SqliteContext context, DataBaseFeeder feeder) => {

            var charactersBase = new List<Character>();
            var filmsBase = new List<Movie>();
           

            var infosCharecters = await feeder.GetInfoFromPeopleEndpoint();
            var infosPlanets = await feeder.GetInfoFromPlanetsEndpoint();
            var infosMovies = await feeder.GetInfoFromMoviesEndpoint();



            foreach (var info in infosCharecters)
            {
                var homeString = info.GetProperty("homeworld").GetString()!.Split("/");
                var homeId = int.Parse(homeString[homeString.Length - 2]);

                var movie = filmsBase.FirstOrDefault(x => x.Id == homeId);

                var character = new Character
                {
                    Name = info.GetProperty("name").GetString()!,
                    Height = info.GetProperty("height").GetString()!,
                    Mass = info.GetProperty("mass").GetString()!,
                    HairColor = info.GetProperty("hair_color").GetString()!,
                    SkinColor = info.GetProperty("skin_color").GetString()!,
                    EyeColor = info.GetProperty("eye_color").GetString()!,
                    BirthYear = info.GetProperty("birth_year").GetString()!,
                    Gender = info.GetProperty("gender").GetString()!,
                    PlanetId = homeId,
                    //Movies = info.GetProperty("films").EnumerateArray()
                    //             .Select(movie => GetMovies(movie)).ToList()
                    Movies = new List<CharacterMovie>
                    {
                        new CharacterMovie
                        {
                            Movie = movie!
                        }
                    }
                };

                charactersBase.Add(character);
            }
        });


        

        return app;
    }

    private static CharacterMovie GetMovies(JsonElement film)
    {
        var movieString = film.GetString()!.Split("/");
        return new CharacterMovie
        {
            MovieId = int.Parse(movieString[movieString.Length - 2])
        };
    }
}
