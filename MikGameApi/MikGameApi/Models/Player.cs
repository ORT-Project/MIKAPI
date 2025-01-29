// file: Models/Player.cs

namespace MikGameApi.Models
{
    using System.Collections.Generic;
}
public class Player
{
    public int PlayerID {get; set;}
    public string Username {get; set;}
    public string Email {get; set;}
    
    public ICollection<GameSession> GameSessions {get; set;}
}