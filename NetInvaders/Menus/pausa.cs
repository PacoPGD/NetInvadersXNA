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
    /// Esta clase es la que pinta la chapa de charla con la que hago que los personajes hablen en las secuencias,
    /// simplemente tengo varias string "texto a pintar" y otro para ir añadiendo letras y asi no salgan todas a la vez
    /// </summary>
    public class pausa
    {

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



        public pausa(Game1 juegos, ContentManager contents)
        {
            juego = juegos;
            content = contents;

            fuente = content.Load<SpriteFont>("menu/fuentemenu");

            fondo = content.Load<Texture2D>("menu/bgMenu");
            cursor = content.Load<Texture2D>("menu/selec2");
            opcionesImg[0] = content.Load<Texture2D>("menu/jugar");
            opcionesImg[1] = content.Load<Texture2D>("menu/opciones");

            cursor = content.Load<Texture2D>("menu/selec2");


        }


        public void Update()
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.B == ButtonState.Pressed)
            {
                Game1.estadodeljuego = Game1.MiEstado.Mission;
            }

        }

        public void Draw()
        {

        }
    }
}