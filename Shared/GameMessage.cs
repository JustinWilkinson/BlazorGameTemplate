﻿using System;

namespace BlazorGameTemplate.Shared
{
    public class GameMessage
    {
        public DateTime SentAt { get; set; }

        public string PlayerName { get; set; }

        public string Message { get; set; }

        public GameMessage()
        {

        }

        public GameMessage(string playerName, string message)
        {
            SentAt = DateTime.UtcNow;
            PlayerName = playerName;
            Message = message;
        }
    }
}