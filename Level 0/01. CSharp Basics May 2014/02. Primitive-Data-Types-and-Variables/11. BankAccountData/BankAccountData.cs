using System;

//A bank account has a holder name (first name, middle name and last name), available amount of money (balance), bank name, IBAN, 3 credit card numbers associated with 
//the account. Declare the variables needed to keep the information for a single bank account using the appropriate data types and descriptive names.

class BankAccountData
{
    static void Main()
    {
        string firstName = "Ivan";
        string middleName = "Ivanov";
        string lastName = "Ivanov";
        decimal accountBallance = 12749.4678M;
        string moneyType = "BGN";
        string bankName = "Bulgarian National Bank";
        string iBan = "BG80 BNBG 9661 1020 3456 78";
        string visaCreditCard = "4111111111111111";
        string maestroCreditCard = "4012888888881881";
        string virtualVisaCreditCard = "5019717010103742";
        Console.WriteLine("First name: \t\t  {0}", firstName);
        Console.WriteLine("Midlle name: \t\t  {0}", middleName);
        Console.WriteLine("Last name: \t\t  {0}", lastName);
        Console.WriteLine("Account ballance: \t  {0:N2} {1}", accountBallance, moneyType);
        Console.WriteLine("Bank: \t\t\t  {0}", bankName);
        Console.WriteLine("IBAN: \t\t\t  {0}", iBan);
        Console.WriteLine("Visa card number: \t  {0}", visaCreditCard);
        Console.WriteLine("Maestro card number: \t  {0}", maestroCreditCard);
        Console.WriteLine("Virtual Visa card number: {0}", virtualVisaCreditCard);
    }
}