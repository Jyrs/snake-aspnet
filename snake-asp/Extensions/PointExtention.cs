using snake_asp.game;
using System.Drawing;

namespace snake_asp.Extensions
{
    public static class PointExtention
    {
        public static Point GenerateInFieldPoint(this Point point, IEnumerable<Point> excludePointsFromGeneration)
        {
            Random randomizer = new Random();
            var excludePointsFromGenerationArray =
                excludePointsFromGeneration as Point[] ?? excludePointsFromGeneration.ToArray();
            while (true)
            {
                int X = randomizer.Next(Field._FIELD_WIDTH);
                int Y = randomizer.Next(Field._FIELD_HEIGTH);

                if (!excludePointsFromGenerationArray.Any(z => z.X == X && z.Y == Y))
                {
                    return new Point(X, Y);
                }
            }
        }
    }
}