﻿// Score.cs
using System;

namespace MekiApi.Models
{
    public class Score
    {
        public int Id { get; set; }
        public int HighScore { get; set; }
        public DateTime Date { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}