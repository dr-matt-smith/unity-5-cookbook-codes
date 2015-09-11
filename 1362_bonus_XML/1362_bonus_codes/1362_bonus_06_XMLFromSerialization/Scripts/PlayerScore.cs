// file: PlayerScore.cs
public class PlayerScore 
{ 
	public string name; 
	public int score;
	
	// default constructor, needed for serialization
	public PlayerScore() {}
	
	public PlayerScore(string newName, int newScore) {
		name = newName;		
		score = newScore;
	}
}