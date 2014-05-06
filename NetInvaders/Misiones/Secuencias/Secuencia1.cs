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
    /// Esta es una de las secuencias de juego, todas heredan de fase y simplemente en los updates indico las charlas y cosas que pasarán
    /// </summary>
    public class Secuencia1 : Fase
    {

        public Secuencia1(ContentManager contents)
        {
            eliminaTodo();
            Fase.momentoActual = 0;
            content = contents;
            fondo = content.Load<Texture2D>("fondos/bg1");
            cancion = content.Load<Song>("musica/Oblivion");
            velocidadFon = 1;

        }

        public override void Update()
        {
            /*
            if (momentoActual == 10)
            {
                decorado = new decorado(content, 400, -500, 0, 4, "actores/personajesnaves/Cless/nave");
                cosas.Add(decorado);
            }
            */

            if (momentoActual == 10)
            {
                charla = new Charla(content, "Cless", "Uff, vaya aburrimiento, odio hacer estas vigilancias");
                cosas.Add(charla);
            }

            if (momentoActual == 210)
            {
                charla = new Charla(content, "Xavier", "traigo un mensaje urgente de PDAMON");
                cosas.Add(charla);
            }

            if (momentoActual == 410)
            {
                charla = new Charla(content, "Pdamon", "La tregua con los .net ha finalizado, hemos descubierto como han usado su asqueroso compilador");
                cosas.Add(charla);
            }
            if (momentoActual == 660)
            {
                charla = new Charla(content, "Pdamon", "cuando fui a amenazarlos me pegaron un guantazo y me dijeron que mandarian tropas a la tierra");
                cosas.Add(charla);
            }
            if (momentoActual == 910)
            {
                charla = new Charla(content, "Pdamon", "Os quiero alli cubriendo todos los puntos estrategicos posibles");
                cosas.Add(charla);
            }

            if (momentoActual == 1110)
            {
                charla = new Charla(content, "Cless", "Vaya movida...");
                cosas.Add(charla);
            }


            if (momentoActual == 1210 || GamePad.GetState(PlayerIndex.One).Buttons.B == ButtonState.Pressed || (Keyboard.GetState().IsKeyDown(Keys.B)))
            {
                Game1.mission = new Mission1(content, Game1.numeroJugadores, Game1.naveSeleccionada1, Game1.naveSeleccionada2);
                MediaPlayer.Play(Game1.mission.cancion);
                Game1.estadodeljuego = Game1.MiEstado.Mission;
            }
            base.Update();

        }
        public override void Draw()
        {
            base.Draw();
        }
    }
}