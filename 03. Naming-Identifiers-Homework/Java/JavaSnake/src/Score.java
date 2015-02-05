import java.awt.Color;
import java.awt.Graphics;

public class Score {
	private int x, y;
	private final int width = 20;
	private final int height = 20;
	
	public Score(Score p){
		this(p.x, p.y);
	}
	
	public Score(int x, int y){
		this.x = x;
		this.y = y;
	}	
		
	public int getX() {
		return x;
	}
	public void namestiXiksa(int x) {
		this.x = x;
	}
	public int getY() {
		return y;
	}
	public void namestIgreka(int y) {
		this.y = y;
	}
	
	public void draw(Graphics g, Color cvqt) {
		g.setColor(Color.BLACK);
		g.fillRect(x, y, width, height);
		g.setColor(cvqt);
		g.fillRect(x+1, y+1, width-2, height-2);		
	}
	
	public String toString() {
		return "[x=" + x + ",y=" + y + "]";
	}
	
	public boolean equals(Object object) {
        if (object instanceof Score) {
            Score score = (Score)object;
            return (x == score.x) && (y == score.y);
        }
        return false;
    }
}
