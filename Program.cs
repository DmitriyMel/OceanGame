using EcoProject;
using Game.GameElements;

namespace Game
{
    class Program
    {
        static void Main(string[] args)
        {
            UI output = new UI();
            Ocean myOcean = new Ocean(output);

            myOcean.Initialize();
            myOcean.Run();
        }
    }
}