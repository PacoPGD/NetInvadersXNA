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
    /// Menu principal del juego donde escogemos la modalidad de juego
    /// </summary>
    public class menu
    {
        public static Song menuSong;
        public static SpriteFont fuente;
        public int posicionCursor = 0;
        public static int descansoCursor = 10;
        public static int descansoCursor2 = 10;
        public int numeroOpciones = 4;
        public Texture2D fondo;
        public Texture2D[] opcionesImg = new Texture2D[4];
        public Texture2D cursor;
        public Game1 juego;
        public ContentManager content;

        public static int estadoMenu = 0;

        numJugadores menuJugadores;
        eligeNave elegirNave;
        eligeMision elegirMision;
        eligeMisionEspecial elegirMisionEspecial;

        //La generación de los contenidos es como en todas las otras pantallas
        public menu(Game1 juegos,ContentManager contents) 
        {
            juego = juegos;
            content = contents;
            fondo = content.Load<Texture2D>("menu/bgMenu");
            fuente = content.Load<SpriteFont>("menu/fuentemenu");

            opcionesImg[0] = content.Load<Texture2D>("menu/jugar");
            opcionesImg[1] = content.Load<Texture2D>("menu/opciones");
            opcionesImg[2] = content.Load<Texture2D>("menu/creditos");
            opcionesImg[3] = content.Load<Texture2D>("menu/salir");
            cursor = content.Load<Texture2D>("menu/selec2");
            menuSong = content.Load<Song>("musica/You Make Me Crazy");


            menuJugadores = new numJugadores(content);
            elegirNave = new eligeNave(content);
            elegirMision = new eligeMision(content);
            elegirMisionEspecial = new eligeMisionEspecial(content);
        }
        

    
        //Este es el update que mueve el cursor y dependiendo de la opcion seleccionada nos mande a uno u otro menú
        public void Update()
        {

            if (estadoMenu == 0)
            {
                if (descansoCursor == 0)
                {

                    if ((Keyboard.GetState().IsKeyDown(Keys.S) || (GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.Y < 0)) && posicionCursor < numeroOpciones - 1)
                    {
                        posicionCursor++;
                        descansoCursor = 10;
                    }
                    if ((Keyboard.GetState().IsKeyDown(Keys.W) || (GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.Y > 0)) && posicionCursor > 0)
                    {
                        posicionCursor--;
                        descansoCursor = 10;
                    }
                }
                else
                {
                    descansoCursor--;
                }

                if (Keyboard.GetState().IsKeyDown(Keys.Space) || (GamePad.GetState(PlayerIndex.One).Buttons.A == ButtonState.Pressed))
                {
                    if (posicionCursor == 0)
                    {
                        descansoCursor = 10;
                        estadoMenu = 1;
                    }
                    if (posicionCursor == 2)
                    {
                        Game1.mission = new creditos(content);
                        MediaPlayer.Play(Game1.mission.cancion);
                        Game1.estadodeljuego = Game1.MiEstado.Mission;

                    }
                    if (posicionCursor == 3)
                    {
                        MediaPlayer.Stop();
                        juego.Exit();

                    }
                }
            }
            else
            {
                switch (estadoMenu)
                {
                    case 1: menuJugadores.Update(); break;
                    case 2: elegirNave.Update(); break;
                    case 3: elegirMision.Update(); break;
                    case 4: elegirMisionEspecial.Update(); break;
                }
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Space) || (GamePad.GetState(PlayerIndex.One).Buttons.A == ButtonState.Pressed))
            {
                descansoCursor = 10;
            }
            if ((GamePad.GetState(PlayerIndex.One).Buttons.B == ButtonState.Pressed))
            {
                descansoCursor = 10;
            }
        }

        public void Draw()
        {

            Game1.spriteBatch.Begin();

            if (estadoMenu == 0)
            {
                Game1.spriteBatch.Draw(fondo, new Rectangle(0, 0, (int)Game1.width, (int)Game1.height), Color.White);
                for (int i = 0; i < 4; i++)
                {
                    //800,600//31,470
                    Game1.spriteBatch.Draw(opcionesImg[i], new Rectangle((int)(Game1.width / 5.16), i * 100 +290, (int)(Game1.width / 1.6), (int)(Game1.height / 17)), Color.White);
                }

                Game1.spriteBatch.Draw(cursor, new Rectangle((int)(Game1.width / 8.3), posicionCursor * 100 +250, (int)(Game1.width / 1.33), (int)(Game1.height / 6)), Color.White);
            }
            else
            {
                switch (estadoMenu)
                {
                    case 1: menuJugadores.Draw(); break;
                    case 2: elegirNave.Draw(); break;
                    case 3: elegirMision.Draw(); break;
                    case 4: elegirMisionEspecial.Draw(); break;
                }

            }
            Game1.spriteBatch.End();
        }
    }
}