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
    public class Secuencia2 : Fase
    {

        public Secuencia2(ContentManager contents)
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

            if (momentoActual == 10)
            {
                charla = new Charla(content, "Pdamon", "Muchachos, sigue sin haber tregua... alguien esta usando ASP desde la luna, como protectores del software libre tenemos que destruirle");
                cosas.Add(charla);
            }


            if (momentoActual == 300)
            {
                charla = new Charla(content, "RedStar", "No hay problema, haremos todo lo que esté en nuestra mano, iremos a la luna y destruiremos al enemigo");
                cosas.Add(charla);
            }

            if (momentoActual == 650)
            {
                charla = new Charla(content, "Pdamon", "Bien, se que su equipo lo conseguirá, adelante");
                cosas.Add(charla);
            }

            if (momentoActual == 900)
            {
                charla = new Charla(content, "Adam", "Destruiremos la luna, vale");
                cosas.Add(charla);
            }

            if (momentoActual == 1150)
            {
                charla = new Charla(content, "Pdamon", "No, la misión es destruir al enemigo, la luna dejadla como está");
                cosas.Add(charla);
            }

            if (momentoActual == 1400)
            {
                charla = new Charla(content, "Adam", "Destruiremos la luna, vale");
                cosas.Add(charla);
            }

            if (momentoActual == 1650)
            {
                charla = new Charla(content, "Pdamon", "...");
                cosas.Add(charla);
            }

            if (momentoActual == 1800)
            {
                charla = new Charla(content, "Adam", "Destruiremos la luna, vale");
                cosas.Add(charla);
            }

            if (momentoActual == 2050)
            {
                charla = new Charla(content, "Redstar", "¡CALLATE COÑO!");
                cosas.Add(charla);
            }

            if (momentoActual == 2400 || GamePad.GetState(PlayerIndex.One).Buttons.B == ButtonState.Pressed || (Keyboard.GetState().IsKeyDown(Keys.B)))
            {
                Game1.mission = new Mission2(content, Game1.numeroJugadores, Game1.naveSeleccionada1, Game1.naveSeleccionada2);
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