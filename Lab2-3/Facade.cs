using MainLogic;

namespace Lab2_3
{
    internal class Facade
    {
        static void Main(string[] args)
        {
            Observer observer = new Observer();
            List<Animal> animals = new List<Animal>();
            List<Owner> owners = new List<Owner>();
            List<Zoo> zoos = new List<Zoo>();

            observer.createdAnimal += (animal) => Console.WriteLine($"{animal.name} created");
            observer.walked += (animal)=> Console.WriteLine($"{animal.name} walked");
            observer.eated += (animal) => Console.WriteLine($"{animal.name} eated");
            observer.crawled += (animal) => Console.WriteLine($"{animal.name} crawled");
            observer.cleaned += (animal) => Console.WriteLine($"{animal.name} cleaned");
            observer.singed += (animal, wasAble) => Console.WriteLine($"{animal.name} singed: {wasAble}");
            observer.runnded += (animal, wasAble) => Console.WriteLine($"{animal.name} runnded: {wasAble}");
            observer.flied += (animal, wasAble) => Console.WriteLine($"{animal.name} flied: {wasAble}");
            observer.died += (animal) => Console.WriteLine($"{animal.name} died");

            observer.createdZoo += (zoo) => Console.WriteLine($"{zoo.name} zoo was created");
            observer.createdOwner += (owner) => Console.WriteLine($"{owner.name} owner was created");
            observer.removedAnimalFromZoo += (zoo, animal) => Console.WriteLine($"{animal.name} was removed from {zoo.name}");
            observer.removedAnimalFromOwner += (owner, animal) => Console.WriteLine($"{animal.name} was removed from {owner.name}");
            observer.addedAnimalToZoo += (zoo, animal) => Console.WriteLine($"{animal.name} added to {zoo.name}");
            observer.addedAnimalToOwner += (owner, animal) => Console.WriteLine($"{animal.name} added to {owner.name}");

            string input;
            while (true)
            {
                Console.WriteLine("\nEnter command id (just number):\n1.Create animal\n2.Show all animals\n3.Use animal action\n4.Add owner\n5.Set animal to owner\n6.Add zoo\n7.Add animal to zoo\n8.Exit");
                input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        Console.WriteLine("Enter name: ");
                        input = Console.ReadLine();
                        animals.Add(new Animal(input));
                        break;

                    case "2":
                        foreach (Animal animal in animals) Console.Write($"{animal.name} id:{animal.id}, ");
                        break;

                    case "3":
                        Console.WriteLine("Enter animal id: ");
                        input = Console.ReadLine();
                        try
                        {
                            int actionedAnimalId = int.Parse(input);
                            Animal actionedAnimal = animals.Find((a) => a.id == actionedAnimalId);
                            if (actionedAnimal != null)
                            {
                                Console.WriteLine("Enter acton id: 1.eat\n2.walk\n3.crawl\n4.run\n5.sing\n6.fly");
                                input = Console.ReadLine();
                                animals.Add(new Animal(input));
                                switch (input)
                                {
                                    case "1":
                                        actionedAnimal.Eat();
                                        break;
                                    case "2":
                                        actionedAnimal.Walk();
                                        break;
                                    case "3":
                                        actionedAnimal.Crawl();
                                        break;
                                    case "4":
                                        actionedAnimal.Run();
                                        break;
                                    case "5":
                                        actionedAnimal.Sing();
                                        break;
                                    case "6":
                                        actionedAnimal.Fly();
                                        break;
                                    default:
                                        Console.WriteLine("Enter correct acton id");
                                        break;
                                }
                            }
                            else
                            {
                                Console.WriteLine("Not found animal with this id");
                            }
                        }
                        catch
                        {
                            Console.WriteLine("Enter correct animal id");
                        }

                        break;

                    case "4":
                        Console.WriteLine("Enter name of owner: ");
                        input = Console.ReadLine();
                        owners.Add(new Owner(input));
                        break;

                    case "5":
                        Console.WriteLine("Enter animal id: ");
                        input = Console.ReadLine();
                        try
                        {
                            int animalId = int.Parse(input);
                            Animal animal = animals.Find((a) => a.id == animalId);
                            if (animal != null)
                            {
                                Console.WriteLine("Enter owner name: ");
                                input = Console.ReadLine();
                                Owner owner = owners.Find((o) => o.name == input);
                                if (owner != null)
                                    owner.SetAnimal(animal);
                                else
                                    Console.WriteLine("Not found owner with this name");

                            }
                            else
                                Console.WriteLine("Not found animal with this id");
                        }
                        catch
                        {
                            Console.WriteLine("Enter correct animal id");
                        }
                        break;

                    case "6":
                        Console.WriteLine("Enter name of zoo: ");
                        input = Console.ReadLine();
                        zoos.Add(new Zoo(input));
                        break;

                    case "7":
                        Console.WriteLine("Enter animal id: ");
                        input = Console.ReadLine();
                        try
                        {
                            int animalId = int.Parse(input);
                            Animal animal = animals.Find((a) => a.id == animalId);
                            if (animal != null)
                            {
                                Console.WriteLine("Enter zoo name: ");
                                input = Console.ReadLine();
                                Zoo zoo = zoos.Find((o) => o.name == input);
                                if (zoo != null)
                                    zoo.AddAnimal(animal);
                                else
                                    Console.WriteLine("Not found zoo with this name");

                            }
                            else
                                Console.WriteLine("Not found animal with this id");
                        }
                        catch
                        {
                            Console.WriteLine("Enter correct animal id");
                        }
                        break;

                    case "8":
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("Enter correct command");
                        break;
                        
                }
            }
        }
    }
}
