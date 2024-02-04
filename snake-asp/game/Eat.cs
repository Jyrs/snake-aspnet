using snake_asp.Extensions;
using System.Drawing;

namespace snake_asp.game
{
    public class Eat
    {
        private readonly Snake _snake;
        public Point Position { get; private set; }

        public Eat(Snake snake)
        {
            _snake = snake;
            Position = GenerateEatPosition(_snake);
        }

        public void OnDataUpdated()
        {
            if (Position == _snake.SnakeHead)
            {
                _snake.IsGrownig = true;
                RegenerateEat();
            }
        }

        public void RegenerateEat()
        {
            Position = GenerateEatPosition(_snake);
        }
        private static Point GenerateEatPosition(Snake snake)
        {
            return Point.Empty.GenerateInFieldPoint(
                snake.SnakeBody.Union(new[] { snake.SnakeHead }));
        }

    }
}
