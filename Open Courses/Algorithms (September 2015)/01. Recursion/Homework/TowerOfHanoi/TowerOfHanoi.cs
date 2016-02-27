namespace TowerOfHanoi
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class TowerOfHanoi
    {
        private static int stepsTaken = 0;

        private static Stack<int> _source;
        private static readonly Stack<int> _destination = new Stack<int>();
        private static readonly Stack<int> _spare = new Stack<int>();

        public static void Main()
        {
            int numberOfDisks = ReadDisksNumber();
            _source = new Stack<int>(Enumerable.Range(1, numberOfDisks).Reverse());
            PrintRods();
            MoveDisks(numberOfDisks, _source, _destination, _spare);
        }

        private static void MoveDisks(int bottomDisk, Stack<int> source, Stack<int> destination, Stack<int> spare)
        {
            if (bottomDisk == 1)
            {
                destination.Push(source.Pop());
                PrintRods(bottomDisk);
            }
            else
            {
                MoveDisks(bottomDisk -1, source, spare, destination);
                destination.Push(source.Pop());
                PrintRods(bottomDisk);
                MoveDisks(bottomDisk -1, spare, destination, source);
            }
        }

        private static void PrintRods(int? bottomDisk = null)
        {
            if (bottomDisk != null)
            {
                Console.WriteLine("Step #{0}: Moved disk {1}", ++stepsTaken, bottomDisk);
            }
            
            Console.WriteLine("Source: {0}", string.Join(", ", _source.Reverse()));
            Console.WriteLine("Destination: {0}", string.Join(", ", _destination.Reverse()));
            Console.WriteLine("Spare: {0}", string.Join(", ", _spare.Reverse()));
            Console.WriteLine();
        }

        private static int ReadDisksNumber()
        {
            try
            {
                Console.Write("Enter number of disks: ");
                var disks = int.Parse(Console.ReadLine());
                if (disks < 1)
                {
                    throw new InvalidOperationException("Number of disks should be greater than 0");
                }

                return disks;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return ReadDisksNumber();
            }

        }
    }
}
