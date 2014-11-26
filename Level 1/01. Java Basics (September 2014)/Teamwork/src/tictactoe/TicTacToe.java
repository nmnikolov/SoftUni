package tictactoe;

import java.io.File;

import javafx.application.Application;
import javafx.application.Platform;
import javafx.event.ActionEvent;
import javafx.event.EventHandler;
import javafx.scene.Scene;
import javafx.scene.control.Button;
import javafx.scene.control.Label;
import javafx.scene.image.Image;
import javafx.scene.image.ImageView;
import javafx.scene.layout.Pane;
import javafx.stage.Stage;

/**
 * @author Team "Fashion Fuchsia"
 */

public class TicTacToe extends Application {
	
	//add variables
	static int playerToStartFirst = 1;
	static int playerTurn = playerToStartFirst;
	static int xPlayerScore = 0;
	static int oPlayerScore = 0;
	static int count = 0;
	static int[] board = new int[9];
	
	//make buttons and labels
	static Button btn1 = new Button("");
	static Button btn2 = new Button("");
	static Button btn3 = new Button("");
	static Button btn4 = new Button("");
	static Button btn5 = new Button("");
	static Button btn6 = new Button("");
	static Button btn7 = new Button("");
	static Button btn8 = new Button("");
	static Button btn9 = new Button("");
	static Button newGame = new Button("New Game");
	static Button resetScore = new Button("Reset Score");
	static Button exitGame = new Button("Exit");
	static Label status = new Label();
	static Label xScore = new Label("X score: 0");
	static Label oScore = new Label("O score: 0");	
	static Label version = new Label("v1.0");
	
	//load X and O graphics
	static File xFile = new File("images/blue-cross-icon.png");
	static Image xImage = new Image(xFile.toURI().toString());  
	//static Image xImage = new Image("http://icons.iconarchive.com/icons/double-j-design/origami-colored-pencil/128/blue-cross-icon.png"); 
	static File oFile = new File("images/green-cd-icon.png");
	static Image oImage = new Image(oFile.toURI().toString());	
	//static Image oImage = new Image("http://icons.iconarchive.com/icons/double-j-design/origami-colored-pencil/128/green-cd-icon.png");	
	
	
	@Override
	public void start(Stage primaryStage) {
			
		// set buttons and labels size and add ID-s
		btn1.setPrefSize(200, 200);
		btn2.setPrefSize(200, 200);
		btn3.setPrefSize(200, 200);
		btn4.setPrefSize(200, 200);
		btn5.setPrefSize(200, 200);
		btn6.setPrefSize(200, 200);
		btn7.setPrefSize(200, 200);
		btn8.setPrefSize(200, 200);
		btn9.setPrefSize(200, 200);		
		newGame.setPrefSize(105, 50);	
		resetScore.setPrefSize(105, 50);
		exitGame.setPrefSize(105, 50);
		xScore.setId(("xScore"));
		oScore.setId(("oScore"));
		status.setId(("status"));
		status.setText("X's turn");		
		version.setId(("version"));
				 
		//setLayouts for all buttons and labels
		btn1.setLayoutX(0);
		btn1.setLayoutY(0);
		btn2.setLayoutX(200);
		btn2.setLayoutY(0);
		btn3.setLayoutX(400);
		btn3.setLayoutY(0);
		btn4.setLayoutX(0);
		btn4.setLayoutY(200);
		btn5.setLayoutX(200);
		btn5.setLayoutY(200);
		btn6.setLayoutX(400);
		btn6.setLayoutY(200);
		btn7.setLayoutX(0);
		btn7.setLayoutY(400);
		btn8.setLayoutX(200);
		btn8.setLayoutY(400);
		btn9.setLayoutX(400);
		btn9.setLayoutY(400);	
		newGame.setLayoutX(710);
		newGame.setLayoutY(10);
		resetScore.setLayoutX(710);
		resetScore.setLayoutY(80);
		exitGame.setLayoutX(710);
		exitGame.setLayoutY(150);
		xScore.setLayoutX(690);
		xScore.setLayoutY(250);
		oScore.setLayoutX(688);
		oScore.setLayoutY(300);	
		status.setLayoutX(680);
		status.setLayoutY(470);
		version.setLayoutX(860);
		version.setLayoutY(575);
		
		//make Pane and add buttons and labels to that Pane
		Pane root = new Pane();
		root.getChildren().add(btn1);
		root.getChildren().add(btn2);
		root.getChildren().add(btn3);
		root.getChildren().add(btn4);
		root.getChildren().add(btn5);
		root.getChildren().add(btn6);
		root.getChildren().add(btn7);
		root.getChildren().add(btn8);
		root.getChildren().add(btn9);
		root.getChildren().add(newGame);
		root.getChildren().add(resetScore);
		root.getChildren().add(exitGame);
		root.getChildren().add(xScore);
		root.getChildren().add(oScore);
		root.getChildren().add(status);
		root.getChildren().add(version);
	  
		
		// Eventhandler for buttons
		Button[] buttons = {btn1,btn2,btn3,btn4,btn5,btn6,btn7,btn8,btn9};
		for (int i = 0; i < buttons.length; i++) {
			buttonAction(buttons[i], i);		
		}	
				
		// make Scene
		Scene scene = new Scene(root, 900, 600);
		primaryStage.setTitle("Tic-Tac-Toe");
		primaryStage.setScene(scene);
		scene.getStylesheets().add(TicTacToe.class.getResource("button_effects.css").toExternalForm());
		primaryStage.show();	
		newGame(buttons);	
		resetScore();
		exitGame();
	}
	
