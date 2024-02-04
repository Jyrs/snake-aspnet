using System.Drawing;

namespace snake_asp.game
{
    public class Snake
    {
        public const int BORN_SNAKE_SIZE = 4;
        public Point[] SnakeBody => _snakeBody.Where(x => x != SnakeHead).ToArray();
        public Point SnakeHead => _snakeBody.Last();
        public Point Speed { get; set; } = Point.Empty;
        public bool IsDead { get; private set; } = false;
        public bool IsMoving { get; private set; } = false;
        public bool IsGrownig { get; set; } = false;


        public int SnakeSize => _snakeBody.Count;

        private readonly Queue<Point> _snakeBody;


        public Snake()
        {
            Random randomizer = new Random();
            int snakeHead_X = randomizer.Next(Field._FIELD_WIDTH);
            int snakeHead_Y = randomizer.Next(Field._FIELD_HEIGTH);

            _snakeBody = new Queue<Point>();
            for (int counter = 0; counter < BORN_SNAKE_SIZE; counter++)
            {
                _snakeBody.Enqueue(new Point(snakeHead_X, snakeHead_Y));
            }

            IsDead = false;
        }
        public void Move()
        {
            IsMoving = Speed != Point.Empty;
            //if (IsDead) { return; }
            Point head = SnakeHead;
            Point nextHead = new Point(head.X + Speed.X, head.Y + Speed.Y);
            IsDead = IsOutofField(nextHead);
            if (IsDead) { return; }
            if (!IsGrownig)
            {
                _snakeBody.Dequeue();
            }
            else
            {
                IsGrownig = false;
            }
            IsDead |= IsHitMyself(nextHead);
            if (IsDead) { return; }

            _snakeBody.Enqueue(nextHead);

        }

        private bool IsHitMyself(Point nextHead)
        {
            return SnakeBody.Length >= BORN_SNAKE_SIZE - 1 && _snakeBody.Contains(nextHead);
        }

        private bool IsOutofField(Point nextHead)
        {
            return nextHead.X >= Field._FIELD_WIDTH || nextHead.X < 0 ||
                   nextHead.Y >= Field._FIELD_HEIGTH || nextHead.Y < 0;

        }

    }
}
