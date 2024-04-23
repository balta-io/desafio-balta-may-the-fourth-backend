using MayTheFourth.Core.Contexts.PersonContext.UseCases.Create;
using MayTheFourth.Core.Interfaces.Repositories;
using MayTheFourth.Tests.Repositories;

namespace MayTheFourth.Tests.Contexts.PersonContext.UseCases;

[TestClass]
public class CreatePersonTests
{
    private readonly IPersonRepository _personRepository;
    private readonly Handler _handler;

    public CreatePersonTests()
    {
        _personRepository = new FakePersonRepository();
        _handler = new(_personRepository);
    }

    [TestMethod]
    [TestCategory("Handler")]
    public async Task Should_Return_Error_400_When_Person_Already_Exists()
    {
        var request = new Request(
            Name : "Obi-Wan Kenobi",
            Height : 182,
            Mass : "77",
            HairColor: "auburn, white",
            SkinColor: "fair",
            EyeColor: "blue-gray",
            BirthYear: "57BBY",
            Gender: "male",
            Homeworld: null,
            Films: [],
            Species: [],
            Vehicles: [],
            Starships: [],
            Created: DateTime.UtcNow,
            Edited: DateTime.UtcNow,
            Url: "https://swapi.dev/api/people/10/"
        );

        var response = await _handler.Handle(request, CancellationToken.None);

        Assert.AreEqual("Erro: Personagem já cadastrado.", response.Message);
        Assert.AreEqual(400, response.Status);
        Assert.AreEqual(false, response.IsSuccess);
    }

    [TestMethod]
    [TestCategory("Handler")]
    public async Task Should_Return_Success_Response_When_Person_Created_Successfully()
    {
        var request = new Request(
            Name: "Leia Organa",
            Height: 150,
            Mass: "49",
            HairColor: "brown",
            SkinColor: "light",
            EyeColor: "brown",
            BirthYear: "19BBY",
            Gender: "female",
            Homeworld: null,
            Films: [],
            Species: [],
            Vehicles: [],
            Starships: [],
            Created: DateTime.UtcNow,
            Edited: DateTime.UtcNow,
            Url: "https://swapi.dev/api/people/5/"
        );

        var response = await _handler.Handle(request, CancellationToken.None);

        Assert.AreEqual("Personagem cadastrado com sucesso.", response.Message);
        Assert.IsNotNull(response.Data?.person);
        Assert.AreEqual(201, response.Status);
        Assert.AreEqual(true, response.IsSuccess);
    }
}
