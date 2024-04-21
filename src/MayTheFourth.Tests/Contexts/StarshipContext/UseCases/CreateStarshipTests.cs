using MayTheFourth.Core.Contexts.StarshipContext.UseCases.Create;
using MayTheFourth.Core.Interfaces.Repositories;
using MayTheFourth.Tests.Repositories;

namespace MayTheFourth.Tests.Contexts.StarshipContext.UseCases;

[TestClass]
public class CreateStarshipTests
{
    private readonly IStarshipRepository _starshipRepository;
    private readonly Handler _handler;

    public CreateStarshipTests()
    {
        _starshipRepository = new FakeStarshipRepository();
        _handler = new(_starshipRepository);
    }

    [TestMethod]
    [TestCategory("Handler")]
    public async Task Should_Return_Error_400_When_Starship_Already_Exists()
    {
        var request = new Request(
            Name: "Executor",
            Model: "Executor-class Star Dreadnought",
            StarshipClass: "Star Dreadnought",
            Manufacturer: "Kuat Drive Yards",
            CostInCredits: 1143350000,
            Length: 19000.0,
            Crew: 279,
            Passengers: 38000,
            MaxAtmospheringSpeed: 40,
            HyperdriveRating: "2.0",
            MGLT: "40",
            CargoCapacity: 25000000,
            Consumables: "6 years",
            Url: "https://starwars.fandom.com/wiki/Executor",
            Created: DateTime.UtcNow,
            Edited: DateTime.UtcNow
        );

        var response = await _handler.Handle(request, new CancellationToken());
        Assert.AreEqual(400, response.Status);
        Assert.AreEqual(false, response.IsSuccess);
    }

    [TestMethod]
    [TestCategory("Handler")]
    public async Task Should_Return_Success_After_Starship_Is_Created()
    {
        var request = new Request(
            Name: "Devastator",
            Model: "Imperial-class Star Destroyer",
            StarshipClass: "Star Destroyer",
            Manufacturer: "Kuat Drive Yards",
            CostInCredits: 145000000,
            Length: 1600.0,
            Crew: 9700,
            Passengers: 0,
            MaxAtmospheringSpeed: 975,
            HyperdriveRating: "2.0",
            MGLT: "60",
            CargoCapacity: 36000000,
            Consumables: "2 years",
            Url: "https://starwars.fandom.com/wiki/Imperial_I-class_Star_Destroyer",
            Created: DateTime.UtcNow,
            Edited: DateTime.UtcNow
        );

        var response = await _handler.Handle(request, new CancellationToken());

        Assert.AreEqual("Nave criada com sucesso", response.Message);
        Assert.IsNotNull(response.Data?.starship);
        Assert.AreEqual(true, response.IsSuccess);
    }
}
