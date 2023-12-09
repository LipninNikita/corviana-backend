﻿using EventBusRabbitMq.Events;

namespace Point.API.Events.Models
{
    public class QuestionCompletedEvent : Event
    {
        public string QuestionId { get; set; }
        public int Level { get; set; }
        public string UserId { get; set; }
    }
}