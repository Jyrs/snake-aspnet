using System.Net.NetworkInformation;

namespace snake_asp.game
{
    public class Game
    {
        public Field field => _field;
        public Snake Snake => _snake;
        public GameTimer Timer => _timer;
        public Eat eat => _eat;

        private readonly Field _field;
        private readonly Snake _snake;
        private readonly GameTimer _timer;
        private readonly Eat _eat;

        public Statistics _statistic { get; }

        public Game()
        {
            _snake = new Snake();
            _eat = new Eat(_snake);
            _field = new Field(_snake, _eat);
            _statistic = new Statistics(_snake);

            _timer = new GameTimer(TimeSpan.FromSeconds(0.1f), _snake.Move,
                 _eat.OnDataUpdated, _statistic.Tick, _field.ChangeField);

        }
    }
}
