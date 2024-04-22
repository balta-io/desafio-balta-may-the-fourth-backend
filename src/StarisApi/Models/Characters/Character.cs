using StarisApi.Dtos;
using System.Globalization;
using System.Reflection;

namespace StarisApi.Models.Characters
{
    public sealed class Character : Entity
    {
        public string Name { get; set; } = null!;

        public override T ConvertToDto<T>()
        {
            var character = new CharacterDto
                            {
                                Id = Id,
                                Name = Name
                            
                            } as T;

            return character!;
        }

        public override string GetSearchParameter() => "Name";
    }
}
