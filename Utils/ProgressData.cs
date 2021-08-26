using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils
{
    public class ProgressData
    {
        private long _ticksElapsed;
        private readonly DateTime _timeStarted = DateTime.Now;

        public string ActionCompleted { get; set; }

        public float PercentComplete { get; set; }

        public long CurrentTicks { get; private set; } = DateTime.Now.Ticks;

        public TimeSpan TimeElapsed => DateTime.Now - _timeStarted;



    }
}
