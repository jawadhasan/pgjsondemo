using System;
using System.Collections.Generic;
using System.Text;

namespace PGdemoApp.Core
{
    public class LogRecord
    {
        public int Id { get; set; }
        public DateTime LogTime { get; set; }
        public string LogInfo { get; set; }

        public LogRecord()
        {
            LogTime = DateTime.UtcNow;
        }
    }
}
