
using Humanizer;

namespace snake_asp.Models.Api
{
    public class GetStatusDataModel
    {
        public int SnakeSize { get; }
        public int SnakeScore { get; }
        public TimeSpan GameTime { get; }
        public int SnakeDead { get; }
        public bool IsSnakeDead { get; }
        public bool IsSnakeMove { get; }
        public GetStatusDataModel(game.Game model)
        {
            GameTime = new TimeSpan(model._statistic.GameTime.Hours, model._statistic.GameTime.Minutes,
                                   model._statistic.GameTime.Seconds);
            SnakeScore = model._statistic.GameScore;
            SnakeSize = model._statistic.SnakeSize - 4;
            IsSnakeDead = !model._statistic.IsDead;
            IsSnakeMove = model.Snake.IsMoving;

        }
    }
}
