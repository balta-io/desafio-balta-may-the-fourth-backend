using MayTheFourth.Core.Contexts.FilmContext.UseCases.SearchAll;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MayTheFourth.Tests.Contexts.FilmContext.UseCases.SearchAll
{
    public class Handler : IRequestHandler<Request, Response>
    {
        public Task<Response> Handle(Request request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
