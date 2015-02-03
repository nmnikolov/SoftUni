namespace Company.Interfaces
{
    public interface ICustomer
    {
        decimal PurchasesAmmount { get; set; }

        void AddPurchasePrice(decimal purchasePrice);

        string ToString();
    }
}