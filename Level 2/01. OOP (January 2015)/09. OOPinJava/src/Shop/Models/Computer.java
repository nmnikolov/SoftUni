package Shop.Models;

public class Computer extends ElectonicsProduct {
    public Computer(String name, double price, int quantity, AgeRestriction ageRestriction) throws Exception {
        super(name, price, quantity, ageRestriction, 24);
    }

    @Override
    public double getPrice(){
        if (this.getQuantity() > 1000) {
            return super.getPrice() * 0.95;
        }

        return super.getPrice();
    }
}