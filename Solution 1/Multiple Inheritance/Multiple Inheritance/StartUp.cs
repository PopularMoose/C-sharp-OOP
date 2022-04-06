using System;

namespace Farm
{
   public  class StartUp
    {
        static void Main(string[] args)
        {
            Puppy puppy = new Puppy();
            puppy.Eat();
            puppy.Bark();
            puppy.Weep();


            Console.WriteLine(puppy.Eat());
            Console.WriteLine(puppy.Bark());
            Console.WriteLine(puppy.Weep());
        }
    }
}
