using System;

namespace Game.GameElements
{
    class UI
    {
        public uint userNumObstacles;
        public uint userNumPrey;
        public uint userNumPredator;
        public uint userNumIteration;
        private bool IsConverted;

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
        }

    }
}