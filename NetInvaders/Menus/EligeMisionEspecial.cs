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
    /// Este es el menu donde escogemos la fase survival que queramos
    /// </summary>
    public class eligeMisionEspecial
    {
        public int posicionCursor = 0;
        public int numeroOpciones = 2;
        public int[] ejeXplaneta = new int[2];
        public int[] ejeYplaneta = new int[2];
        public Texture2D fondo;
        public Texture2D[] opcionesImg = new Texture2D[2];
        public Texture2D cursor;
        public ContentManager content;
        public eligeMisionEspecial(ContentManager contents)
        {
            content = contents;
            fondo = content.Load<Texture2D>("fondos/bg1");
            cursor = content.Load<Texture2D>("menu/selec2");
            opcionesImg[0] = content.Load<Texture2D>("planetas/prueba");
            opcionesImg[1] = content.Load<Texture2D>("planetas/prueba");
            posicionPlanetas();
        }


        public void Update()
        {
            if (menu.descansoCursor == 0)
            {

                if ((Keyboard.GetState().IsKeyDown(Keys.S) || (GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.X > 0)) && posicionCursor < numeroOpciones - 1)
                {
                    posicionCursor++;
                    menu.descansoCursor = 10;
                }
                if ((Keyboard.GetState().IsKeyDown(Keys.W) || (GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.X < 0)) && posicionCursor > 0)
                {
                    posicionCursor--;
                    menu.descansoCursor = 10;
                }

                if (Keyboard.GetState().IsKeyDown(Keys.Space) || (GamePad.GetState(PlayerIndex.One).Buttons.A == ButtonState.Pressed))
                {

                    if (posicionCursor == 0)
                    {
                        Game1.mission = new Survival1(content, Game1.numeroJugadores, Game1.naveSeleccionada1, Game1.naveSeleccionada2);
                        MediaPlayer.Play(Game1.mission.cancion);
                        Game1.estadodeljuego = Game1.MiEstado.Mission;
                    }
                    if (posicionCursor == 1)
                    {
                        Game1.mission = new Survival2(content, Game1.numeroJugadores, Game1.naveSeleccionada1, Game1.naveSeleccionada2);
                        MediaPlayer.Play(Game1.mission.cancion);
                        Game1.estadodeljuego = Game1.MiEstado.Mission;
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
                Game1.spriteBatch.Draw(opcionesImg[i], new Rectangle(ejeXplaneta[i], ejeYplaneta[i], opcionesImg[i].Width / 4, opcionesImg[i].Height / 4), Color.White);
            }

            Game1.spriteBatch.Draw(cursor, new Rectangle(ejeXplaneta[posicionCursor], ejeYplaneta[posicionCursor], opcionesImg[0].Width / 4, opcionesImg[0].Height / 4), Color.White);
        }

        public void posicionPlanetas()
        {
            ejeXplaneta[0] = 50;
            ejeYplaneta[0] = 200;
            ejeXplaneta[1] = 150;
            ejeYplaneta[1] = 200;

        }
    }
}