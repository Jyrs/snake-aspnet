using System.Drawing;

namespace snake_asp.game
{
    public class Field
    {
        public const int _FIELD_WIDTH = 10;
        public const int _FIELD_HEIGTH = 10;
        public int[][] FieldData => _field;
        private int[][] _field;
        private readonly Snake _snake;
        private readonly Eat _eat;
        private static int[][] InitField()
        {
            int[][] result = new int[_FIELD_HEIGTH][];
            for (int rowCounter = 0; rowCounter < _FIELD_HEIGTH; rowCounter++)
            {
                result[rowCounter] = new int[_FIELD_WIDTH];
                Array.Fill(result[rowCounter], 0, 0, _FIELD_WIDTH);
            }
            return result;
        }
        private void AddSnakeDataToField()
        {
            Point snakeHead = _snake.SnakeHead;
            Point[] snakeBody = _snake.SnakeBody;

            _field[snakeHead.Y][snakeHead.X] = 3;
            foreach (var snakeBodyPoint in snakeBody)
            {
                _field[snakeBodyPoint.Y][snakeBodyPoint.X] = 2;
            }
        }
        public Field(Snake snake, Eat eat)
        {
            _snake = snake;
            _eat = eat;
            _field = InitField();

        }
        public void ChangeField()
        {
            _field = InitField();
            AddEatToField();
            AddSnakeDataToField();

        }

        private void AddEatToField()
        {
            _field[_eat.Position.Y][_eat.Position.X] = 1;
        }
    }
}
