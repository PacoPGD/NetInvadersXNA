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
    /// Clase que genera al enemigo tirador preciso
    /// </summary>
    public class TiradorPreciso : Enemigo
    {
        public int resVy;
        public int resVx;
        public TiradorPreciso(ContentManager contents, int x, int y, int vx, int vy)
        {
            content = contents;
            imagenAnimada[0] = content.Load<Texture2D>("actores/enemigosnaves/preciso");

            this.x = x;
            this.y = y;
            this.vx = vx;
            this.vy = vy;
            resVy = vy;
            resVx = vx;

            this.shields = 10;
            this.puntosAObtener = 3000;
            this.furiaAObtener = 3;
            this.FIRING_FREQUENCY = 5;
            inicializa();
        }


        public override void Update()
        {
            base.Update();

            if (tiempoVida == 1)
            {
                eligeEnemigo();
            }

            if (Fase.momentoActual % 6 == 0)
            {
                    if (x < apuntado.x)
                    {
                        vx = Math.Abs(resVx);
                    }
                    else
                    {
                        if (x == apuntado.x)
                        {
                            vx = 0;
                        }
                        else
                        {
                            vx = -Math.Abs(resVx);
                        }
                    }

                    if (y + 300 < apuntado.y)
                    {
                        vy = Math.Abs(resVy);
                    }
                    else
                    {
                        if (y + 300 == apuntado.y)
                        {
                            vy = 0;
                        }
                        else
                        {
                            vy = -Math.Abs(resVy);
                        }
                    }
                

                if (r.Next(0, 100) < FIRING_FREQUENCY)
                    disparar();

            }


        }
        public override void Draw()
        {
            base.Draw();
        }
        public void disparar()
        {
            disparo = new balaGenerico(content, x + this.height / 2, y + this.width);
            Fase.balasE.Add(disparo);
        }
    }
}