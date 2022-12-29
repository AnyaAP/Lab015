namespace Lab015c
{
    class Program
    {
        static void Main(string[] args)
        {
            var r = new Random();
            (new Thread(() =>
            {
                Singleton rand1 = new Singleton(r.Next(1, 100));
                rand1 = rand1.GetInstance();
                Console.WriteLine(rand1.number);
            })).Start();
            Singleton rand2 = new Singleton(r.Next(1, 100));
            rand2 = rand2.GetInstance();
            Console.WriteLine(rand2.number);
        }
    }

    public class Singleton
    {
        public static Singleton? singletonInstance;

        public int number { get; set; }
        public Singleton(int i)
        {
            number = i;
        }
        private static object syncRoot = new();

        public Singleton GetInstance()
        {
            if (singletonInstance == null)
            {
                lock (syncRoot)
                {
                    if (singletonInstance == null)
                        singletonInstance = new Singleton(number);
                }
            }
            return singletonInstance;
        }
    }
}