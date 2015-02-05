import java.awt.event.KeyEvent;
import java.awt.event.KeyListener;

public class EventListener implements KeyListener{
	
	public EventListener(Player game){
		game.addKeyListener(this);
	}
	
	public void keyPressed(KeyEvent e) {
		int keyCode = e.getKeyCode();
		
		if (keyCode == KeyEvent.VK_W || keyCode == KeyEvent.VK_UP) {
			if(Player.currentSnake.getVelY() != 20){
				Player.currentSnake.setVelX(0);
				Player.currentSnake.setVelY(-20);
			}
		}
		if (keyCode == KeyEvent.VK_S || keyCode == KeyEvent.VK_DOWN) {
			if(Player.currentSnake.getVelY() != -20){
				Player.currentSnake.setVelX(0);
				Player.currentSnake.setVelY(20);
			}
		}
		if (keyCode == KeyEvent.VK_D || keyCode == KeyEvent.VK_RIGHT) {
			if(Player.currentSnake.getVelX() != -20){
			Player.currentSnake.setVelX(20);
			Player.currentSnake.setVelY(0);
			}
		}
		if (keyCode == KeyEvent.VK_A || keyCode == KeyEvent.VK_LEFT) {
			if(Player.currentSnake.getVelX() != 20){
				Player.currentSnake.setVelX(-20);
				Player.currentSnake.setVelY(0);
			}
		}
		//Other controls
		if (keyCode == KeyEvent.VK_ESCAPE) {
			System.exit(0);
		}
	}
	
	public void keyReleased(KeyEvent e) {
	}
	
	public void keyTyped(KeyEvent e) {
		
	}

}
