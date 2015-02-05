import java.awt.Color;
import java.awt.Graphics;
import java.util.Random;


public class Apple {
	public static Random randomGenerator;
	private Score appleObject;
	private Color snakeColor;
	
	public Apple(Snake s) {
		appleObject = createApple(s);
		snakeColor = Color.RED;		
	}
	
	private Score createApple(Snake s) {
		randomGenerator = new Random();
		int x = randomGenerator.nextInt(30) * 20; 
		int y = randomGenerator.nextInt(30) * 20;
		for (Score snakePoint : s.snakeBody) {
			if (x == snakePoint.getX() || y == snakePoint.getY()) {
				return createApple(s);				
			}
		}
		return new Score(x, y);
	}
	
	public void drawApple(Graphics g){
		appleObject.draw(g, snakeColor);
	}	
	
	public Score scorePoint(){
		return appleObject;
	}
}
