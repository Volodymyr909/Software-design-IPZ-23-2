using System;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;

        Virus parentVirus = new Virus(5.0, 10, "ParentVirus", "TypeA");
        Virus childVirus1 = new Virus(2.0, 5, "ChildVirus1", "TypeB");
        Virus childVirus2 = new Virus(1.5, 3, "ChildVirus2", "TypeC");

        parentVirus.AddChild(childVirus1);
        parentVirus.AddChild(childVirus2);

        Virus clonedVirus = (Virus)parentVirus.Clone();

        Console.WriteLine("Початковий вірус:");
        parentVirus.Display();

        Console.WriteLine("\nКлонований вірус:");
        clonedVirus.Display();
    }
}
