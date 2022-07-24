namespace Game.GameElements
{
    class Obstacle : Cell
    {
        public const char defaultObstacleImage = '#';

        public Obstacle(Coordinate anOffset, Ocean ocean)
        {
            Offset = anOffset;
            myOcean = ocean;

            image = defaultObstacleImage;
        }
    }
}