using Microsoft.EntityFrameworkCore;
using System;

namespace library
{
    public enum eClassifiationAnimal
    {
        Herbovores, Carnivores, Omnivores,
    }
    public enum eFavouriteFood { Meet, Plants, Everything,}
    [Comment("They are animals")]
    public abstract class Animal
    {
        public abstract string Country { get; set;  }
        public abstract bool HideFromOtherAnimals { get; set;  }
        public abstract string Name { get; set; }
        public abstract string WhatAniml { get; set; }
        public Animal(string country, bool hide, string name, string what)
        {
            Country = country;
            HideFromOtherAnimals = hide;
            Name = name;
            WhatAniml = what;
        }
        public void Deconstruct() { }
        public virtual void GetClassificationAnimal()
        {
            Console.WriteLine();
        }
        public virtual void GetFavoriteFood()
        {
            Console.WriteLine();
        }
        public virtual void SayHello() {  Console.WriteLine(); }
    }
    public abstract class Cow : Animal
    {
        public Cow(string county,bool hide, string name) : base (county, hide, name, "Cow") { }
        public override void GetClassificationAnimal()
        {
            Console.WriteLine(eClassifiationAnimal.Herbovores);
        }
        public override void GetFavoriteFood()
        {
            Console.WriteLine(eFavouriteFood.Plants);
        }
        public override void SayHello()
        {
            Console.WriteLine("Muuuuuuuu");
        }
    }
    public abstract class Lion : Animal
    {
        public Lion(string county, bool hide, string name) : base(county, hide, name, "Lion") { }
        public override void GetClassificationAnimal()
        {
            Console.WriteLine(eClassifiationAnimal.Carnivores);
        }
        public override void GetFavoriteFood()
        {
            Console.WriteLine(eFavouriteFood.Meet);
        }
        public override void SayHello()
        {
            Console.WriteLine("Raaaaaar");
        }
    }
    public abstract class Pig : Animal
    {
        public Pig(string county, bool hide, string name) : base(county, hide, name, "Pig") { }
        public override void GetClassificationAnimal()
        {
            Console.WriteLine(eClassifiationAnimal.Omnivores);
        }
        public override void GetFavoriteFood()
        {
            Console.WriteLine(eFavouriteFood.Everything);
        }
        public override void SayHello()
        {
            Console.WriteLine("Hruuuuuuuuu");
        }
    }
}