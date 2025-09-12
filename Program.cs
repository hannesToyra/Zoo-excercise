

using System.Formats.Asn1;

public class Program
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
            Prey.AddRange(new List<Animal> { new Goat(), new Jackal(), new WildCat(), new Kite()});
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
            Prey.AddRange(new List<Animal> { new Goat(), new Rabbit()});
        }
    }

    public class Owl : Animal
    {
        public Owl (string? animalName = null) : base(animalName)
        {
            Prey.Add(new Mouse());
        }
    }


    public class Snake : Animal
    {
        public Snake (string? animalName = null) : base(animalName)
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
        public WildCat (string? animalName = null) : base(animalName)
        {
            Prey.AddRange(new List<Animal> { new Rabbit(), new Mouse()});
        }
    }

    public class Cage
    {
        public List<Animal> AnimalList = new List<Animal>();

        public void GetAnimalsInsideCage(List<Animal> cagedAnimals)
        {
            if(cagedAnimals == null || cagedAnimals.Count == 0)
            {
                Console.WriteLine("There are currently no animals inside this cage");
                return;
            }

            foreach(Animal animal in cagedAnimals)
            {
                Console.Write($"{animal.Name}");
            }
        }

        public void AddAnimal(Animal animal)
        {
            

            foreach(Animal a in AnimalList)
            {
                if (animal.Prey.Any(prey => prey.GetType() == a.GetType() || a.GetType() == prey.GetType()))
                {
                    Console.WriteLine("Ooops! Seems like you put predator and prey in the same cage");
                    Console.WriteLine($"{a.GetType().Name} was eaten by {animal.GetType().Name}");
                    //AnimalList.Remove(a);
                } else if (animal.Prey.Any(prey => a.GetType() == prey.GetType()))
                {
                    Console.WriteLine("Ooops! Seems like you put predator and prey in the same cage");
                    Console.WriteLine($"{animal.GetType().Name} was eaten by {a.GetType().Name}");
                }
            }
            
            //lägg till nytt djur i listan
            AnimalList.Add(animal);
        }
    }

    public static void Main(string[] args)
    {
        Animal animal = new Animal("karl");

        Cage cage = new Cage();

        Lion aslan = new Lion("Fred");

        Lion leo = new Lion();

        Console.WriteLine(aslan.Name);

        //Console.WriteLine(aslan.Prey[0].Name);

        //cage.AnimalList.Add(aslan);

        //cage.AnimalList.Add(leo);

        Bird larry = new Bird();

        cage.AddAnimal(larry);

        cage.AddAnimal(leo);

        Mouse mickey = new Mouse();

        Console.WriteLine(mickey.Name);

        mickey.GetPreyInfo();

        larry.GetPreyInfo();

        leo.GetPreyInfo();
    }
}