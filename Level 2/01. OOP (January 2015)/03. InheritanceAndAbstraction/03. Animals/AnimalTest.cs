namespace Animal
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Models;

    public class AnimalTest
    {
        public static void Main()
        {
            Tomcat tomcat1 = new Tomcat("Tomcat", 13);
            Tomcat tomcat2 = new Tomcat("Tomcat", 3);
            Tomcat tomcat3 = new Tomcat("Tomcat", 10);

            Kitten kitten1 = new Kitten("Kitten", 1);
            Kitten kitten2 = new Kitten("Kitten", 1);
            Kitten kitten3 = new Kitten("Kitten", 9);

            Dog dog1 = new Dog("Dog", 15, Gender.Female);
            Dog dog2 = new Dog("Dog", 3, Gender.Male);
            Dog dog3 = new Dog("Dog", 7, Gender.Female);

            Frog frog1 = new Frog("Frog", 4, Gender.Female);
            Frog frog2 = new Frog("Frog", 0, Gender.Male);
            Frog frog3 = new Frog("Frog", 2, Gender.Female);

            IList<Animal> animals = new List<Animal>
            {
                tomcat1, tomcat2, tomcat3, kitten1, kitten2, kitten3, dog1, dog2, dog3, frog1, frog2, frog3
            };

            tomcat1.ProduceSound();
            kitten1.ProduceSound();
            dog1.ProduceSound();
            frog1.ProduceSound();
            
            double catsAverage = animals
                .Where(c => c is Cat)
                .Average(c => c.Age);

            double dogsAverage = animals
                .Where(c => c is Dog)
                .Average(c => c.Age);

            double frogsAverage = animals
                .Where(c => c is Frog)
                .Average(c => c.Age);

            Console.WriteLine("Average cats age: {0:F2}", catsAverage);
            Console.WriteLine("Average dogs age: {0:F2}", dogsAverage);
            Console.WriteLine("Average frogs age: {0:F2}", frogsAverage);
        }
    }
}