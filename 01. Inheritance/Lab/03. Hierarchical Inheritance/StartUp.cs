using System;

namespace Farm
{
    public class StartUp
    {
        static void Main(string[] args)
        {

            Dog puppy = new Dog();
            puppy.Eat();
            puppy.Bark();


            Cat cat = new Cat();
            cat.Eat();
            cat.Meow();

        }
    }
}