	// set Action when btn1..9 pressed
	static void buttonAction(Button btn, int i){
		
		btn.setOnAction(new EventHandler<ActionEvent>() {
			
			public void handle(ActionEvent e) {
				
				if (playerTurn == 1) { //button action if the active player is X										
						btn.setGraphic(new ImageView(xImage));					
						playerTurn = -playerTurn;			
						board[i] = 1;	
						count++;
						
						if (isWin(1)) {
							playerTurn = 0;
							xPlayerScore++;
							count = 0;
							status.setText("X wins!");
							xScore.setText("X score: " + xPlayerScore);							
							
						} else {
							status.setText("O's turn");
						}						
					
				} else if (playerTurn == -1){ //button action if active player is O				
					btn.setGraphic(new ImageView(oImage));
					playerTurn = -playerTurn;			
					board[i] = 2;
					count++;
					
					if (isWin(2)) {
						playerTurn = 0;
						oPlayerScore++;
						count = 0;
						status.setText("O wins!");
						oScore.setText("O score: " + oPlayerScore);
					} else {
						status.setText("X's turn");
					}					
				}
				
				if (count == 9) {
					status.setText("Draw");
				}
										
				btn.setOnAction(null);				
			}
		});
	}	
	
	// start new Game
	static void newGame (Button[] buttons){
		
		newGame.setOnAction(new EventHandler<ActionEvent>() {
			@Override
			public void handle(ActionEvent e) {				
				for (int i = 0; i < buttons.length; i++) {					
					buttons[i].setGraphic(null);
					buttons[i].setId("");
				}

				playerToStartFirst = -playerToStartFirst;
				playerTurn = playerToStartFirst;
				count = 0;							
				
				for (int i = 0; i < buttons.length; i++) {
					buttonAction(buttons[i], i);
				}					
				
				for (int i = 0; i < board.length; i++) {
					board[i] = 0;
				}	
				
				if (playerTurn == 1) {
					status.setText("X's turn");
				} else {
					status.setText("O's turn");
				}							
			}
		});
	}
	
	//Reset score
	static void resetScore(){
		
		resetScore.setOnAction(new EventHandler<ActionEvent>() {
			public void handle(ActionEvent e) {		
				xPlayerScore = 0;
				oPlayerScore = 0;
				xScore.setText("X score: " + oPlayerScore);
				oScore.setText("O score: " + oPlayerScore);
			}
		});	
	}
	
	//Exit game
	static void exitGame(){
		
		exitGame.setOnAction(new EventHandler<ActionEvent>() {
			public void handle(ActionEvent e) {		
				Platform.exit();
			}
		});	
	}
	
	// Checking for winner
	public static boolean isWin (int x){
		
		if ( board[0] == board[1] && board[1] == board[2] && board [2] == x){
			btn1.setId("winButton");
			btn2.setId("winButton");
			btn3.setId("winButton");
			return true;
		}
		
		if ( board[3] == board[4] && board[4] == board[5] && board [5] == x){
			btn4.setId("winButton");
			btn5.setId("winButton");
			btn6.setId("winButton");
			return true;
		}
		
		if ( board[6] == board[7] && board[7] == board[8] && board [8] == x){
			btn7.setId("winButton");
			btn8.setId("winButton");
			btn9.setId("winButton");
			return true;
		}
		
		if ( board[0] == board[3] && board[3] == board[6] && board [6] == x){
			btn1.setId("winButton");
			btn4.setId("winButton");
			btn7.setId("winButton");
			return true;
		}
		
		if ( board[1] == board[4] && board[4] == board[7] && board [7] == x){
			btn2.setId("winButton");
			btn5.setId("winButton");
			btn8.setId("winButton");
			return true;
		}
		
		if ( board[2] == board[5] && board[5] == board[8] && board [8] == x){
			btn3.setId("winButton");
			btn6.setId("winButton");
			btn9.setId("winButton");
			return true;
		}
		
		if ( board[0] == board[4] && board[4] == board[8] && board [8] == x){
			btn1.setId("winButton");
			btn5.setId("winButton");
			btn9.setId("winButton");
			return true;
		}
		
		if ( board[2] == board[4] && board[4] == board[6] && board [6] == x){
			btn3.setId("winButton");
			btn5.setId("winButton");
			btn7.setId("winButton");
			return true;
		}
		
		return false;
	}
	
	public static void main(String[] args) {
		
        launch(args);
        
    }
	
}