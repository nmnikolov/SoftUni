import java.io.BufferedReader;
import java.io.BufferedWriter;
import java.io.FileReader;
import java.io.FileWriter;
import java.io.IOException;
import java.util.ArrayList;
import java.util.Collections;


public class _09_ListOfProducts {

	public static void main(String[] args) throws IOException {
			
		ArrayList<Product> products = new ArrayList<Product>();
		BufferedWriter writer = null;
	    
		try {
			BufferedReader reader = new BufferedReader(new FileReader("inputProducts.txt"));
			String readLine = reader.readLine();
	    	String[] line = null;
	    	
	    	while (readLine != null) {
				line = readLine.split(" ");
				products.add(new Product(line[0], Float.parseFloat(line[1])));
				readLine = reader.readLine();
			}
	    	
	    	reader.close();
	    	
	    	Collections.sort(products);
	    	
	    	writer = new BufferedWriter(new FileWriter("Output.txt"));
	    	
	    	for (Product product : products) {
	    		writer.write(String.format("%.2f %s\n", product.getPrice(), product.getName()));
			}
	    	
	    	writer.close();	    		        	        
	    } 
	    catch (Exception ex){   	
	    	System.out.println("error");
	    }	    	
	}	
}

class Product implements Comparable<Product>{	
	String name;
	float price;
	public Product(String name, float price) {
		this.name = name;
		this.price = price;
	}
	public float getPrice() {
		return price;
	}
	public void setPrice(float price) {
		this.price = price;
	}
	public String getName() {
		return name;
	}
	public void setName(String name) {
		this.name = name;
	}

	public int compareTo(Product compareFruit) {
      
		 double otherPrice = ((Product) compareFruit).getPrice();
		
		 //ascending order
		 if(this.price>otherPrice) return 1;
		 else
		 if(this.price==otherPrice) return 0;
		 return -1;
	}  
}