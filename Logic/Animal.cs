namespace Logic
{
    public class Animal
    {
        public int id { get; private set; }
        public static int LastUsedId = 0;

        public string name { get; private set; }
        public string nose { get; private set; }
        public string feet { get; private set; }
        public string eyes { get; private set; }

        public int eatenPerDay { get; private set; }

        public AnimalState state;
        public DateTime lastTimeCleaned;
        public DateTime lastTimeEaten;

        public Animal(string name)
        {
            this.name = name;
            eatenPerDay = 0;
            lastTimeCleaned = DateTime.Now;
            lastTimeEaten = DateTime.Now;
            state = AnimalState.free;
            id = ++LastUsedId;
            Observer.Instance.createdAnimal.Invoke(this);
        }

        public bool IsHappy()
        {
            if(state != AnimalState.free && DateTime.Now.Hour - lastTimeCleaned.Hour > 24) return false;
            return true;
        }

        public void Clean()
        {
            lastTimeCleaned = DateTime.Now;
            Observer.Instance.cleaned.Invoke(this);
        }


        public void Eat()
        {
            eatenPerDay++;
            lastTimeEaten = DateTime.Now;
            Observer.Instance.eated.Invoke(this);
        }

        public void Walk()
        {
            Observer.Instance.walked.Invoke(this);
        }
        public void Crawl()
        {
            Observer.Instance.crawled.Invoke(this);
        }

        public void Run()
        {
            if (DateTime.Now.Hour - lastTimeEaten.Hour > 8)
                Observer.Instance.runnded.Invoke(this, false);
            else
                Observer.Instance.runnded.Invoke(this, true);
        }

        public void Sing()
        {
            if (DateTime.Now.Hour - lastTimeEaten.Hour > 8)
                Observer.Instance.singed.Invoke(this, false);
            else
                Observer.Instance.singed.Invoke(this, true);
        }

        public void Fly()
        {
            if (DateTime.Now.Hour - lastTimeEaten.Hour > 8)
                Observer.Instance.flied.Invoke(this, false);
            else
                Observer.Instance.flied.Invoke(this, true);
        }

        public void SpendDay()
        {
            if (eatenPerDay <= 0 || eatenPerDay > 5) Die();
            eatenPerDay = 0;
        }

        public void Die()
        {

            Observer.Instance.died.Invoke(this);
        }
    }
    public enum AnimalState { free, owned, inZoo}
}
