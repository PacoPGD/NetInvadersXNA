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
    public class Bicicleta : Enemigo
    {

        public Bicicleta(ContentManager contents, int x, int y, int vx, int vy)
        {
            content = contents;
            imagenAnimada[0] = content.Load<Texture2D>("actores/enemigosnaves/joaquin/centro");
            imagenizq = content.Load<Texture2D>("actores/enemigosnaves/joaquin/izquierda");
            imagender = content.Load<Texture2D>("actores/enemigosnaves/joaquin/derecha");
    
            this.x = x;
            this.y = y;
            this.vx = vx;
            this.vy = vy;


            this.shields = 10;
            this.puntosAObtener = 3500;
            this.furiaAObtener = 5;
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
                    else{
                        if (x == apuntado.x)
                        {
                            vx = 0;
                        }
                        else
                        {
                            vx = -Math.Abs(vx);
                        }
                    }
            }


        }
        public override void Draw()
        {
            if (vx == 0)
            {
                Game1.spriteBatch.Draw(imagenAnimada[0], rectangulo, Color.White);
            }
            if (vx > 0)
            {
                Game1.spriteBatch.Draw(imagender, rectangulo, Color.White);
            }
            if (vx < 0)
            {
                Game1.spriteBatch.Draw(imagenizq, rectangulo, Color.White);
            }
        }

    }
}