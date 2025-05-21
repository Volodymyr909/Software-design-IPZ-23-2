using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder
{
    public class CharacterDirector
    {
        private ICharacterBuilder _builder;

        public CharacterDirector(ICharacterBuilder builder)
        {
            _builder = builder;
        }

        public GameCharacter CreateHero()
        {
            return _builder
                .WithName("Герой")
                .WithHeight(1.85)
                .WithBodyType("Сильний")
                .WithHairColor("Чорний")
                .WithEyeColor("Карий")
                .WithOutfit("Броня")
                .WithEquipment(new List<string> { "Меч", "Щит", "Ліки" })
                .Build();
        }

        public GameCharacter CreateVillain()
        {
            return _builder
                .WithName("Злодій")
                .WithHeight(1.75)
                .WithBodyType("Худий")
                .WithHairColor("Білий")
                .WithEyeColor("Сірий")
                .WithOutfit("Чорний плащ")
                .WithEquipment(new List<string> { "Кинджал", "Отрута" })
                .Build();
        }
    }
}
