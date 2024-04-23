using MayTheFourth.Core.Contexts.FilmContext.UseCases.SearchAll;
using MayTheFourth.Core.Interfaces.Repositories;
using MayTheFourth.Tests.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MayTheFourth.Tests.Contexts.FilmContext.UseCases
{
    [TestClass]
    public class SearchAll
    {
        private readonly IFilmRepository _filmRepository;

        public SearchAll()
        {
            _filmRepository = new FakeFilmRepository();
        }

        [TestMethod]
        [TestCategory("Handler")]
        public void Should_Return_Exactly_Five_Films()
        {
            var handler = new Handler(_filmRepository);
            var request = new Request();

            var films = handler.Handle(request, new CancellationToken());

            Assert.AreEqual(5, films.Result.Data?.films.Count, "Expected exactly five films in the list.");
        }
    }
}
