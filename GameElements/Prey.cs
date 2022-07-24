namespace Game.GameElements
{
    class Prey : Cell
    {
        #region Variables

        private int lastNumOfIteration;

        public const int defaultTimeToReproduce = 6;
        protected int neededTimeToReproduce = defaultTimeToReproduce;
        private int timeToReproduce = defaultTimeToReproduce;

        public const char defaultPreyImage = 'f';

        public int TimeToReproduce
        {
            get
            {
                return timeToReproduce;
            }
            protected set
            {
                timeToReproduce = value;
            }
        }
        #endregion

        public Prey(Coordinate anOffSet, Ocean ocean, int timeToBreed)
        {
            Offset = anOffSet;
            myOcean = ocean;
            timeToReproduce = timeToBreed;
            image = defaultPreyImage;
        }

        public override void Process()
        {
            MoveFrom(Offset, GetEmptyNeighborCoord());
        }

        protected virtual void MoveFrom(Coordinate from, Coordinate to)
        {
            if (myOcean.nowIteration != lastNumOfIteration)
            {
                timeToReproduce--;

                lastNumOfIteration = myOcean.nowIteration;
            }

            if (to != from)
            {
                Offset = to;
                AssignCellAt(to, this);

                if (timeToReproduce <= 0)
                {
                    AssignCellAt(from, Reproduce(from));

                    timeToReproduce = defaultTimeToReproduce;
                }

                else
                {
                    AssignCellAt(from, new Cell(from, myOcean));
                }

            }
        }

        public override Cell Reproduce(Coordinate anOffset)
        {
            return new Prey(anOffset, myOcean, defaultTimeToReproduce);
        }

    }
}