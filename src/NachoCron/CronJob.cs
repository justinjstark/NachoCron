﻿using System;
using System.Collections.Generic;

namespace NachoCron
{
    public class CronJob
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool Enabled { get; set; }
        public string Executable { get; set; }
        public IEnumerable<string> Arguments { get; set; }
        public string CronExpression { get; set; }
        public TimeSpan? LogWarningAfter { get; set; }
        public TimeSpan? LogErrorAfter { get; set; }
        public TimeSpan? Timeout { get; set; }
        public bool StartImmediately { get; set; } = false;
        public bool SkipIfAlreadyRunning { get; set; } = true;
        public bool StopIfApplicationStopping { get; set; } = true;
    }
}
