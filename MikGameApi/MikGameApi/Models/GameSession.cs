//file: Models/gameSession.cs
using System;

public class GameSession
{
    public int SessionID { get; set; }
    public DateTime StartTime { get; set; }
    public int Score { get; set; }
    public string LastMove { get; set; }
    
    public int PlayerID { get; set; }
    public Player Player { get; set; }
    
    public int GameID { get; set; }
    public Game Game { get; set; }
}