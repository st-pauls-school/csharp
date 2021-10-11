using System;
using System.Timers;

namespace EventsAndGuiBasics.Library
{
    public class Ticker
    {
        public event EventHandler<TickerEventArgs> Tick;
        readonly Timer _timer;
        string _message;

        public Ticker(string message, int interval)
        {
            _timer = new Timer();
            _timer.Interval = interval;
            _timer.Enabled = false;
            _message = message;
            _timer.Elapsed += _timer_Elapsed;
        }

        void _timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            
            OnTick(e.SignalTime);
        }

        public void Start(string message = null)
        {
            if (!string.IsNullOrEmpty(message))
                _message = message;
            _timer.Enabled = true;
            
        }

        public void Stop()
        {
            _timer.Enabled = false;
        }

        public void OnTick(DateTime sig)
        {
            Tick?.Invoke(this, new TickerEventArgs(_message, sig));
        }
    }

    public class TickerEventArgs : EventArgs
    {
        readonly string _message;
        readonly DateTime _dateTime;

        public TickerEventArgs(string message, DateTime dt) : base()
        {
            _message = message;
            _dateTime = dt;
        }

        public string Message => _message;
        public DateTime SignalTime => _dateTime;

        public override string ToString()
        {
            return string.Format("{0} ({1})", Message, SignalTime.TimeOfDay);
        }
    }
}
