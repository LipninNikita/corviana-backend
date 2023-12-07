﻿using EventBusRabbitMq.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Post.API.Events
{
    public class PostCreatedEvent : Event
    {
        public string PostId { get; set; }
        public string UserId { get; set; }
        public IEnumerable<string> Images { get; set; }
    }
}
