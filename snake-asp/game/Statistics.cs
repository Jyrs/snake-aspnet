using System.Data;

namespace snake_asp.game
{
    public class Statistics
    {
        private readonly Snake _snake;
        public TimeSpan GameTime { get; private set; }
        public int GameScore { get; private set; }
        public int SnakeSize { get; private set; }
        private DateTime GameStarted { get; set; }
        private DateTime GameSTopped { get; set; }
        private DateTime TurnStarted { get; set; }
        public bool IsDead { get; private set; }

        public Statistics(Snake snake)
        {
            _snake = snake;
            if (_snake.IsMoving) { GameStarted = DateTime.Now; }
            else { GameStarted = DateTime.MinValue; }
            GameTime = TimeSpan.Zero;
            GameSTopped = DateTime.MinValue;
            GameScore = 0;
            SnakeSize = _snake.SnakeSize;
            TurnStarted = GameStarted;
            IsDead = false;
        }
        public void Tick()
        {
            if (_snake.IsDead)
            {
                IsDead = true;
                GameSTopped = GameSTopped == DateTime.MinValue ? DateTime.Now : GameSTopped;

            }
            if (_snake.IsMoving && GameStarted == DateTime.MinValue)
            {
                GameStarted = DateTime.Now;
                TurnStarted = GameStarted;
            }
            if (_snake.IsMoving)
            {
                GameTime = GameSTopped == DateTime.MinValue ?
                    DateTime.Now - GameStarted : GameSTopped - GameStarted;
            }
            if (_snake.SnakeSize != SnakeSize)
            {
                SnakeSize = _snake.SnakeSize;
                // base score 100
                // 100 for 10 turns i.e 10 sec
                // 1 for more than 20 sec

                var eatSecond = (int)(DateTime.Now - TurnStarted).TotalSeconds;
                if (eatSecond < 10) { GameScore += 100; }
                else if (eatSecond <= 20) { GameScore += 10 * (20 - eatSecond); }
                else { GameScore += 1; }
            }
        }
    }
}

