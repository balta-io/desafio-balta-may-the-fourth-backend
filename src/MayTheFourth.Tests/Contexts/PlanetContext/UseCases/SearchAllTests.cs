using MayTheFourth.Core.Contexts.PlanetContext.UseCases.SearchAll;
using MayTheFourth.Core.Entities;
using MayTheFourth.Core.Interfaces.Repositories;
using MayTheFourth.Tests.Repositories;

namespace MayTheFourth.Tests.Contexts.PlanetContext.UseCases;

[TestClass]
public class SearchAllTests
{
    private readonly IPlanetRepository _planetRepository;
    private readonly Handler _handler;

    public SearchAllTests()
    {
        _planetRepository = new FakePlanetRepository();
        _handler = new(_planetRepository);
    }

    [TestMethod]
    [TestCategory("Handler")]
    public async Task Should_Return_Error_404_When_Repository_Returns_Empty_List()
    {
        var planetRepository = new FakePlanetRepository();
        planetRepository.planets.Clear();

        var handler = new Handler(planetRepository);
        var request = new Request();

        var response = await handler.Handle(request, CancellationToken.None);

        Assert.AreEqual(404, response.Status);
        Assert.AreEqual(false, response.IsSuccess);
    }

    [TestMethod]
    [TestCategory("Handler")]
    public async Task Should_Succeed_When_PlanetList_Contains_Exactly_Five_Planets()
    {
        var request = new Request();
        var response = await _handler.Handle(request, new CancellationToken());
        
        Assert.AreEqual(5, response.Data?.planetList.Count, "Expected exactly five planets in the list.");
        Assert.AreEqual(true, response.IsSuccess);
        Assert.AreEqual(200, response.Status);
    }
}
