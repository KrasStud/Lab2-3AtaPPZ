namespace MainLogic
{
    public class Observer
    {
        public static Observer Instance;
        public Action<Animal> createdAnimal;
        public Action<Animal> walked;
        public Action<Animal> crawled;
        public Action<Animal, bool> runnded;
        public Action<Animal, bool> singed;
        public Action<Animal, bool> flied;
        public Action<Animal> cleaned;
        public Action<Animal> eated;
        public Action<Animal> died;

        public Action<Owner> createdOwner;
        public Action<Zoo> createdZoo;
        public Action<Owner,Animal> addedAnimalToOwner;
        public Action<Zoo,Animal> addedAnimalToZoo;
        public Action<Owner,Animal> removedAnimalFromOwner;
        public Action<Zoo,Animal> removedAnimalFromZoo;
        public Observer()
        {
            if (Instance == null)
                Instance = this;
        }
    }
}
