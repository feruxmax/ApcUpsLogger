using System;
using System.Collections.Generic;
using System.Linq;
using System.Timers;
using ApcUpsLogger.Utils;

namespace ApcUpsLogger.Engine
{ 
    public class PeriodicLogger
    {
        private readonly ScopedRunner scopedRunner;
        private readonly Timer timer;

        public PeriodicLogger(ScopedRunner scopedRunner)
        {
            this.scopedRunner = scopedRunner;

            timer = new Timer(1000);
            timer.Elapsed += (sender, e) => LogLineV();
        }

        public void Run()
        {
            timer.Start();
        }

        private void LogLineV()
        {
            var lineV = scopedRunner.Run<ApcDbLogger, double?>(x => x.LogLineV());
            Console.WriteLine(lineV);
        }
    }
}
