namespace Staris.Domain.Entities
{
	/// <summary>
	/// Residents
	/// </summary>
	public sealed class PlanetCharacter
	{
		public int PlanetId { get; set; }
        public int CharacterId { get; set; }


		//EF Relation
        public Planet? Planet { get; init; }
		public Character? Character { get; init; }
	}
}
