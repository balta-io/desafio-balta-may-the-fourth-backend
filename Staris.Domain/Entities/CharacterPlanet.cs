namespace Staris.Domain.Entities
{
	public sealed class CharacterPlanet
	{
		public int PlanetId { get; set; }
        public int CharacterId { get; set; }


		//EF Relation
        public Planet? Planet { get; set; }
		public Character? Character { get; set; }
	}
}
