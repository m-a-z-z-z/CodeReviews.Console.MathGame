namespace ConsoleMathGame.m_a_z_z_z.Model;

internal class Game
{
	public GameMode GameMode { get; set; }
	public Difficulty Difficulty { get; set; }
	public int Score { get; set; }
	public DateTime Date { get; set; }
	public string PlayerName { get; set; }

	internal Game(GameMode gameMode, int score, string date, string playerName)
	{
		GameMode = gameMode;
		Score = score;
		Date = DateTime.Parse(date);
		PlayerName = playerName;
	}
	
	
	internal Game(GameMode gameMode, Difficulty difficulty, int score, string date, string playerName)
	{
		GameMode = gameMode;
		Score = score;
		Date = DateTime.Parse(date);
		PlayerName = playerName;
	}
	
	internal Game(GameMode gameMode, Difficulty difficulty) 
	{  
		GameMode = gameMode; 
		Difficulty = difficulty;
	}
	
}

internal enum GameMode
{
	Addition,
	Subtraction,
	Multiplication,
	Division
}

internal enum Difficulty 
{
	Easy,
	Medium,
	Hard
}