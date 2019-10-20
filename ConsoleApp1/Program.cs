using System.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
//public delegate void Print(int value);

class Person
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
}

class Pet
{
    public string Name { get; set; }
    public Person Owner { get; set; }
}

public class Program
{

    public static void Main(string[] args)
    {
        LeftOuterJoinExample();
    }

    public static void LeftOuterJoinExample()
    {
        Person magnus = new Person { FirstName = "Magnus", LastName = "Hedlund" };
        Person terry = new Person { FirstName = "Terry", LastName = "Adams" };
        Person charlotte = new Person { FirstName = "Charlotte", LastName = "Weiss" };
        Person arlene = new Person { FirstName = "Arlene", LastName = "Huff" };

        Pet barley = new Pet { Name = "Barley", Owner = terry };
        Pet boots = new Pet { Name = "Boots", Owner = terry };
        Pet whiskers = new Pet { Name = "Whiskers", Owner = charlotte };
        Pet bluemoon = new Pet { Name = "Blue Moon", Owner = terry };
        Pet daisy = new Pet { Name = "Daisy", Owner = magnus };

        // Create two lists.
        List<Person> people = new List<Person> { magnus, terry, charlotte, arlene };
        List<Pet> pets = new List<Pet> { barley, boots, whiskers, bluemoon, daisy };

        var query = from person in people
            join pet in pets on person equals pet.Owner into gj
            from subpet in gj.DefaultIfEmpty()
                //select new { person.FirstName, PetName = subpet?.Name ?? String.Empty };
            select new { person.FirstName, PetName = subpet?.Name ?? String.Empty, NewName = true };

        //foreach (var v in query)
        //{
        //    Console.WriteLine($"{v.FirstName + ":",-15}{v.PetName}{v.NewName}");
        //}

        var query1 = from q in query where q.PetName == String.Empty select new {q.FirstName, q.NewName, q.PetName};

        //query1 contains those things in people that are not in pets
        foreach (var v in query1)
        {
            Console.WriteLine($"{v.FirstName + ":",-15}{v.PetName}{v.NewName}");
        }
    }

    private static void PrintDel(int value)
    {
        Console.WriteLine(value);
    }



}