// file: Models/Game.cs
using System.Collections.Generic;
public class Game
{
    public int GameID { get; set; }
    public string Name { get; set; }
    
    public ICollection<GameSession> GameSessions { get; set; }
}