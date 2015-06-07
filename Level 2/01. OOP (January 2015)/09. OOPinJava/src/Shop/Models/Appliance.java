package Shop.Models;

public class Appliance extends ElectonicsProduct {
    public  Appliance(String name, double price, int quantity, AgeRestriction ageRestriction) throws Exception {
        super(name, price, quantity, ageRestriction, 6);
    }

    @Override
    public double getPrice(){
        if (this.getQuantity() < 50) {
            return super.getPrice() * 1.05;
        }

        return super.getPrice();
    }
}
