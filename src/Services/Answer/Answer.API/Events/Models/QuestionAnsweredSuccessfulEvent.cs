﻿using EventBusRabbitMq.Events;

namespace Answer.API.Events.Models
{
    public class QuestionAnsweredSuccessfulEvent : Event
    {
        public int QuestionId { get; set; }
        public int Level { get; set; }
        public string UserId { get; set; }
    }
}
