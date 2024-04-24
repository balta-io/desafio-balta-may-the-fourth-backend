using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MayTheFourth.Application.Features.People
{
    public class GetPeopleResponse
    {
        public string Name { get; set; }  = null!;
        public string Height { get; set; } = null!;
        public string Mass { get; set; } = null!;
        public string Hair_color { get; set; } = null!;
        public string Skin_color { get; set; } = null!;
        public string Eye_color { get; set; } = null!;
        public string Birth_year { get; set; } = null!;
        public string Gender { get; set; } = null!;
        public List<ItemDescriptor>? Movies { get; set; }
    }

    public class ItemDescriptor
    {
        public int? Id { get; set; }
        public string? Tittle { get; set; }
    }


}
