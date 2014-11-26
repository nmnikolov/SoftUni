using System;

class Eclipse
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        string frame = " " + new string('*', 2 * n - 2) + " ";
        string lens = "*" + new string('/', 2 * n - 2) + "*";
        string connection = new string(' ', n - 1);
        string bridge = new string('-', n - 1);

        for (int i = 0; i < n; i++)
        {
            if (i == 0 || i == n - 1)
            {
                Console.WriteLine(frame + connection + frame);
            }
            else if (i == n / 2)
            {
                Console.WriteLine(lens + bridge + lens);
            }
            else
            {
                Console.WriteLine(lens + connection + lens);
            }
        }    
    }
}