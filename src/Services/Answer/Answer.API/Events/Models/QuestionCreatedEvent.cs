﻿using EventBusRabbitMq.Events;

namespace Answer.API.Events.Models
{
    public class QuestionCreatedEvent : Event
    {
        public int QuestionId { get; set; }
        public IEnumerable<Answer> Answers { get; set; } 
    }
    public class Answer
    {
        public string Content { get; set; }
        public bool IsRight { get; set; }
    }
}
