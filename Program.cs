using System;
using System.Collections.Generic;
using System.Text;

abstract class SeaItem
{
    public string Name { get; set; }
    public int Age { get; set; }

    public SeaItem(string name, int age)
    {
        Name = name;
        Age = age;
    }

    public abstract string Kind { get; }

    public override string ToString()
    {
        return $"{Kind} {Name}, вік: {Age}";
    }
}

class Shark : SeaItem
{
    public double Length { get; set; }

    public Shark(string name, int age, double length) : base(name, age)
    {
        Length = length;
    }

    public override string Kind => "Акула";

    public override string ToString()
    {
        return $"{base.ToString()}, довжина: {Length} м";
    }
}

class Dolphin : SeaItem
{
    public string Trick { get; set; }

    public Dolphin(string name, int age, string trick) : base(name, age)
    {
        Trick = trick;
    }

    public override string Kind => "Дельфін";

    public override string ToString()
    {
        return $"{base.ToString()}, вміє: {Trick}";
    }
}

class Turtle : SeaItem
{
    public int Weight { get; set; }

    public Turtle(string name, int age, int weight) : base(name, age)
    {
        Weight = weight;
    }

    public override string Kind => "Черепаха";

    public override string ToString()
    {
        return $"{base.ToString()}, вага: {Weight} кг";
    }
}

class Octopus : SeaItem
{
    public string Color { get; set; }

    public Octopus(string name, int age, string color) : base(name, age)
    {
        Color = color;
    }

    public override string Kind => "Восьминіг";

    public override string ToString()
    {
        return $"{base.ToString()}, колір: {Color}";
    }
}

class Oceanarium
{
    private List<SeaItem> items = new List<SeaItem>();

    public string Name { get; set; }

    public Oceanarium(string name)
    {
        Name = name;
    }

    public int Count => items.Count;

    public void Add(SeaItem item)
    {
        items.Add(item);
    }

    public void Show()
    {
        Console.WriteLine($"Океанаріум \"{Name}\", жителів: {Count}");
        for (int i = 0; i < items.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {items[i]}");
        }
    }
}

enum Position
{
    Goalkeeper,
    Defender,
    Midfielder,
    Forward
}

class Player
{
    private static string[] positionNames = { "Воротар", "Захисник", "Півзахисник", "Нападник" };

    public string Name { get; set; }
    public int Number { get; set; }
    public int Age { get; set; }
    public Position Position { get; set; }

    public Player(string name, int number, int age, Position position)
    {
        Name = name;
        Number = number;
        Age = age;
        Position = position;
    }

    public string PositionName => positionNames[(int)Position];

    public override string ToString()
    {
        return $"№{Number,-3} {Name,-20} {PositionName,-12} вік: {Age}";
    }
}

class FootballTeam
{
    private List<Player> players = new List<Player>();

    public string Name { get; set; }
    public string City { get; set; }

    public FootballTeam(string name, string city)
    {
        Name = name;
        City = city;
    }

    public int Count => players.Count;

    public void Add(Player player)
    {
        players.Add(player);
    }

    public void Show()
    {
        Console.WriteLine($"Команда \"{Name}\" ({City}), гравців: {Count}");
        foreach (Player player in players)
        {
            Console.WriteLine(player);
        }
    }
}

class Program
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;

        Console.WriteLine("Завдання 1");
        Oceanarium oceanarium = new Oceanarium("Морський світ");
        oceanarium.Add(new Shark("Брюс", 12, 3.5));
        oceanarium.Add(new Dolphin("Тоні", 7, "стрибати через обруч"));
        oceanarium.Add(new Turtle("Тортила", 85, 120));
        oceanarium.Show();

        Console.WriteLine("\nДодаємо нового жителя...");
        oceanarium.Add(new Octopus("Пауль", 3, "червоний"));
        oceanarium.Show();

        Console.WriteLine("\nЗавдання 2");
        FootballTeam team = new FootballTeam("Зірка", "Київ");
        team.Add(new Player("Андрій Мельник", 1, 28, Position.Goalkeeper));
        team.Add(new Player("Олег Ткаченко", 4, 25, Position.Defender));
        team.Add(new Player("Дмитро Кравчук", 8, 23, Position.Midfielder));
        team.Show();

        Console.WriteLine("\nДодаємо нового гравця...");
        team.Add(new Player("Максим Савченко", 9, 21, Position.Forward));
        team.Show();
    }
}
