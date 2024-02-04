namespace snake_asp.game
{
    using System.Collections.Generic;
    using System.Configuration;
    using System.Threading;

    public class GameTimer
    {
        private readonly TimeSpan _timeout;
        private readonly Action[] _timeListeners;
        private Timer _timer;
        public GameTimer(TimeSpan timeOut, params Action[] timerListeners)
        {
            _timeout = timeOut;
            _timeListeners = timerListeners;
            _timer = new Timer(OnTimer);



            if (timerListeners.Length > 0)
            {
                _timer.Change(_timeout, Timeout.InfiniteTimeSpan);
            }


        }
        private void OnTimer(object? state)
        {
            foreach (var timerListener in _timeListeners)
            {
                timerListener();
            }
            _timer.Change(_timeout, Timeout.InfiniteTimeSpan);
        }
    }
}
