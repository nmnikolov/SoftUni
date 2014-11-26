using System;

class SandGlass
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int dot = 0;
        int asterik = n;

        for (int i = 0; i < n; i++)
        {
            string row = new string('.', dot) + new string('*', asterik) + new string('.', dot);
            Console.WriteLine(row);

            if (i < n / 2)
            {
                asterik -= 2;
                dot++;
            }
            else
            {
                asterik += 2;
                dot--;
            }            
        }
    }
}