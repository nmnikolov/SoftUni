package Shop;

import Shop.Interfaces.Expirable;
import Shop.Models.*;
import java.text.SimpleDateFormat;
import java.util.Arrays;
import java.util.List;

public class ShopTest{

    public static void main(String[] args) throws Exception{
        SimpleDateFormat dateFormat = new SimpleDateFormat("dd.MM.yyyy");

        FoodProduct bananas = new FoodProduct("Bananas", 1.3, 347, AgeRestriction.None, dateFormat.parse("16.11.2015"));
        FoodProduct cigars = new FoodProduct("420 Blaze it fgt", 96.90, 1400, AgeRestriction.Adult, dateFormat.parse("16.10.2015"));
        Computer lenovo = new Computer("Lenovo ThinkPad E51", 1235.34, 57, AgeRestriction.None);
        Computer sony = new Computer("Sony Vaio", 1780.00, 34, AgeRestriction.Teenager);
        Appliance cellPhone = new Appliance("Apple Iphone 6", 1834.68, 17, AgeRestriction.Teenager);
        Appliance tablet = new Appliance("Toshiba", 90.5, 13, AgeRestriction.Adult);

        Customer pecata = new Customer("Pecata", 17, 30.00);
        Customer gopeto = new Customer("Gopeto", 12, 0.44);
        Customer ivan = new Customer("Ivan", 26, 3570.70);
        Customer ginka = new Customer("Ginka", 78, 1470.99);

        List<Product> products = Arrays.asList(bananas, cigars, lenovo, sony, cellPhone, tablet);
        List<Customer> customers = Arrays.asList(pecata, gopeto, ivan, ginka);

        System.out.println("<-----Get the name of the first product with the soonest date of expiration----->");
        String filterByExpirationDate = products.stream()
                .filter(p -> p instanceof Expirable)
                .map(p -> (Expirable) p)
                .sorted((d1, d2) -> d1.getExpirationDate().compareTo(d2.getExpirationDate()))
                .findFirst()
                .map(p -> (Product) p)
                .map(Product::getName)
                .get();

        System.out.println(filterByExpirationDate + "\n");

        System.out.println("<-----Get all products with adult age restriction and sort them by price in ascending order----->");
        products.stream()
                .filter(p -> p.getAgeRestriction() == AgeRestriction.Adult)
                .sorted((p1, p2) -> Double.compare(p1.getPrice(), p2.getPrice()))
                .forEach(System.out::println);

        try {
            System.out.println("<-----Test Purchase manager----->");
            for (int i = 0; i < 5; i++) {
                int randomProduct = (int)(Math.random() * products.size());
                int randomCustomer = (int)(Math.random() * customers.size());
                PurchaseManager.processPurchase(products.get(randomProduct), customers.get(randomCustomer));
            }

            PurchaseManager.processPurchase(cigars, pecata);
            PurchaseManager.processPurchase(cigars, gopeto);
        } catch (Exception ex){
            System.out.println(ex);
        }
    }
}