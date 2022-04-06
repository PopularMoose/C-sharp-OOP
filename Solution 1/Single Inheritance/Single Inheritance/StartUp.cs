using System;

namespace Farm
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Dog dog = new Dog();
            dog.Bark();
            dog.Bark();

            Console.WriteLine(dog.Bark());
            Console.WriteLine(dog.Bark());
        }
    }
}
