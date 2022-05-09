namespace MainLogic
{
    public class Owner
    {
        public string name;
        public Animal animal;

        public Owner(string name)
        {
            this.name = name;
            Observer.Instance.createdOwner.Invoke(this);
        }

        public void SetAnimal(Animal newAnimal)
        {
            if (animal == null) RemoveAnimal();
            Observer.Instance.addedAnimalToOwner.Invoke(this,newAnimal);
            animal = newAnimal;
            animal.state = AnimalState.owned;
        }

        public void RemoveAnimal()
        {
            Observer.Instance.removedAnimalFromOwner.Invoke(this, animal);
            animal.state = AnimalState.free;
            animal = null;
        }

        public void Clean()
        {
            animal.Clean();
        }
    }
}
