using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils
{
    public class TaskSummary<T>
    {
        private readonly DateTime _startTime;
        private Stopwatch _stopWatch;
        public T Data { get; set; }
        public long TicksElapsed
        {
            get
            {
                return _stopWatch.ElapsedTicks;
            }
        }

        public TaskSummary()
        {
            _startTime = DateTime.Now;
            _stopWatch = Stopwatch.StartNew();
            Data = default(T);
        }

        ~TaskSummary()
        {
            _stopWatch.Stop();
        }
    }
}
