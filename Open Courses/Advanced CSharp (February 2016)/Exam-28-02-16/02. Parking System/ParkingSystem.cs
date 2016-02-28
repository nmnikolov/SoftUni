using System;
using System.Collections.Generic;
using System.Linq;

namespace ParkingSystem
{
    public class ParkingSystem
    {
        private static HashSet<string> occupied = new HashSet<string>();
        private static int rows;
        private static int cols;

        public static void Main()
        {
            ReadDimensions();
            ParkCars();
        }

        private static void ParkCars()
        {
            string parkingRow = Console.ReadLine();

            while (parkingRow != "stop")
            {
                int[] rowData =
                    parkingRow.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse)
                        .ToArray();
                int startingRow = rowData[0];
                int x = rowData[1];
                int y = rowData[2];

                string coodinates = string.Format("{0}|{1}", x, y);

                if (!occupied.Contains(coodinates))
                {
                    occupied.Add(coodinates);

                    int distance = Math.Abs(startingRow - x) + y + 1;
                    Console.WriteLine(distance);
                }
                else
                {
                    bool found = false;

                    int closestToSpot = int.MaxValue;
                    SortedSet<int> columns = new SortedSet<int>();

                    for (int i = 1; i < cols; i++)
                    {
                        coodinates = string.Format("{0}|{1}", x, i);

                        if (!occupied.Contains(coodinates))
                        {
                            int distanceFromSpot = Math.Abs(y - i);
                            if (distanceFromSpot == closestToSpot)
                            {
                                columns.Add(i);
                                found = true;
                            }
                            else if (distanceFromSpot <= closestToSpot)
                            {
                                closestToSpot = distanceFromSpot;
                                columns.Clear();
                                columns.Add(i);
                                found = true;
                            }
                        }
                    }

                    if (!found)
                    {
                        Console.WriteLine("Row {0} full", x);
                    }
                    else
                    {
                        occupied.Add(string.Format("{0}|{1}", x, columns.First()));
                        Console.WriteLine(Math.Abs(startingRow - x) + columns.First() + 1);
                    }
                }

                parkingRow = Console.ReadLine();
            }
        }

        private static void ReadDimensions()
        {
            int[] dimensions =
                Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            rows = dimensions[0];
            cols = dimensions[1];
        }
    }
}