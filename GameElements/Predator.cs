namespace Game.GameElements
{
    class Predator : Prey
    {
        #region Variables

        private int lastNumOfIteration;

        public const int defaultTimeToFeed = 6;
        private int neededTimeToFeed = defaultTimeToFeed;
        private int timeToFeed = defaultTimeToFeed;

        public const char defaultPredatorImage = 'S';

        public int TimeToFeed
        {
            get
            {
                return timeToFeed;
            }
            set
            {
                timeToFeed = value;
            }
        }
        #endregion
        public Predator(Coordinate anOffset, Ocean ocean, int timeToBreed, int timeToDie) : base(anOffset, ocean, timeToBreed)
        {
            neededTimeToFeed = timeToDie;
            timeToFeed = neededTimeToFeed;

            image = defaultPredatorImage;
        }
        public override void Process()
        {
            if (myOcean.nowIteration != lastNumOfIteration)
            {
                timeToFeed--;

                lastNumOfIteration = myOcean.nowIteration;
            }

            Coordinate toCoord;
            toCoord = GetPreyNeighborCoord();

            if (timeToFeed <= 0)
            {
                AssignCellAt(Offset, new Cell(Offset, myOcean));
            }

            else
            {

                if (toCoord != Offset)
                {
                    MoveFrom(Offset, toCoord);

                    timeToFeed = neededTimeToFeed;
                }

                else
                {
                    base.Process();
                }

            }
        }

        public override Cell Reproduce(Coordinate anOffset)
        {
            return new Predator(anOffset, myOcean, neededTimeToReproduce, neededTimeToFeed);
        }
    }
}