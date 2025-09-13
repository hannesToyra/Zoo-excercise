using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo
{
    public class Animal
    {
        public string? Name { get; set; }
        public List<Animal> Prey = new List<Animal>();

        public Animal(string? animalName = null)
        {
            Name = string.IsNullOrWhiteSpace(animalName) ? $"Unnamed {this.GetType().Name.ToLower()}" : animalName;
        }
        public void GetPreyInfo()
        {
            if (Prey.Count == 0)
            {
                Console.WriteLine($"The {this.GetType().Name.ToLower()} has no prey");
                return;
            }

            foreach (var preyAnimal in Prey)
            {
                Console.WriteLine($"The {this.GetType().Name.ToLower()} likes to eat {preyAnimal.GetType().Name.ToLower()}");
            }
        }
    }

    public class Lion : Animal
    {
        public Lion(string? animalName = null) : base(animalName)
        {
            Prey.AddRange(new List<Animal> { new Goat(), new Jackal(), new WildCat(), new Kite() });
        }
    }


    public class Mouse : Animal
    {

    }


    public class Goat : Animal
    {

    }

    public class Rabbit : Animal
    {
        public Rabbit(string? animalName = null) : base(animalName)
        {
            Prey.Add(new Mouse());
        }
    }

    public class Jackal : Animal
    {
        public Jackal(string? animalName = null) : base(animalName)
        {
            Prey.AddRange(new List<Animal> { new Goat(), new Rabbit() });
        }
    }

    public class Owl : Animal
    {
        public Owl(string? animalName = null) : base(animalName)
        {
            Prey.Add(new Mouse());
        }
    }


    public class Snake : Animal
    {
        public Snake(string? animalName = null) : base(animalName)
        {
            Prey.Add(new Mouse());
        }
    }

    public class Kite : Animal
    {
        public Kite(string? animalName = null) : base(animalName)
        {
            Prey.Add(new Snake());
        }
    }

    public class WildCat : Animal
    {
        public WildCat(string? animalName = null) : base(animalName)
        {
            Prey.AddRange(new List<Animal> { new Rabbit(), new Mouse() });
        }
    }
}
