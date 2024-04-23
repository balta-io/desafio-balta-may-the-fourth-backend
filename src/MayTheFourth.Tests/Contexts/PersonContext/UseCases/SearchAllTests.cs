using MayTheFourth.Core.Contexts.PersonContext.UseCases.SearchAll;
using MayTheFourth.Core.Interfaces.Repositories;
using MayTheFourth.Tests.Repositories;

namespace MayTheFourth.Tests.Contexts.PersonContext.UseCases;

[TestClass]
public class SearchAllTests
{
    private readonly IPersonRepository _personRepository;

    public SearchAllTests()
    {
        _personRepository = new FakePersonRepository();
    }

    [TestMethod]
    [TestCategory("Handler")]
    public async Task Should_Return_Error_404_When_Repository_Returns_Empty_List()
    {
        var personRepository = new FakePersonRepository();
        personRepository.people.Clear();

        var handler = new Handler(personRepository);
        var request = new Request();

        var response = await handler.Handle(request, CancellationToken.None);

        Assert.AreEqual(404, response.Status);
        Assert.AreEqual(false, response.IsSuccess);
    }

    [TestMethod]
    [TestCategory("Handler")]
    public void Should_Succeed_When_PeopleList_Contains_Exactly_Five_People()
    {
        var handler = new Handler(_personRepository);
        var request = new Request();

        var people = handler.Handle(request, new CancellationToken());

        Assert.AreEqual(5, people.Result.Data?.people.Count, "Expected exactly five people in the list.");
    }

}
