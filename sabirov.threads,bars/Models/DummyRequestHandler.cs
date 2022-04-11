﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sabirov.threads_bars.Models
{
    public class DummyRequestHandler : IRequestHandler
    {
        public string HandleRequest(string message, string[] arguments)
        {
            Thread.Sleep(10_000);
            if (message.Contains("упади"))
            {
                throw new Exception("Я упал, как сам просил");
            }
            return Guid.NewGuid().ToString("D");
        }
    }
}
