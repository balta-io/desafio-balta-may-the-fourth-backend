using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Staris.Domain.Entities
{
	public sealed class CharacterFilm
	{
        public int CharacterId { get; set; }
		public int FilmId { get; set; }

		//EF Relation
		public Character? Character { get; init; }
		public Film? Film { get; init; }
	}
}
