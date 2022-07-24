using System;

namespace Game.GameElements
{
    class Cell
    {
        #region Variables

        public Ocean myOcean;

        public Coordinate Offset { get; protected set; }
        public const char defaultCellChar = '-';

     

        protected char image = defaultCellChar;
        public char Image
        {
            get { return image; }
            set { }
        }
        #endregion

        public Cell()
        {

        }

        public Cell(Coordinate anOffset, Ocean ocean)
        {
            Offset = anOffset;
            myOcean = ocean;
        }

        public virtual void Process()
        {

        }

        public virtual Cell Reproduce(Coordinate anOffset)
        {
            return this;
        }

        public void Display()
        {
            Console.Write(image);
        }

        public Coordinate GetEmptyNeighborCoord()
        {
            return GetNeighborWithImage(defaultCellChar).Offset;
        }

        public Coordinate GetPreyNeighborCoord()
        {
            return GetNeighborWithImage(Prey.defaultPreyImage).Offset;
        }

        public Cell GetNeighborWithImage(char anImage)
        {
            int numNeighbors = 4;
            Cell[] neighbors = new Cell[numNeighbors];

            int i = 0;

            if (GetNorthCell().image == anImage)
            {
                neighbors[i] = GetNorthCell();
                i++;
            }

            if (GetSouthCell().image == anImage)
            {
                neighbors[i] = GetSouthCell();
                i++;
            }

            if (GetWestCell().image == anImage)
            {
                neighbors[i] = GetWestCell();
                i++;
            }

            if (GetEastCell().image == anImage)
            {
                neighbors[i] = GetEastCell();
                i++;
            }

            if (i == 0)
            {
                return this;
            }
            else
            { 
                return neighbors[myOcean.Random % i];
            }
        }

        public Cell GetCellAt(Coordinate aCoord)
        {
            return myOcean.cells[aCoord.Y, aCoord.X];
        }

        public void AssignCellAt(Coordinate aCoord, Cell cell)
        {
            myOcean.cells[aCoord.Y, aCoord.X] = cell;
        }

        #region Directions

        private Cell GetNorthCell()
        {
            if (Offset.Y <= 0)
            {
                return this;
            }

            else
            {
                Coordinate coord = new Coordinate(Offset.X, Offset.Y - 1);

                return GetCellAt(coord);
            }
        }

        private Cell GetEastCell()
        {
            if (Offset.X >= (myOcean.NumCols - 1))
            {
                return this;
            }

            else
            {
                Coordinate coord = new Coordinate(Offset.X + 1, Offset.Y);

                return GetCellAt(coord);
            }
        }

        private Cell GetWestCell()
        {
            if (Offset.X <= 0)
            {
                return this;
            }

            else
            {
                Coordinate coord = new Coordinate(Offset.X - 1, Offset.Y);

                return GetCellAt(coord);
            }
        }

        private Cell GetSouthCell()
        {
            if (Offset.Y >= (myOcean.NumRows - 1))
            {
                return this;
            }

            else
            {
                Coordinate coord = new Coordinate(Offset.X, Offset.Y + 1);

                return GetCellAt(coord);
            }
        }
        #endregion

    }
}