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
        public string HairColor { get; set; } = null!;
        public string SkinColor { get; set; } = null!;
        public string EyeColor { get; set; } = null!;
        public string BirthYear { get; set; } = null!;
        public string Gender { get; set; } = null!;
    }
}
