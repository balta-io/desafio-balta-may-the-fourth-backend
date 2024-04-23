using MayTheFourth.Core.Contexts.PlanetContext.UseCases.Create;
using MayTheFourth.Core.Entities;
using MayTheFourth.Core.Interfaces.Repositories;
using MayTheFourth.Tests.Repositories;

namespace MayTheFourth.Tests.Contexts.PlanetContext.UseCases;

[TestClass]
public class CreatePlanetTests
{
    private readonly IPlanetRepository _planetRepository;
    private readonly Handler _handler;

    public CreatePlanetTests()
    {
        _planetRepository = new FakePlanetRepository();
        _handler = new(_planetRepository);
    }

    [TestMethod]
    [TestCategory("Handler")]
    public async Task Should_Return_Error_400_When_Planet_Already_Exists()
    {
        var request = new Request(
            Name: "Alderaan",
            Diameter: 12500,
            RotationPeriod: 24,
            OrbitalPeriod: 364,
            Gravity: "9.81",
            Population: 2000000000,
            Climate: "temperate",
            Terrain: "grasslands, mountains",
            SurfaceWater: "40",
            Url: "https://swapi.dev/api/planets/2/",
            Created: DateTime.UtcNow,
            Edited: DateTime.UtcNow,
            Residents: [],
            Films: []
        );

        var response = await _handler.Handle(request, CancellationToken.None);

        Assert.AreEqual("Erro: Planeja já cadastrado.", response.Message);
        Assert.AreEqual(400, response.Status);
        Assert.AreEqual(false, response.IsSuccess);
    }

    [TestMethod]
    [TestCategory("Handler")]
    public async Task Should_Return_Success_Response_When_Planet_Created_Successfully()
    {
        var request = new Request(
            Name: "Tatooine",
            Diameter: 10465,
            RotationPeriod: 23,
            OrbitalPeriod: 304,
            Gravity: "8.0",
            Population: 200000,
            Climate: "arid",
            Terrain: "desert",
            SurfaceWater: "1",
            Url: "https://swapi.dev/api/planets/1/",
            Created: DateTime.UtcNow,
            Edited: DateTime.UtcNow,
            Residents: [],
            Films: []
        );

        var response = await _handler.Handle(request, CancellationToken.None);

        Assert.AreEqual("Planeta cadastrado com sucesso.", response.Message);
        Assert.IsNotNull(response.Data?.planet);
        Assert.AreEqual(201, response.Status);
        Assert.AreEqual(true,response.IsSuccess);
    }

}
