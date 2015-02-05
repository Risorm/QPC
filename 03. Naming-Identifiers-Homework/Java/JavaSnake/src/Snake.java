import java.awt.Color;
import java.awt.Graphics;
import java.util.LinkedList;

public class Snake{
	LinkedList<Score> snakeBody = new LinkedList<Score>();
	private Color snakeColor;
	private int velocityX, velocityY;
	
	public Snake() {
		snakeColor = Color.GREEN;
		snakeBody.add(new Score(300, 100)); 
		snakeBody.add(new Score(280, 100)); 
		snakeBody.add(new Score(260, 100)); 
		snakeBody.add(new Score(240, 100)); 
		snakeBody.add(new Score(220, 100)); 
		snakeBody.add(new Score(200, 100)); 
		snakeBody.add(new Score(180, 100));
		snakeBody.add(new Score(160, 100));
		snakeBody.add(new Score(140, 100));
		snakeBody.add(new Score(120, 100));

		velocityX = 20;
		velocityY = 0;
	}
	
	public void drawSnake(Graphics g) {		
		for (Score point : this.snakeBody) {
			point.draw(g, snakeColor);
		}
	}
	
	public void tick() {
		Score newPositionPoint = new Score((snakeBody.get(0).getX() + velocityX), (snakeBody.get(0).getY() + velocityY));
		
		if (newPositionPoint.getX() > Player.WIDTH - 20) {
		 	Player.gameRunning = false;
		} else if (newPositionPoint.getX() < 0) {
			Player.gameRunning = false;
		} else if (newPositionPoint.getY() < 0) {
			Player.gameRunning = false;
		} else if (newPositionPoint.getY() > Player.height - 20) {
			Player.gameRunning = false;
		} else if (Player.apalkata.scorePoint().equals(newPositionPoint)) {
			snakeBody.add(Player.apalkata.scorePoint());
			Player.apalkata = new Apple(this);
			Player.to4ki += 50;
		} else if (snakeBody.contains(newPositionPoint)) {
			Player.gameRunning = false;
			System.out.println("You ate yourself");
		}	
		
		for (int i = snakeBody.size()-1; i > 0; i--) {
			snakeBody.set(i, new Score(snakeBody.get(i-1)));
		}	
		snakeBody.set(0, newPositionPoint);
	}

	public int getVelX() {
		return velocityX;
	}

	public void setVelX(int velX) {
		this.velocityX = velX;
	}

	public int getVelY() {
		return velocityY;
	}

	public void setVelY(int velY) {
		this.velocityY = velY;
	}
}
