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
    /// Clase con la nave de Angel
    /// </summary>
    public class Angel : eljugador
    {

        public Angel(ContentManager contents, int jugador)
        {

            content = contents;
            nJugador = jugador;
            placaJugador = new PlacaJugador(content, jugador);
            Fase.cosas.Add(placaJugador);
            this.PLAYER_SPEED = 8 * constanteSpeed;
            this.MAX_SHIELDS = 5 * constanteShield;
            this.clusterBombs = 0 * constanteBomb;

            this.numero =5;
            shields = MAX_SHIELDS;
            MAX_MANA = 100;
            mana = 100;
            imagenAnimada[0] = content.Load<Texture2D>("actores/personajesnaves/Angel/nave");
            imagenizq = content.Load<Texture2D>("actores/personajesnaves/Angel/naveIzq");
            imagender = content.Load<Texture2D>("actores/personajesnaves/Angel/naveDer");

            if (jugador == 1)
            {
                x = (int)Game1.width / 2 - 100;
            }
            else
            {
                x = (int)Game1.width / 2 + 100;
            }
            y = 500;


            inicializa();


        }

        public override void disparar()
        {
            if (tiempodisparo == 10)
            {
                disparo = new balaAngel(content, x + 8, y, nJugador);
                Fase.balasJ.Add(disparo);
                tiempodisparo = 0;
            }
        }
        public override void ataqueFuria()
        {

        }

        public override void Update()
        {
            base.Update();
        }
        public override void Draw()
        {
            base.Draw();
        }

    }
}