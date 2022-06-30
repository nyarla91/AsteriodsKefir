using System.Numerics;

namespace Model.Obstacles
{
    public class PieceOfMeteor : Meteor
    {
        protected override int ScoreWorth => 3;
        protected override float Speed => 2;
        protected override int PiecesOnBreak => 0;

        public PieceOfMeteor(Vector2 position, float rotation, ScoreCounter scoreCounter, ObstaclesSpawner spawner)
            : base(position, rotation, scoreCounter, spawner)
        {
            Scale = Vector2.One * 0.6f;
        }
    }
}