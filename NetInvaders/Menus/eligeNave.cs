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
    /// Este es el menu desde el que seleccionamos nuestra nave
    /// </summary>
    public class eligeNave
    {

        public int[] posicionCursorX = new int[2];
        public int[] posicionCursorY = new int[2];

        public int listoj1 = 0;
        public int listoj2 = 0;

        public int descansoCursor2 = 10;

        public int numeroOpciones =  6;

        public Texture2D fondo;
        public Texture2D[] opcionesImg = new Texture2D[6];
        public Texture2D cursor;

        public Texture2D[] cara = new Texture2D[6];

        public Texture2D estrella;
        public ContentManager content;


        public eligeNave(ContentManager contents)
        {


        posicionCursorX[0] = 0;
        posicionCursorY[0] = 0;
        posicionCursorX[1] = 3;
        posicionCursorY[1] = 0;


            content = contents;
            fondo = content.Load<Texture2D>("menu/menu");
            cursor = content.Load<Texture2D>("menu/selec2");
            estrella = content.Load<Texture2D>("estrella");
            opcionesImg[0] = content.Load<Texture2D>("actores/personajesnaves/RedStar/nave");
            opcionesImg[1] = content.Load<Texture2D>("actores/personajesnaves/Cless/nave");
            opcionesImg[2] = content.Load<Texture2D>("actores/personajesnaves/Xavier/nave");
            opcionesImg[3] = content.Load<Texture2D>("actores/personajesnaves/John/nave");
            opcionesImg[4] = content.Load<Texture2D>("actores/personajesnaves/Angel/nave");
            opcionesImg[5] = content.Load<Texture2D>("actores/personajesnaves/RedStar/nave");


            cara[0] = content.Load<Texture2D>("caras/RedStar");
            cara[1] = content.Load<Texture2D>("caras/Cless");
            cara[2] = content.Load<Texture2D>("caras/Xavier");
            cara[3] = content.Load<Texture2D>("caras/John");
            cara[4] = content.Load<Texture2D>("caras/Angel");
            cara[5] = content.Load<Texture2D>("caras/Adamuz");

        }


        public void Update()
        {
            /*
            if (Gamer.SignedInGamers[PlayerIndex.One] != null)
            {
                nombre1 = Gamer.SignedInGamers[PlayerIndex.One].Gamertag;
                gamerProfile1 = Gamer.SignedInGamers[PlayerIndex.One].GetProfile();
                picture1 = gamerProfile1.GamerPicture;

            }

            if (Gamer.SignedInGamers[PlayerIndex.Two] != null)
            {
                nombre2 = Gamer.SignedInGamers[PlayerIndex.Two].Gamertag;
                gamerProfile2 = Gamer.SignedInGamers[PlayerIndex.One].GetProfile();
                picture2 = gamerProfile2.GamerPicture;

            }
            */

            if (Game1.numeroJugadores == 1)
            {
                if (GamePad.GetState(PlayerIndex.Two).Buttons.Start == ButtonState.Pressed){
                    Game1.numeroJugadores = 2;
                }
            }
            

            if (menu.descansoCursor == 0)
            {

                if ((Keyboard.GetState().IsKeyDown(Keys.S) || (GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.Y < 0)) && posicionCursorY[0] < 1)
                {
                    posicionCursorY[0]++;
                    menu.descansoCursor = 10;
                }
                if ((Keyboard.GetState().IsKeyDown(Keys.W) || (GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.Y > 0)) && posicionCursorY[0] > 0)
                {
                    posicionCursorY[0]--;
                    menu.descansoCursor = 10;
                }

                if ((Keyboard.GetState().IsKeyDown(Keys.D) || (GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.X > 0)) && posicionCursorX[0] <2)
                {
                    posicionCursorX[0]++;
                    menu.descansoCursor = 10;
                }
                if ((Keyboard.GetState().IsKeyDown(Keys.A) || (GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.X < 0)) && posicionCursorX[0] >0)
                {
                    posicionCursorX[0]--;
                    menu.descansoCursor = 10;
                }


                if (Keyboard.GetState().IsKeyDown(Keys.Space) || (GamePad.GetState(PlayerIndex.One).Buttons.A == ButtonState.Pressed))
                {
                    if (listoj1 == 0)
                    {
                        listoj1 = 1;
                    }
                    else
                    {
                        listoj1 = 0;
                    }
                }

                if (GamePad.GetState(PlayerIndex.One).Buttons.B == ButtonState.Pressed)
                {
                    if (listoj1 == 1)
                    {
                        listoj1 = 0;
                        menu.descansoCursor = 10;
                    }
                    else
                    {
                        listoj2 = 0;
                        menu.estadoMenu = 1;
                    }

                }


            }
            else
            {
                menu.descansoCursor--;
            }

            if (menu.descansoCursor2 == 0)
            {

                if ((GamePad.GetState(PlayerIndex.Two).ThumbSticks.Left.Y < 0) && posicionCursorY[1] < 1)
                {
                    posicionCursorY[1]++;
                    menu.descansoCursor2 = 10;
                }
                if ((GamePad.GetState(PlayerIndex.Two).ThumbSticks.Left.Y > 0) && posicionCursorY[1] > 0)
                {
                    posicionCursorY[1]--;
                    menu.descansoCursor2 = 10;
                }

                if ((GamePad.GetState(PlayerIndex.Two).ThumbSticks.Left.X > 0) && posicionCursorX[1] < 3)
                {
                    posicionCursorX[1]++;
                    menu.descansoCursor2 = 10;
                }
                if ( (GamePad.GetState(PlayerIndex.Two).ThumbSticks.Left.X < 0) && posicionCursorX[1] > 0)
                {
                    posicionCursorX[1]--;
                    menu.descansoCursor2 = 10;
                }


                if (GamePad.GetState(PlayerIndex.Two).Buttons.A == ButtonState.Pressed)
                {
                    if (listoj2 == 0)
                    {
                        listoj2 = 1;
                    }
                    else
                    {
                        listoj2 = 0;
                    }
                }

                if (GamePad.GetState(PlayerIndex.One).Buttons.B == ButtonState.Pressed)
                {
                    if (listoj2 == 1)
                    {
                        listoj2 = 0;
                        menu.descansoCursor2 = 10;
                    }
                    else
                    {
                        listoj2 = 0;
                        menu.estadoMenu = 1;
                    }

                }


            }
            else
            {
                menu.descansoCursor2--;
            }



            if (listoj1 == 1)
            {
                if (Game1.numeroJugadores == 2)
                {
                    if (listoj2 == 1)
                    {
                        listoj1 = 0;
                        listoj2 = 0;
                        Game1.naveSeleccionada1 = posicionCursorX[0] + 1 + posicionCursorY[0] * 3;
                        Game1.naveSeleccionada2 = posicionCursorX[1] + 1 + posicionCursorY[1] * 3;
                        menu.estadoMenu = 3;
                    }
                }
                else
                {
                    listoj1 = 0;
                    Game1.naveSeleccionada1 = posicionCursorX[0] + 1 + posicionCursorY[0] * 3;
                    menu.estadoMenu = 3;
                }

            }

        }

        public void Draw()
        {
           Game1.spriteBatch.Draw(fondo, new Rectangle(0, 0, (int)Game1.width, (int)Game1.height), Color.White);
            /*
            if (Game1.numeroJugadores == 2)
            {
                Game1.spriteBatch.DrawString(menu.fuente, Gamer.SignedInGamers[PlayerIndex.Two].Gamertag, new Vector2(500, 40), Color.White);
                Game1.spriteBatch.Draw(Game1.picture2, new Rectangle(500, 80, 80, 80), Color.White);
            }*/

            if (listoj1 == 1)
            {
                Game1.spriteBatch.DrawString(menu.fuente, "Listo", new Vector2(0, 50), Color.White);
            }


            for (int i = 0; i < opcionesImg.Length/2; i++)
            {
                Game1.spriteBatch.Draw(opcionesImg[i], new Rectangle(220*(i+1),100,150,150), Color.White);
            }
            for (int i = opcionesImg.Length/2; i < opcionesImg.Length; i++)
            {
                Game1.spriteBatch.Draw(opcionesImg[i], new Rectangle(220 * (i -2), 350, 150,150), Color.White);
            }

            
            Game1.spriteBatch.Draw(cursor, new Rectangle(220*(posicionCursorX[0]+1),100 +(posicionCursorY[0]*250),150,150), Color.Red);

            Game1.spriteBatch.Draw(cara[posicionCursorX[0] + posicionCursorY[0]*3], new Rectangle(40, 585, 112,108), Color.White);

            pintaEstrellas(1);

            Game1.spriteBatch.DrawString(menu.fuente, "Ataque", new Vector2(600, 580), Color.White);
            Game1.spriteBatch.DrawString(menu.fuente, "Velocidad", new Vector2(600, 608), Color.White);
            Game1.spriteBatch.DrawString(menu.fuente, "Escudos", new Vector2(600, 636), Color.White);
            Game1.spriteBatch.DrawString(menu.fuente, "Bombas", new Vector2(600, 664), Color.White);
            if (Game1.numeroJugadores == 2)
            {
                if (listoj2 == 1)
                {
                    Game1.spriteBatch.DrawString(menu.fuente, "Listo", new Vector2(500, 50), Color.White);
                }
                Game1.spriteBatch.Draw(cursor, new Rectangle(220 * (posicionCursorX[1] + 1), 100 + (posicionCursorY[1] * 250), 150, 150), Color.White);
               
                Game1.spriteBatch.Draw(cara[posicionCursorX[1] + posicionCursorY[1] * 3], new Rectangle(1280-172, 585,112,108), Color.White);
                pintaEstrellas(2);
            }
        }

        public void pintaEstrellas(int jugador)
        {
            int []datos = new int[4];

            int i,j;

            int despla;
            int puntoPar;
            //DATOS REDSTAR
            if (posicionCursorX[jugador-1] + posicionCursorY[jugador-1] * 3 == 0)
            {
                datos[0] = 6;
                datos[1] = 5;
                datos[2] = 7;
                datos[3] = 0;
            }
            //DATOS CLESS
            if (posicionCursorX[jugador - 1] + posicionCursorY[jugador - 1] * 3 == 1)
            {
                datos[0] = 7;
                datos[1] = 5;
                datos[2] = 6;
                datos[3] = 0;
            }
            //DATOS XAVIER
            if (posicionCursorX[jugador - 1] + posicionCursorY[jugador - 1] * 3 == 2)
            {
                datos[0] = 5;
                datos[1] = 6;
                datos[2] = 7;
                datos[3] = 0;
            }
            //DATOS JOHN
            if (posicionCursorX[jugador - 1] + posicionCursorY[jugador - 1] * 3 == 3)
            {
                datos[0] = 8;
                datos[1] = 4;
                datos[2] = 6;
                datos[3] = 0;
            }
            //DATOS ANGEL
            if (posicionCursorX[jugador - 1] + posicionCursorY[jugador - 1] * 3 == 4)
            {
                datos[0] = 5;
                datos[1] = 8;
                datos[2] = 5;
                datos[3] = 0;
            }
            //DATOS ADAMUZ
            if (posicionCursorX[jugador - 1] + posicionCursorY[jugador - 1] * 3 == 5)
            {
                datos[0] = 10;
                datos[1] = 10;
                datos[2] = 10;
                datos[3] = 10;
            }


            if (jugador == 1)
            {
                despla = 20;
                puntoPar = 150;
            }
            else
            {
                despla = -20;
                puntoPar = 1080;
            }

            for (j = 0; j < datos.Length; j++)
            {
                for (i = 0; i < datos[j]; i++)
                {
                    Game1.spriteBatch.Draw(estrella, new Rectangle(puntoPar + i * despla, 580 + j*28, 52, 28), Color.White);
                }
            }
        }
    }
}