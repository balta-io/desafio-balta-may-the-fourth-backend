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
    public void Should_Succeed_When_PersonList_Contains_Exactly_Five_Persons()
    {
        var handler = new Handler(_personRepository);
        var request = new Request();

        var persons = handler.Handle(request, new CancellationToken());

        Assert.AreEqual(5, persons.Result.Data?.persons.Count, "Expected exactly five persons in the list.");
    }
}
