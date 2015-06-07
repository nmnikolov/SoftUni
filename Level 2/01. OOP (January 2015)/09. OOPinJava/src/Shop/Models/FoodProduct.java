package Shop.Models;

import Shop.Interfaces.Expirable;

import java.text.SimpleDateFormat;
import java.util.Date;
import java.util.concurrent.TimeUnit;

public class FoodProduct extends Product implements Expirable{
    private final static SimpleDateFormat dateFormat = new SimpleDateFormat("dd.MM.yyyy");
    private Date expirationDate;

    public FoodProduct(String name, double price, int quantity, AgeRestriction ageRestriction, Date expirationDate) throws Exception {
        super(name, price, quantity, ageRestriction);
        this.setExpirationDate(expirationDate);
    }

    @Override
    public double getPrice() {
        if(daysUntilExpiration() <= 15){
            return super.getPrice() * 0.75;
        }

        return super.getPrice();
    }

    public void setExpirationDate(Date expirationDate) {
        this.expirationDate = expirationDate;
    }

    @Override
    public Date getExpirationDate() {
        return this.expirationDate;
    }

    public long daysUntilExpiration(){
        long diff = this.getExpirationDate().getTime() - new Date().getTime();
        long days = TimeUnit.DAYS.convert(diff, TimeUnit.MILLISECONDS);

        return days;
    }

    @Override
    public String toString() {
        String result = super.toString();
        result += String.format("Expiration date: %s\n", dateFormat.format(this.getExpirationDate()));

        return result;
    }
}
