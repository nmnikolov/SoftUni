package Shop.Models;

public class Customer {
    private String name;
    private int age;
    private double balance;

    public Customer(String name, int age, double balance) throws Exception{
        this.setName(name);
        this.setAge(age);
        this.setBalance(balance);
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

    public int getAge() {
        return this.age;
    }

    public void setAge(int age) throws Exception{
        if (age < 0) {
            throw new Exception("Age should be positive");
        }

        this.age = age;
    }

    public double getBalance() {
        return this.balance;
    }

    public void setBalance(double balance) throws Exception{
        if (balance < 0) {
            throw new Exception("Balance should be positive");
        }

        this.balance = balance;
    }

    @Override
    public String toString() {
        String result = "Customer:\n";
        result += String.format("Name: %s\n", this.getName());
        result += String.format("Aeg: %d\n", this.getAge());
        result += String.format("Balance: %.2f\n", this.getBalance());

        return result;
    }
}