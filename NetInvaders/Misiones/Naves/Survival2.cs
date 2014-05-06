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
    /// Survival2 es la fase donde no hacen mas que caer rocas
    /// </summary>
    public class Survival2 : Fase
    {
        public Random r;
        public Enemigo enemigo;
        int survivalVar = 0;
        public Survival2(ContentManager contents, int jugadore, int nave1, int nave2)
        {
            eliminaTodo();
            Fase.momentoActual = 0;
            nJugadores = jugadore;
            content = contents;
            fondo = content.Load<Texture2D>("fondos/bg1");
            cancion = content.Load<Song>("musica/Wild Side");
            velocidadFon = 10;
            
            if (nJugadores == 2)
            {
                inicializaJugador(2, nave2);
                jugador2.fuegoDisponible = 0;
            }

            inicializaJugador(1, nave1);
            jugador1.fuegoDisponible = 0;
            
            start = new visorStart(content);


        }

        public override void Update()
        {
            r = new Random(DateTime.Now.Millisecond-momentoActual);

            if (momentoActual == 100)
            {
                traseras.Add(start);
            }

            if (momentoActual == 25)
            {
                charla = new Charla(content, "Pdamon", "Consigue los maximos puntos posibles en este modo supervivencia");
                cosas.Add(charla);
            }

            if (momentoActual >= 100)
            {
                jugador1.score = jugador1.score + 20;

                if (nJugadores == 2)
                {
                    jugador2.score = jugador2.score + 20;
                }
            }

            if (momentoActual >= 100 && momentoActual %4 == 0)
            {
                enemigo = new Piedra(content, r.Next(0,(int)Game1.width), 0, 0, 5+survivalVar, 0);
                enemigos.Add(enemigo);
            }

            if (momentoActual % 400 == 0)
            {
                survivalVar++;
            }
            if (jugadores.Count == 0)
            {
                cosas.Remove(charla);
                Game1.mission = new GameOver(content);
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