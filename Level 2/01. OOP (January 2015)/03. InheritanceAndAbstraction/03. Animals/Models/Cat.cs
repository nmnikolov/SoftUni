namespace Animal.Models
{
    using System;

    public abstract class Cat : Animal
    {
        protected Cat(string name, int age, Gender gender)
            : base(name, age, gender)
        {
        }

        public override void ProduceSound()
        {
            Console.WriteLine("meow meow");
        }
    }
}