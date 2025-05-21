using Decorator;
using static System.Net.Mime.MediaTypeNames;

public class Program
{
    public static void Main(string[] args)
    {
        IHero warrior = new Warrior();
        warrior = new ArmorDecorator(warrior);
        warrior = new WeaponDecorator(warrior);
        warrior.DisplayStats();

        Console.WriteLine();

        IHero mage = new Mage();
        mage = new ArtifactDecorator(mage);
        mage = new WeaponDecorator(mage);
        mage.DisplayStats();

        Console.WriteLine();

        IHero paladin = new Paladin();
        paladin = new ArmorDecorator(paladin);
        paladin = new ArtifactDecorator(paladin);
        paladin.DisplayStats();
    }
}
