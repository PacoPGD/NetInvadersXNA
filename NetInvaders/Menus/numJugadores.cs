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
    /// Menu donde seleccionamos el numero de jugadores
    /// </summary>
    public class numJugadores 
    {
        public int posicionCursor = 0;

        public int numeroOpciones = 2;
        public Texture2D fondo;
        public Texture2D[] opcionesImg = new Texture2D[2];
        public Texture2D cursor;
        public ContentManager content;
        public numJugadores(ContentManager contents)
        {
            content = contents;
            fondo = content.Load<Texture2D>("menu/bgMenu");
            cursor = content.Load<Texture2D>("menu/selec2");
            opcionesImg[0] = content.Load<Texture2D>("menu/jugar");
            opcionesImg[1] = content.Load<Texture2D>("menu/opciones");


        }


        public void Update()
        {
            if (menu.descansoCursor == 0)
            {

                if (GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.Y < 0 && posicionCursor < numeroOpciones - 1)
                {
                    posicionCursor++;
                    menu.descansoCursor = 10;
                }
                if (GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.Y > 0 && posicionCursor > 0)
                {
                    posicionCursor--;
                    menu.descansoCursor = 10;
                }

                if (Keyboard.GetState().IsKeyDown(Keys.Space) || GamePad.GetState(PlayerIndex.One).Buttons.A == ButtonState.Pressed)
                {

                    if (posicionCursor == 0)
                    {
                       /* if (Gamer.SignedInGamers[PlayerIndex.One] == null)
                        {
                            Guide.ShowSignIn(1, false);
                        }
                        else
                        {*/
                            Game1.numeroJugadores = 1;
                            menu.estadoMenu = 2;
                       // }
                    }
                    if (posicionCursor == 1)
                    {
                        /*if (Gamer.SignedInGamers[PlayerIndex.One] == null || Gamer.SignedInGamers[PlayerIndex.Two] == null)
                        {
                            Guide.ShowSignIn(2, false);
                        }
                        else
                        {*/
                            Game1.numeroJugadores = 2;
                            menu.estadoMenu = 2;
                        //}
                    }

                    

                }


            }
            else
            {
                menu.descansoCursor--;
            }



            if (GamePad.GetState(PlayerIndex.One).Buttons.B == ButtonState.Pressed)
            {

                menu.estadoMenu = 0;
            }
        }

        public void Draw()
        {
            Game1.spriteBatch.Draw(fondo, new Rectangle(0, 0, (int)Game1.width, (int)Game1.height), Color.White);

            for (int i = 0; i < opcionesImg.Length; i++)
            {
                //800,600//31,470
                Game1.spriteBatch.Draw(opcionesImg[i], new Rectangle((int)(Game1.width / 5.16), (int)(i * (Game1.width / 10.6) + Game1.height / 2.5), (int)(Game1.width / 1.6), (int)(Game1.height / 17)), Color.White);
            }
            Game1.spriteBatch.Draw(cursor, new Rectangle((int)(Game1.width / 8.3), (int)(posicionCursor * (Game1.width / 10.6) + Game1.height / 2.9), (int)(Game1.width / 1.33), (int)(Game1.height / 6)), Color.White);
        }
    }
}