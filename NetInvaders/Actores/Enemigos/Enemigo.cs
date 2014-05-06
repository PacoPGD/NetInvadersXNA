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
    /// De esta clase heredan todos los enemigos del juego
    /// </summary>
    /// 
    public abstract class Enemigo : Actor
    {
        public int idUltimaBala;

        public Explosion explo;
        public Random r;
        public disparoEnemigo disparo;
        public Boolean jefe = false;
        public int numEnemigo;
        public int shields;
        public int puntosAObtener;
        protected int furiaAObtener;
        public int FIRING_FREQUENCY;
        public eljugador apuntado;

        public Enemigo() { }
        public Enemigo(ContentManager content) {}

  

        //Con el update siempre guardo el jugador que es el ultimo en disparar para saber a quien asignar la puntuacion y furia
        public override void Update()
        {
            r = new Random(DateTime.Now.Millisecond+(numEnemigo*numEnemigo));

            if (shields <= 0)
            {
                explo = new Explosion(content,x,y, width, height);
                Fase.cosas.Add(explo);

                if (idUltimaBala == 1) 
                {
                    Fase.jugador1.score = Fase.jugador1.score + puntosAObtener;
                    Fase.jugador1.fury = Fase.jugador1.fury + furiaAObtener;
                }
                else 
                { 
                    Fase.jugador2.score = Fase.jugador2.score + puntosAObtener;
                    Fase.jugador2.fury = Fase.jugador2.fury + furiaAObtener;
                }
             
                paraBorrar = true;
            }
            base.Update();

            if (x < 0 && vx < 0)
            {
                vx = -vx;
            }
            if (x > Game1.width - height && vx > 0)
            {
                vx = -vx;
            }
        }
        public override void Draw()
        {
            base.Draw();
        }

        public void eligeEnemigo()
        {
            if (r.Next(1, Fase.nJugadores) <= 1.5)
            {
                apuntado = Fase.jugador1;
            }
            else
            {
                apuntado = Fase.jugador2;
            }


        }
    }
}