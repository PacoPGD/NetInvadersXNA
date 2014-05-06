using System;

namespace NetInvaders
{
    static class Program
    {
        /// <summary>
        /// Esta es la clase principal del juego.
        /// </summary>

        static void Main(string[] args)
        {
            using (Game1 game = new Game1())
            {
                game.Run();
            }
        }
    }
}

