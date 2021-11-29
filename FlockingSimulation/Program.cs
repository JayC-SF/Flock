using System;

namespace FlockingSimulation
{
    /// <summary>
    /// Program class is where the Main method resides to launch the app
    /// </summary>
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            using (var game = new Game1())
                game.Run();
        }
    }
}
