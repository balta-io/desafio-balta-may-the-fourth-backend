using MayTheFourth.Core.Contexts.SharedContext;
using MayTheFourth.Core.Contexts.SharedContext.UseCases;
using MayTheFourth.Core.Dtos;
using MayTheFourth.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MayTheFourth.Core.Contexts.FilmContext.UseCases.SearchAll
{
    public class Response : SharedContext.UseCases.Response
    {
        public Response(string message, int status)
        {
            Message = message;
            Status = status;
        }

        public Response(string message, ResponseData data)
        {
            Message = message;
            Status = 200;
            Data = data;
        }

        public ResponseData? Data { get; set; }
    }

    public record ResponseData(PagedList<FilmSummaryDto> films);
}
