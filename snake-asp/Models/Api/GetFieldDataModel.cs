namespace snake_asp.Models.Api
{
    public class GetFieldDataModel
    {
        public int FieldWidth => game.Field._FIELD_WIDTH;
        public int FieldHeigth => game.Field._FIELD_HEIGTH;
        private int[][] _fieldData;
        public int[][] FieldData => _fieldData;
        public GetFieldDataModel(game.Game game)
        {
            _fieldData = game.field.FieldData;
        }

    }
}
