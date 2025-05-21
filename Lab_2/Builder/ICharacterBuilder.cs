using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder
{
    public interface ICharacterBuilder
    {
        ICharacterBuilder WithName(string name);
        ICharacterBuilder WithHeight(double height);
        ICharacterBuilder WithBodyType(string bodyType);
        ICharacterBuilder WithHairColor(string hairColor);
        ICharacterBuilder WithEyeColor(string eyeColor);
        ICharacterBuilder WithOutfit(string outfit);
        ICharacterBuilder WithEquipment(List<string> equipment);
        GameCharacter Build();
    }

}
