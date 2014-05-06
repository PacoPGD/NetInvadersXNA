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
    public class Banzai : Enemigo
    {

        public Banzai(ContentManager contents, int x, int y, int vx, int vy)
        {
            content = contents;
            imagenAnimada[0] = content.Load<Texture2D>("actores/enemigosnaves/banzai");

            this.x = x;
            this.y = y;
            this.vx = vx;
            this.vy = vy;


            this.shields = 10;
            this.puntosAObtener = 3000;
            this.furiaAObtener = 3;
            inicializa();


        }


        public override void Update()
        {
            base.Update();

            if (tiempoVida == 1)
            {
                eligeEnemigo();
            }

            if (Fase.momentoActual % 4 == 0)
            {
                    if (x < apuntado.x)
                    {
                        vx = Math.Abs(vx);
                    }
                    else
                    {
                        vx = -Math.Abs(vx);
                    }
                    if (y < apuntado.y)
                    {
                        vy = Math.Abs(vy);
                    }
                    else
                    {
                        vy = -Math.Abs(vy);
                    }
            }


        }
        public override void Draw()
        {
            base.Draw();
        }

    }
}