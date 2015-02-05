import java.awt.Canvas;
import java.awt.Dimension;
import java.awt.Graphics;

@SuppressWarnings("serial")
public class Player extends Canvas implements Runnable {
	public static Snake currentSnake;
	public static Apple apalkata;
	static int to4ki;
	
	private Graphics globalGraphics;
	private Thread runThread;
	public static final int WIDTH = 600;
	public static final int height = 600;
	private final Dimension naIgr1t1Razmera = new Dimension(WIDTH, height);
	
	static boolean gameRunning = false;
	
	public void paint(Graphics g){
		this.setPreferredSize(naIgr1t1Razmera);
		globalGraphics = g.create();
		to4ki = 0;
		
		if(runThread == null){
			runThread = new Thread(this);
			runThread.start();
			gameRunning = true;
		}
	}
	
	public void run(){
		while(gameRunning){
			currentSnake.tick();
			render(globalGraphics);
			try {
				Thread.sleep(100);
			} catch (Exception e) {
				// TODO: fani ma za eksep6ana
			}
		}
	}
	
	public Player(){	
		currentSnake = new Snake();
		apalkata = new Apple(currentSnake);
	}
		
	public void render(Graphics g){
		g.clearRect(0, 0, WIDTH, height+25);
		
		g.drawRect(0, 0, WIDTH, height);			
		currentSnake.drawSnake(g);
		apalkata.drawApple(g);
		g.drawString("score= " + to4ki, 10, height + 25);		
	}
}

