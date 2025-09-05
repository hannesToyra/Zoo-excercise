

public class Program
{

    public class Animal
    {
        public string? Name { get; set; }
        //public List<Animal> Prey { get; set; }

        public Animal(string? animalName = null/*, List<Animal> prey*/) 
        {
            Name = string.IsNullOrEmpty(animalName) ? $"Unnamed {this.GetType().Name.ToLower()}" : animalName;
            //Prey = prey.Count > 0 ? prey : new List<Animal>();
        }

    }

    public class Rat : Animal
    {

    }



    public class Cage
    {
        public List<Animal> Animals { get; set; }

    }


    public class Zoo
    {
        public List<Cage> Cages { get; set; }

        public void GetNumberOfCages()
        {
            Console.WriteLine(Cages.Count);
        }
    }

    public static void Main(string[] args)
    {
        Animal test = new Animal();
        Console.WriteLine(test.Name);

        Rat rat = new Rat();
        Console.WriteLine(rat.Name);
    }
}