package Shop.Models;

import Shop.Interfaces.Buyable;

public abstract class Product implements Buyable{
    private String name;
    private double price;
    private int quantity;
    private AgeRestriction ageRestriction;

    protected Product(String name, double price, int quantity, AgeRestriction ageRestriction) throws Exception{
        this.setName(name);
        this.setPrice(price);
        this.setQuantity(quantity);
        this.setAgeRestriction(ageRestriction);
    }

    public String getName() {
        return this.name;
    }

    public void setName(String name) throws Exception{
        if(name == null || name.trim() == ""){
            throw new Exception("Name cannot be empty.");
        }

        this.name = name;
    }

    @Override
    public double getPrice(){
        return this.price;
    }

    public void setPrice(double price) throws Exception{
        if(price < 0){
            throw new Exception("Price shoud be possitive.");
        }

        this.price = price;
    }

    public int getQuantity() {
        return this.quantity;
    }

    public void setQuantity(int quantity) throws Exception{
        if(quantity < 0){
            throw new Exception("Quantity shoud be possitive.");
        }

        this.quantity = quantity;
    }

    public AgeRestriction getAgeRestriction() {
        return this.ageRestriction;
    }

    public void setAgeRestriction(AgeRestriction ageRestriction) {
        this.ageRestriction = ageRestriction;
    }

    @Override
    public String toString() {
        String result = String.format("Product type: %s\n", this.getClass().getSimpleName());
        result += String.format("Name: %s\n", this.getName());
        result += String.format("Price: %.2f\n", this.getPrice());
        result += String.format("Quantity: %d\n", this.getQuantity());
        result += String.format("Age restriction: %s\n", this.getAgeRestriction());

        return result;
    }
}