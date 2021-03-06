﻿using System;
using System.Collections.Generic;
using Noobot.Core.MessagingPipeline.Request;
using Noobot.Core.MessagingPipeline.Response;

namespace Noobot.Core.MessagingPipeline.Middleware.StandardMiddleware
{
    internal class AboutMiddleware : MiddlewareBase
    {
        public AboutMiddleware(IMiddleware next) : base(next)
        {
            HandlerMappings = new[]
            {
                new HandlerMapping
                {
                    ValidHandles = new []{ "about" },
                    Description = "Tells you some stuff about this bot :-)",
                    EvaluatorFunc = AboutHandler
                }
            };
        }

        private IEnumerable<ResponseMessage> AboutHandler(IncomingMessage message, string matchedHandle)
        {
            yield return message.ReplyDirectlyToUser("Noobot - Created by Simon Colmer " + DateTime.Now.Year);
            yield return message.ReplyDirectlyToUser("I am an extensible SlackBot built in C# using loads of awesome open source projects.");
            yield return message.ReplyDirectlyToUser("Please find more at http://github.com/noobot/noobot");
        }
    }
}