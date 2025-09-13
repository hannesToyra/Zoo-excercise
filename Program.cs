

using System.Formats.Asn1;
using Zoo;

public class Program
{
    public class Cage
    {
        public List<Animal> AnimalList = new List<Animal>();

        public void GetAnimalsInsideCage()
        {
            if(AnimalList == null || AnimalList.Count == 0)
            {
                Console.WriteLine("There are currently no animals inside this cage");
                return;
            }

            foreach(Animal animal in AnimalList)
            {
                Console.Write($"{animal.Name}");
            }
        }

        public bool IsPredatorOf(Animal predator, Animal potentialPrey)
        {
            return predator.Prey.Any(prey => prey.GetType() == potentialPrey.GetType());
        }

        public void CageConflict(Animal predator, Animal prey)
        {
            Console.WriteLine("Ooops! Seems like you put predator and prey in the same cage");
            Console.WriteLine($"{prey.GetType().Name} was eaten by {predator.GetType().Name}");
        }

        public void AddAnimal(Animal animalToAdd)
        {
            List<Animal> animalsToRemove = new List<Animal>();

            foreach(Animal animalInCage in AnimalList)
            {
                if (IsPredatorOf(animalToAdd, animalInCage))
                {
                    CageConflict(animalToAdd, animalInCage);
                    animalsToRemove.Add(animalInCage);
                } 
                else if (IsPredatorOf(animalInCage, animalToAdd))
                {
                    CageConflict(animalInCage, animalToAdd);
                    return;
                }
            }

            foreach (Animal eatenAnimal in animalsToRemove) 
            {
                AnimalList.Remove(eatenAnimal);
            }

            AnimalList.Add(animalToAdd);
        }
    }

    public class Zoo
    {
        public List<Cage> cages = new List<Cage>();

        public void GetNumberOfCages()
        {
            if (cages == null || cages.Count == 0)
            {
                Console.WriteLine("There are no cages at the zoo");
                return;
            }

            Console.WriteLine($"There are currently {cages.Count} at the zoo");
        }
    }

    public static void Main(string[] args)
    {
        Animal animal = new Animal("karl");

        Cage cage = new Cage();

        Lion aslan = new Lion("Fred");

        Lion leo = new Lion();

        cage.AddAnimal(leo);

        Mouse mickey = new Mouse();

        Console.WriteLine(mickey.Name);

        mickey.GetPreyInfo();

        leo.GetPreyInfo();


        WildCat cat = new WildCat();

        cat.GetPreyInfo();


        Cage newCage = new Cage();

        

        //Zoo zoo = new Zoo();

        //zoo.GetNumberOfCages();

        Rabbit rabbit = new Rabbit();

        newCage.AddAnimal(cat);

        newCage.AddAnimal(rabbit);
        
        newCage.GetAnimalsInsideCage();
    }
}