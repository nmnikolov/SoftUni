namespace StringDisperser
{
    using System;

    public class StringDisperserTest
    {
        public static void Main()
        {
            StringDisperser stringDisperser = new StringDisperser("gosho", "pesho", "tanio");
            foreach (var ch in stringDisperser)
            {
                Console.Write(ch + " ");
            }

            StringDisperser deepCopy = stringDisperser.Clone() as StringDisperser;
            deepCopy.Strings.Add("add");

            Console.WriteLine("\n\nDeep copy:");
            foreach (var ch in deepCopy)
            {
                Console.Write(ch + " ");
            }

            Console.WriteLine();
            Console.WriteLine("\nCompare: {0}", stringDisperser.CompareTo(deepCopy));
            Console.WriteLine();
            Console.WriteLine(deepCopy);
        } 
    }
}