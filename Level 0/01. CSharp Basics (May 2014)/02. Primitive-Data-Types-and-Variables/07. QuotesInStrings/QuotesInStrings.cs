using System;

//Declare two string variables and assign them with following value:
// -->   The "use" of quotations causes difficulties.   <--
//Do the above in two different ways: with and without using quoted strings. Print the variables to ensure that their value was correctly defined.

class QuotesInStrings
{
    static void Main()
    {
        string a = "The \"use\" of quotations causes difficulties.";
        Console.WriteLine("Using escaping sequences: {0}", a);
        string b = @"The ""use"" of quotations causes difficulties.";
        Console.WriteLine("Using @ prefix: {0}", b);
    }
}