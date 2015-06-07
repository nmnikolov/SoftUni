package Shop.Models;

public abstract class ElectonicsProduct extends Product {
    private int guaranteePeriodMonths;

    protected ElectonicsProduct(String name, double price, int quantity, AgeRestriction ageRestriction, int guaranteePeriodMonths) throws Exception {
        super(name, price, quantity, ageRestriction);
        this.setGuaranteePeriodMonths(guaranteePeriodMonths);
    }

    public int getGuaranteePeriodMonths() {
        return this.guaranteePeriodMonths;
    }

    public void setGuaranteePeriodMonths(int guarantee) throws Exception{
        if (guarantee < 0) {
            throw new Exception("Guarantee cannot be negative.");
        }

        this.guaranteePeriodMonths = guarantee;
    }

    @Override
    public String toString() {
        String result = super.toString();
        result += String.format("Guarantee: %d months\n", this.getGuaranteePeriodMonths());

        return result;
    }
}