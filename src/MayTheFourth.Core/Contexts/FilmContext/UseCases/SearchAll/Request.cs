using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MayTheFourth.Core.Contexts.FilmContext.UseCases.SearchAll
{
    public record Request(int PageNumber, int PageSize) : IRequest<Response>;

}
