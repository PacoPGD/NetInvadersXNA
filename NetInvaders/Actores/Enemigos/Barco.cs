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
    /// Clase que genera al enemigo banzai
    /// </summary>
    public class Barco : Enemigo
    {

        public Barco(ContentManager contents, int x, int y, int vx, int vy)
        {
            content = contents;
            jefe = true;
            imagenAnimada[0] = content.Load<Texture2D>("actores/enemigosnaves/Barco");

            this.x = x;
            this.y = y;
            this.vx = vx;
            this.vy = vy;
            this.FIRING_FREQUENCY = 10;//frecuencia de disparo

            this.shields = 12000;
            this.puntosAObtener = 50000;
            this.furiaAObtener = 20;
            inicializa();
        }


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
            Random aleatorio = new Random();
            
            disparo = new balaBarco(content, x + 75, y + 231,(int)(aleatorio.NextDouble() * 6)-3);
            Fase.balasE.Add(disparo);
            disparo = new balaBarco(content, x + 104, y + 239, (int)(aleatorio.NextDouble() * 6) - 3);
            Fase.balasE.Add(disparo);
            disparo = new balaBarco(content, x + 135, y + 238, (int)(aleatorio.NextDouble() * 6) - 3);
            Fase.balasE.Add(disparo);
            disparo = new balaBarco(content, x + 166, y + 239, (int)(aleatorio.NextDouble() * 6) - 3);
            Fase.balasE.Add(disparo);
            disparo = new balaBarco(content, x + 198, y + 240, (int)(aleatorio.NextDouble() * 6) - 3);
            Fase.balasE.Add(disparo);
            disparo = new balaBarco(content, x + 228, y + 238, (int)(aleatorio.NextDouble() * 6) - 3);
            Fase.balasE.Add(disparo);
        }

    }
}