using Builder;
using System;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        // Створення героя
        ICharacterBuilder heroBuilder = new HeroCreator();
        CharacterDirector director = new CharacterDirector(heroBuilder);
        GameCharacter hero = director.CreateHero();
        Console.WriteLine("Герой:");
        hero.ShowDetails();

        // Створення лиходія
        ICharacterBuilder villainBuilder = new VillainCreator();
        director = new CharacterDirector(villainBuilder);
        GameCharacter villain = director.CreateVillain();
        Console.WriteLine("\nЛиходій:");
        villain.ShowDetails();
    }
}
