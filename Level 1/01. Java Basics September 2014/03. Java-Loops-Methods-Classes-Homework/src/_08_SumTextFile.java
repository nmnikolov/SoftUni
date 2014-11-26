import java.io.BufferedReader;
import java.io.FileReader;
import java.io.IOException;


public class _08_SumTextFile {

	public static void main(String[] args) throws IOException {
		
		BufferedReader br = new BufferedReader(new FileReader("input.txt"));
	    try {
	        String line = br.readLine();
	        long sum = 0;
	        while (line != null) {
	        	if (!line.equals("")) {
	        		sum += Long.parseLong(line);				
				}           
	            line = br.readLine();
	        }	        
	        System.out.println(sum);	        
	    } 
	    catch (Exception ex){   	
	    	System.out.println("error");
	    }	    
	    finally {
	        br.close();
	    }		
	}	
}