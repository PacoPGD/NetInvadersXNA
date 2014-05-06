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
    /// Este es el menu desde el que seleccionamos la mision que queramos
    /// </summary>
    public class eligeMision
    {
        public int posicionCursor = 0;
        public int numeroOpciones = 9;
        public int []ejeXplaneta = new int[9];
        public int []ejeYplaneta = new int[9];
        public Texture2D fondo;
        public Texture2D[] opcionesImg = new Texture2D[9];
        public String[] nombreMisiones = new String[9];
        public Texture2D cursor;
        public ContentManager content;
        public eligeMision(ContentManager contents)
        {
            content = contents;
            fondo = content.Load<Texture2D>("fondos/bg1");
            cursor = content.Load<Texture2D>("menu/selec2");
            opcionesImg[0] = content.Load<Texture2D>("planetas/prueba");
            opcionesImg[1] = content.Load<Texture2D>("planetas/luna");
            opcionesImg[2] = content.Load<Texture2D>("planetas/prueba");
            opcionesImg[3] = content.Load<Texture2D>("planetas/marte");
            opcionesImg[4] = content.Load<Texture2D>("planetas/planetaoscuro");
            opcionesImg[5] = content.Load<Texture2D>("planetas/desierto");
            opcionesImg[6] = content.Load<Texture2D>("planetas/prueba");
            opcionesImg[7] = content.Load<Texture2D>("planetas/prueba");
            opcionesImg[8] = content.Load<Texture2D>("planetas/prueba");

            nombreMisiones[0] = "Protegiendo la tierra";
            nombreMisiones[1] = "Bicicleta lunar";
            nombreMisiones[2] = "Persecución espacial";
            nombreMisiones[3] = "¿Cuidado! Gravedad cero";
            nombreMisiones[4] = "El mundo de Adamuz Oscuro";
            nombreMisiones[5] = "Shoot acalorado en el desierto";
            nombreMisiones[6] = "La batalla final: base .net";
            nombreMisiones[7] = "La batalla final: base teleco";
            nombreMisiones[8] = "Modos especiales";

            menu.fuente = content.Load<SpriteFont>("fuente1");
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
                        Game1.mission = new SecuenciaIntro(content);
                        MediaPlayer.Play(Game1.mission.cancion);
                        Game1.estadodeljuego = Game1.MiEstado.Mission;
                    }
                    if (posicionCursor == 1)
                    {
                        Game1.mission = new Secuencia2(content);
                        MediaPlayer.Play(Game1.mission.cancion);
                        Game1.estadodeljuego = Game1.MiEstado.Mission;
                    }
                    if (posicionCursor == 8)
                    {
                        menu.estadoMenu = 4;
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
            Game1.spriteBatch.DrawString(menu.fuente, nombreMisiones[posicionCursor], new Vector2(400, 20), Color.White);
            for (int i = 0; i < opcionesImg.Length; i++)
            {
                Game1.spriteBatch.Draw(opcionesImg[i], new Rectangle(ejeXplaneta[i],ejeYplaneta[i],100,100), Color.White);
            }

            Game1.spriteBatch.Draw(cursor, new Rectangle(ejeXplaneta[posicionCursor],ejeYplaneta[posicionCursor],100,100), Color.White);
        }

        public void posicionPlanetas()
        {
            ejeXplaneta[0] = 50;
            ejeYplaneta[0] = 150;
            ejeXplaneta[1] = 200;
            ejeYplaneta[1] = 150;
            ejeXplaneta[2] = 350;
            ejeYplaneta[2] = 200;
            ejeXplaneta[3] = 500;
            ejeYplaneta[3] = 200;
            ejeXplaneta[4] = 650;
            ejeYplaneta[4] = 100;
            ejeXplaneta[5] = 650;
            ejeYplaneta[5] = 300;
            ejeXplaneta[6] = 800;
            ejeYplaneta[6] = 200;
            ejeXplaneta[7] = 800;
            ejeYplaneta[7] = 400;
            ejeXplaneta[8] = 1000;
            ejeYplaneta[8] = 600;

        }
    }
}