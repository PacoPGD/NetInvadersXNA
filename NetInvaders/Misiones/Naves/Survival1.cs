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
    /// Survival1 es la fase con enemigos infinitos
    /// </summary>
    public class Survival1 : Fase
    {
        public Random r;

        public Enemigo enemigo;
        public Survival1(ContentManager contents, int jugadore,int nave1, int nave2)
        {
            eliminaTodo();
            Fase.momentoActual = 0;
            nJugadores = jugadore;
            content = contents;
            fondo = content.Load<Texture2D>("fondos/cielo");
            cancion = content.Load<Song>("musica/Across the Blue Skys");
            velocidadFon = 2;
            if (nJugadores == 2)
            {
                inicializaJugador(2, nave2);
            }
            
            inicializaJugador(1,nave1);

            start = new visorStart(content);

 
        }

        public override void Update() {
            r = new Random(DateTime.Now.Millisecond + momentoActual);
            if (momentoActual == 100)
            {
                traseras.Add(start);
            }
            
            if (momentoActual == 25)
            {
                charla = new Charla(content, "Pdamon", "Consigue los maximos puntos posibles en este modo supervivencia");
                cosas.Add(charla);
            }

            if (momentoActual % 300==0)
            {
                for (int i = 0; i < 5; i++)
                {
                    enemigo = new NaveGenerica(content, 3, 0, r.Next(1,10), 1,i);
                    enemigos.Add(enemigo);
                }
                for (int i = 0; i < 5; i++)
                {
                    enemigo = new NaveGenerica(content, (int)Game1.width, 0, r.Next(1, 10), 1, i);
                    enemigos.Add(enemigo);
                }
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