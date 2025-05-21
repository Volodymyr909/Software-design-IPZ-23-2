using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder
{
    using System;
    using System.Collections.Generic;

    public class GameCharacter
    {
        public string Name { get; set; }
        public double Height { get; set; }
        public string BodyType { get; set; }
        public string HairColor { get; set; }
        public string EyeColor { get; set; }
        public string Outfit { get; set; }
        public List<string> Equipment { get; set; }

        public void ShowDetails()
        {
            Console.WriteLine($"Ім'я: {Name}");
            Console.WriteLine($"Зріст: {Height}");
            Console.WriteLine($"Статура: {BodyType}");
            Console.WriteLine($"Колір волосся: {HairColor}");
            Console.WriteLine($"Колір очей: {EyeColor}");
            Console.WriteLine($"Одяг: {Outfit}");
            Console.WriteLine($"Інвентар: {string.Join(", ", Equipment)}");
        }
    }

}
