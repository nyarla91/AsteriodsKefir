using System.Numerics;

namespace Model.Obstacles
{
    public class PieceOfMeteor : Meteor
    {
        public override int ScoreWorth => 3;
        protected override float Speed => 2;
        protected override int PiecesOnBreak => 0;

        public PieceOfMeteor(Vector2 position, float rotation, ObstaclesSpawner spawner) : base(position, rotation, spawner)
        {
            Scale = Vector2.One * 0.6f;
        }
    }
}