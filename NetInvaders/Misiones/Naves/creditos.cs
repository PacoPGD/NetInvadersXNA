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
    /// Pantalla de creditos del juego
    /// </summary>
    public class creditos : Fase
    {
        
        public creditos(ContentManager contents)
        {
            eliminaTodo();
            Fase.momentoActual = 0;
            content = contents;
            fondo = content.Load<Texture2D>("fondos/bg1");
            cancion = content.Load<Song>("musica/Dream End");
            fuente = content.Load<SpriteFont>("fuente1");
            velocidadFon = 1;

        }

        public override void Update() {

            base.Update();
            if (GamePad.GetState(PlayerIndex.One).Buttons.B == ButtonState.Pressed)
            {
                MediaPlayer.Play(menu.menuSong);
                Game1.estadodeljuego = Game1.MiEstado.Menu;
            }

        }
        public override void Draw()
        {
            Game1.spriteBatch.Begin();
            //pintamos el fondo
            Game1.spriteBatch.Draw(fondo, new Rectangle(0, posFon, (int)Game1.width, (int)Game1.height), Color.White);
            Game1.spriteBatch.Draw(fondo, new Rectangle(0, posFon - (int)Game1.height, (int)Game1.width, (int)Game1.height), Color.White);

            Game1.spriteBatch.DrawString(fuente, "Net Invaders Moral Inyector", new Vector2(240, 20), Color.Red);
            Game1.spriteBatch.DrawString(fuente, "Proyecto presentado por Francisco García Díaz", new Vector2(280, 50), Color.White);
            Game1.spriteBatch.DrawString(fuente, "Ciclo Formativo Grado Superior: Administración de Sistemas Informaticos", new Vector2(340, 80), Color.White);
            Game1.spriteBatch.DrawString(fuente, "Programación y diseño del proyecto: Francisco García Díaz", new Vector2(340, 110), Color.White);
            Game1.spriteBatch.DrawString(fuente, "Diseños otorgados por Jesus Rodriguez Perez", new Vector2(340, 140), Color.White);
            Game1.spriteBatch.DrawString(fuente, "Música otorgada por Peergynt Lobogris", new Vector2(340, 170), Color.White);
            Game1.spriteBatch.DrawString(fuente, "Con la colaboración en voces y otros:", new Vector2(340, 200), Color.White);
            Game1.spriteBatch.DrawString(fuente, "Rafael Muñoz", new Vector2(380, 230), Color.White);
            Game1.spriteBatch.DrawString(fuente, "Francisco Garcia", new Vector2(380, 260), Color.White);
            Game1.spriteBatch.DrawString(fuente, "Jesus Rodriguez", new Vector2(380, 290), Color.White);
            Game1.spriteBatch.DrawString(fuente, "Juan Jesus", new Vector2(380, 320), Color.White);
            Game1.spriteBatch.DrawString(fuente, "Agustin Serrano", new Vector2(380, 350), Color.White);
            Game1.spriteBatch.DrawString(fuente, "Adam Gutierrez", new Vector2(380, 380), Color.White);
            Game1.spriteBatch.DrawString(fuente, "Gabriel Parejo", new Vector2(380, 410), Color.White);
            Game1.spriteBatch.DrawString(fuente, "Juan Carlos Ordoñez", new Vector2(380, 440), Color.White);

            Game1.spriteBatch.End();

        }
    }
}