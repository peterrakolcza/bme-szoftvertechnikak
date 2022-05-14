using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Signals
{
    public class SignalValue
    {
        private readonly double value;
        private readonly DateTime timestamp;

        public DateTime TimeStamp
        {
            get { return timestamp; }
        }

        public double Value
        {
            get { return value; }
        }

        public SignalValue(double _Value, DateTime _TimeStamp)
        {
            value = _Value;
            timestamp = _TimeStamp;
        }

        public override string ToString()
        {
            return string.Format("Value: {0}, TimeStamp: {1}", Value, TimeStamp);
        }

    }
}
