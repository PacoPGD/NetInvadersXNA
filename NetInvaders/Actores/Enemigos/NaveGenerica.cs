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
    /// Clase con la nave enemiga generica, es la unica que recibira la descripcion detallada, los demas enemigos solo tienen cambios puntuales
    /// </summary>
    public class NaveGenerica : Enemigo
    {

        public NaveGenerica(ContentManager contents,int x, int y, int vx, int vy,int nEnemigo)
        {
            content = contents;
            imagenAnimada[0] = content.Load<Texture2D>("actores/enemigosnaves/generico");
            //ancho y alto del enemigo

            this.x = x;
            this.y = y;
            this.vx = vx;
            this.vy = vy;
            numEnemigo = nEnemigo;
            this.shields=10;//su vida
            this.puntosAObtener=500;//puntos que otorga
            this.furiaAObtener=1;//furia que otorga
            this.FIRING_FREQUENCY = 5;//frecuencia de disparo
            inicializa();
        }

        public NaveGenerica(ContentManager contents, int x, int y, int vx, int vy, int nEnemigo,int points)
        {
            content = contents;
            imagenAnimada[0] = content.Load<Texture2D>("actores/enemigosnaves/generico");
            //ancho y alto del enemigo
            width = 64;
            height = 43;
            this.x = x;
            this.y = y;
            this.vx = vx;
            this.vy = vy;
            numEnemigo = nEnemigo;
            this.shields = 10;//su vida
            this.puntosAObtener = points;//puntos que otorga
            this.furiaAObtener = 1;//furia que otorga
            this.FIRING_FREQUENCY = 5;//frecuencia de disparo
            inicializa();
        }



        //Los updates de los enemigos son los que contienen su comportamiento una vez estan en juego
        public override void Update()
        {
            base.Update();

            if (r.Next(0, 100) < FIRING_FREQUENCY)
                disparar();
        

        }
        public override void Draw()
        {
            base.Draw();
        }
        public void disparar() 
        {
            disparo = new balaGenerico(content, x+this.height/2, y + this.width);
            Fase.balasE.Add(disparo);
        }
    }
}