namespace ConsoleMathGame.m_a_z_z_z.Model;

internal class Game
{
	public int Score { get; set; }
	public DateTime Date { get; set; }
	public GameMode GameMode { get; set; }
	public string PlayerName { get; set; }

	internal Game(GameMode gameMode, int score, string date, string playerName)
	{
		GameMode = gameMode;
		Score = score;
		Date = DateTime.Parse(date);
		PlayerName = playerName;
	}

	internal Game(GameMode gameMode) {  GameMode = gameMode; }
}

internal enum GameMode
{
	Addition,
	Subtraction,
	Multiplication,
	Division
}
