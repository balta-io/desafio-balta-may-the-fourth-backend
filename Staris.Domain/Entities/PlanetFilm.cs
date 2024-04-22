using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Staris.Domain.Entities
{
	public sealed class PlanetFilm
	{
		public int FilmId { get; set; }
        public int PlanetId { get; set; }


		//EF Relation
		public Planet? Planet{ get; init; }
		public Film? Film { get; init; }

	}
}
