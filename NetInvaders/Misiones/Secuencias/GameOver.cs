using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Net;
using Microsoft.Xna.Framework.Storage;


namespace NetInvaders
{
    /// <summary>
    /// Esta es la pantalla de gameover que sale cuando mueres, a los pocos segundos te manda de nuevo al menu principal
    /// </summary>
    public class GameOver : Fase
    {

        public GameOver(ContentManager contents)
        {
            content = contents;
            Fase.momentoActual = 0;
            eliminaTodo();
            fondo = content.Load<Texture2D>("flag/gameOver");
            cancion = content.Load<Song>("musica/Game Over");
            velocidadFon = 0;
        }

        public override void Update()
        {
            if (momentoActual == 700 || (GamePad.GetState(PlayerIndex.One).Buttons.B == ButtonState.Pressed))
            {
                MediaPlayer.Play(menu.menuSong);
                menu.estadoMenu = 0;
                Game1.estadodeljuego = Game1.MiEstado.Menu;

            }
            base.Update();

        }
        public override void Draw()
        {
            base.Draw();
        }
    }
}