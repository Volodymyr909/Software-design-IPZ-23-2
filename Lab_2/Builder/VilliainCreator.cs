using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder
{
    using System.Collections.Generic;

    public class VillainCreator : ICharacterBuilder
    {
        private GameCharacter _character = new GameCharacter();

        public ICharacterBuilder WithName(string name)
        {
            _character.Name = name;
            return this;
        }

        public ICharacterBuilder WithHeight(double height)
        {
            _character.Height = height;
            return this;
        }

        public ICharacterBuilder WithBodyType(string bodyType)
        {
            _character.BodyType = bodyType;
            return this;
        }

        public ICharacterBuilder WithHairColor(string hairColor)
        {
            _character.HairColor = hairColor;
            return this;
        }

        public ICharacterBuilder WithEyeColor(string eyeColor)
        {
            _character.EyeColor = eyeColor;
            return this;
        }

        public ICharacterBuilder WithOutfit(string outfit)
        {
            _character.Outfit = outfit;
            return this;
        }

        public ICharacterBuilder WithEquipment(List<string> equipment)
        {
            _character.Equipment = equipment;
            return this;
        }

        public GameCharacter Build()
        {
            return _character;
        }
    }

}
