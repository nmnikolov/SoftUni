package Shop.Models;

import Shop.Interfaces.Expirable;
import java.util.Date;

public class PurchaseManager {
    public static void processPurchase(Product product, Customer customer) throws Exception{
        checkQuantity(product);
        checkExpirationDate(product);
        checkBalance(product, customer);
        checkAgeRestioction(product, customer);

        product.setQuantity(product.getQuantity() - 1);
        customer.setBalance(customer.getBalance() - product.getPrice());

        System.out.printf("Purchase completed successfully.\n");
    }

    public static void checkQuantity(Product product) throws Exception{
        if (product.getQuantity() == 0) {
            throw new Exception("Product out of stock.");
        }
    }

    public static void checkExpirationDate(Product product) throws Exception{
        if (product instanceof Expirable) {
            Date expirationDate = ((Expirable) product).getExpirationDate();
            Date now = new Date();
            if (expirationDate.before(now)){
                throw new Exception("The product has expired.");
            }
        }
    }

    public static void checkBalance(Product product, Customer customer) throws Exception{
        if (customer.getBalance() - product.getPrice() < 0){
            throw new Exception("Not enough money to buy this product.");
        }
    }

    public static void checkAgeRestioction(Product product, Customer customer) throws Exception{
        if (product.getAgeRestriction() == AgeRestriction.Teenager){
            if (customer.getAge() < 14 || customer.getAge() >= 18 ){
                throw new Exception("This product can be sold only to teenagers.");
            }
        }

        if (product.getAgeRestriction() == AgeRestriction.Adult){
            if (customer.getAge() < 18){
                throw new Exception("You are too young to buy this product!");
            }
        }
    }
}