// file: PlayerScore2.cs
public class PlayerScore2 
{ 
	private string _name; 
	private int _score;
	
	public string name {
		get{ return _name; }
		set{ _name = value; }
	}
	
	public int score {
		get{ return _score; }
		set{ _score = value; }
	}
	
	// default constructor, needed for serialization
	public PlayerScore2() {}
	
	public PlayerScore2(string newName, int newScore) {
		name = newName;		
		score = newScore;
	}
}
