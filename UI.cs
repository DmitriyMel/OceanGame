using Game.GameElements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EcoProject
{
        class UI : IView
        {
            public uint userNumObstacles;
            public uint userNumPrey;
            public uint userNumPredator;
            public uint userNumIteration;

            private bool IsConverted;
            public void DisplayBorder(Ocean ocean)
            {
                for (int i = 0; i < ocean.NumCols; i++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
                Thread.Sleep(100);
            }
            public void DisplayStats(Ocean ocean, int iteration)
            {
                Console.SetCursorPosition(0, 0);
                Console.Write("\nIteration: ({0}/{1})", iteration, userNumIteration);
                Console.Write("\tObstacles: {0}", ocean.NumObstacles);
                Console.Write("\tPrey: {0}", ocean.NumPrey);
                Console.WriteLine("\tPredators: {0}", ocean.NumPredator);
            }

            public void SetValue()
            {
                Console.Write("Enter the number of obstacles (default is 75): ");
                IsConverted = UInt32.TryParse(Console.ReadLine(), out userNumObstacles);
                while (!IsConverted)
                {
                    Console.Write("Enter the correct number of obstacles: ");
                    IsConverted = UInt32.TryParse(Console.ReadLine(), out userNumObstacles);
                }
                if (userNumObstacles > Ocean.maxNumObstacles)
                {
                    userNumObstacles = Ocean.maxNumObstacles;
                }

                Console.Write("Enter the number of prey (default is 150): ");
                IsConverted = UInt32.TryParse(Console.ReadLine(), out userNumPrey);
                while (!IsConverted)
                {
                    Console.Write("Enter the correct number of prey: ");
                    IsConverted = UInt32.TryParse(Console.ReadLine(), out userNumPrey);
                }
                if (userNumPrey > Ocean.maxNumPrey)
                {
                    userNumPrey = Ocean.maxNumPrey;
                }

                Console.Write("Enter the number of predator (default is 20): ");
                IsConverted = UInt32.TryParse(Console.ReadLine(), out userNumPredator);
                while (!IsConverted)
                {
                    Console.Write("Enter the correct number of predator: ");
                    IsConverted = UInt32.TryParse(Console.ReadLine(), out userNumPredator);
                }
                if (userNumPredator > Ocean.maxNumPredator)
                {
                    userNumPredator = Ocean.maxNumPredator;
                }
            }
            public void SetIteration()
            {
                Console.Write("Enter the number of iteration(defaul is 100): ");
                IsConverted = UInt32.TryParse(Console.ReadLine(), out userNumIteration);
                while (!IsConverted)
                {
                    Console.Write("Enter the correct number of iteration: ");
                    IsConverted = UInt32.TryParse(Console.ReadLine(), out userNumIteration);
                }
                if (userNumIteration > Ocean.maxIteration)
                {
                    userNumIteration = Ocean.maxIteration;
                }
                Console.Clear();
            }
            public void DisplayCells(Ocean ocean)
            {
                for (int row = 0; row < ocean.NumRows; row++)
                {
                    for (int column = 0; column < ocean.NumCols; column++)
                    {
                    //Console.Write(ocean.cells[row, column].Image);
                    ocean.cells[row, column].Display();
                    }
                Console.WriteLine();
                }
            }
        }
}


