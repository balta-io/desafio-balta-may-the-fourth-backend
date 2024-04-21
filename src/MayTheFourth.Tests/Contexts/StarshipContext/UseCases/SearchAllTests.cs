using MayTheFourth.Core.Contexts.StarshipContext.UseCases.SearchAll;
using MayTheFourth.Core.Interfaces.Repositories;
using MayTheFourth.Tests.Repositories;

namespace MayTheFourth.Tests.Contexts.StarshipContext.UseCases;

[TestClass]
public class SearchAllTests
{
    private readonly IStarshipRepository _starshipRepository;
    private readonly Handler _handler;

    public SearchAllTests()
    {
        _starshipRepository = new FakeStarshipRepository();
        _handler = new(_starshipRepository);
    }

    [TestMethod]
    [TestCategory("Handler")]
    public async Task Should_Return_Error_404_When_StarshipList_Is_Empty()
    {
        var starshipRepository = new FakeStarshipRepository();
        starshipRepository.starships.Clear();

        var handler = new Handler(starshipRepository);
        var request = new Request();

        var response = await handler.Handle(request, new CancellationToken());

        Assert.AreEqual(404, response.Status);
        Assert.AreEqual(false, response.IsSuccess);
    }

    [TestMethod]
    [TestCategory("Handler")]
    public async Task Should_Succeed_When_SpaceshipList_Contains_Exacly_Two_Starships()
    {
        var request = new Request();
        var response = await _handler.Handle(request, new CancellationToken());

        Assert.AreEqual(2, response.Data?.StarshipList.Count, "Expected exactly two starships in the list.");
        Assert.AreEqual(true, response.IsSuccess);
    }
}
