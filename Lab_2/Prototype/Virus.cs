using System;
using System.Collections.Generic;

public class Virus : ICloneable
{
    public double Weight { get; set; }
    public int Age { get; set; }
    public string Name { get; set; }
    public string Type { get; set; }
    public List<Virus> Children { get; set; }

    public Virus(double weight, int age, string name, string type)
    {
        Weight = weight;
        Age = age;
        Name = name;
        Type = type;
        Children = new List<Virus>();
    }

    public void AddChild(Virus child)
    {
        Children.Add(child);
    }

    public object Clone()
    {
        Virus clone = (Virus)this.MemberwiseClone();
        clone.Children = new List<Virus>();

        foreach (Virus child in Children)
        {
            clone.Children.Add((Virus)child.Clone());
        }

        return clone;
    }

    public void Display(int generation = 0)
    {
        Console.WriteLine($"{new string(' ', generation * 2)}Ім'я: {Name}, Вид: {Type}, Вага: {Weight}, Вік: {Age}");
        foreach (Virus child in Children)
        {
            child.Display(generation + 1);
        }
    }
}
