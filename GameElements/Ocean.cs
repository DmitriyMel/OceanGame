using System;
using System.Threading;
using EcoProject;

namespace Game.GameElements
{   class Ocean
    {
        #region Constants
        readonly UI userInterface = new UI();
        public int nowIteration = 0;

        public const int maxIteration = 1000;
        public const int defaultNumIteration = 100;
        private uint numIteration;

        public const int defaultNumObstacles = 75;
        public const int maxNumObstacles = 300;
        private uint numObstacles = defaultNumObstacles;
        public uint NumObstacles
        {
            get { return numObstacles; }
            set { numObstacles = value; }
        }

        public const int defaultNumPrey = 150;
        public const int maxNumPrey = 500;
        private uint numPrey = defaultNumPrey;
        public uint NumPrey
        {
            get { return numPrey; }
            set { numPrey = value; }
        }

        public const int defaultNumPredator = 20;
        public const int maxNumPredator = 500;
        private uint numPredator = defaultNumPredator;
        public uint NumPredator
        {
            get { return numPredator; }
            set { numPredator = value; }
        }

        public const int maxRows = 25;
        private int numRows = maxRows;
        public int NumRows
        {
            get { return numRows; }
            set { numRows = value; }
        }

        public const int maxCols = 70;
        private int numCols = maxCols;
        public int NumCols
        {
            get { return numCols; }
            set { numCols = value; }
        }

        private int size = maxRows * maxCols;
        public int Size
        {
            get { return size; }
            set { size = value; }
        }

        public Cell[,] cells;

        public static Random random { get; set; }

        private Random rand = new Random();
        public int Random
        {
            get { return rand.Next(0, Size); }
            set { }
        }

        private bool IsConverted;
        private UI output;
        #endregion
        public Ocean(UI output)
        {
            this.output = output;
        }
        public void Initialize()
        {
            numRows = maxRows;
            numCols = maxCols;
            Size = maxCols * maxRows;
            cells = new Cell[NumRows, NumCols];

            NumObstacles = defaultNumObstacles;
            numPrey = defaultNumPrey;
            numPredator = defaultNumPredator;

            InitCells();
        }

        private void InitCells()
        {
            userInterface.SetValue();

            NumObstacles = userInterface.userNumObstacles;
            NumPrey = userInterface.userNumPrey;
            NumPredator = userInterface.userNumPredator;

            AddEmptyCells();
            userInterface.DisplayBorder(this);
            AddObstacles();
            AddPrey();
            AddPredators();
            userInterface.DisplayCells(this);
            userInterface.DisplayBorder(this);

            userInterface.SetIteration();
            numIteration = userInterface.userNumIteration;
        }
        public void Run()
        {
            for (int iteration = 1; iteration <= numIteration; iteration++)
            {
                IVisitor cellVisitor = new VisitorImplemention();
                if (NumPredator > 0 && NumPrey > 0)
                {
                    nowIteration++;

                    for (int row = 0; row < NumRows; row++)
                    {
                        for (int column = 0; column < NumCols; column++)
                        {
                            Cell cell = cells[row, column];
                            cell.myOcean = this;
                            cellVisitor.Visit(cell);
                        }
                    }
                    CountInfo();
                    userInterface.DisplayStats(this, iteration);
                    userInterface.DisplayBorder(this);
                    userInterface.DisplayCells(this);
                    userInterface.DisplayBorder(this);
                }
            }
        }

        private Coordinate GetEmptyCellCoord()
        {
            int x, y;
            Coordinate empty;
            do
            {
                x = Random % NumCols;
                y = Random % NumRows;
            }
            while (cells[y, x].Image != Cell.defaultCellChar);
            empty = cells[y, x].Offset;
            return empty;
        }

        #region AddElements

        private void AddEmptyCells()
        {
            for (int row = 0; row < NumRows; row++)
            {
                for (int column = 0; column < NumCols; column++)
                {
                    Coordinate coord = new Coordinate(column, row);
                    Cell temp = new Cell(coord, this);
                    cells[row, column] = temp;
                }
            }
        }

        private void AddObstacles()
        {
            Coordinate empty;

            for (int i = 0; i < NumObstacles; i++)
            {
                empty = GetEmptyCellCoord();
                cells[empty.Y, empty.X] = new Obstacle(empty, this);
            }

        }

        private void AddPrey()
        {
            Coordinate empty;

            for (int i = 0; i < NumPrey; i++)
            {
                empty = GetEmptyCellCoord();
                cells[empty.Y, empty.X] = new Prey(empty, this, Prey.defaultTimeToReproduce);
            }

        }

        private void AddPredators()
        {
            Coordinate empty;

            for (int i = 0; i < NumPredator; i++)
            {
                empty = GetEmptyCellCoord();
                cells[empty.Y, empty.X] = new Predator(empty, this, Predator.defaultTimeToReproduce, Predator.defaultTimeToFeed);
            }

        }
        #endregion
        private void CountInfo()
        {
            int countOfPredator = 0;
            int countOfPrey = 0;

            for (int row = 0; row < NumRows; row++)
            {
                for (int column = 0; column < NumCols; column++)
                {
                    if (cells[row, column].Image == 'S')
                    {
                        countOfPredator++;
                    }

                    if (cells[row, column].Image == 'f')
                    {
                        countOfPrey++;
                    }
                }
            }

            NumPrey = (uint)countOfPrey;
            NumPredator = (uint)countOfPredator;
        }
    }
}

