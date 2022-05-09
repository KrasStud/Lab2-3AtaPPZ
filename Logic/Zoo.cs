using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class Zoo
    {
        public string name { get; private set; }
        public List<Animal> Animals = new List<Animal>();

        public Zoo(string name)
        {
            this.name = name;
            Observer.Instance.createdZoo.Invoke(this);
        }

        public void RemoveAnimal(int id)
        {
            Animal removedAnimal = Animals.Find((an) => an.id == id);
            Observer.Instance.removedAnimalFromZoo.Invoke(this, removedAnimal);
            removedAnimal.state = AnimalState.free;
            Animals.Remove(removedAnimal);
        }

        public void RemoveAnimal(Animal animal)
        {
            Observer.Instance.removedAnimalFromZoo.Invoke(this, animal);
            animal.state = AnimalState.free;
            Animals.Remove(animal);
        }

        public void AddAnimal(Animal animal)
        {
            Observer.Instance.addedAnimalToZoo.Invoke(this, animal);
            animal.state = AnimalState.inZoo;
            Animals.Add(animal);
        }

        public void CleanAllPets()
        {
            foreach (Animal animal in Animals) animal.Clean();
        }
        public void CleanPet(int id)
        {
            Animals.Find((an) => an.id == id).Clean();
        }
    }
}
