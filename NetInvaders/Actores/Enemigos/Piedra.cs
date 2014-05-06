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
    /// Clase que genera al enemigo piedra
    /// </summary>
    public class Piedra : Enemigo
    {

        public Piedra(ContentManager contents, int x, int y, int vx, int vy, int nEnemigo)
        {
            content = contents;

            imagenAnimada = new Texture2D[5];
            imagenAnimada[0] = content.Load<Texture2D>("actores/enemigosnaves/piedra/1");
            imagenAnimada[1] = content.Load<Texture2D>("actores/enemigosnaves/piedra/2");
            imagenAnimada[2] = content.Load<Texture2D>("actores/enemigosnaves/piedra/3");
            imagenAnimada[3] = content.Load<Texture2D>("actores/enemigosnaves/piedra/4");
            imagenAnimada[4] = content.Load<Texture2D>("actores/enemigosnaves/piedra/5");
      
  
            this.x = x;
            this.y = y;
            this.vx = vx;
            this.vy = vy;
            numEnemigo = nEnemigo;
            this.shields = 5;
            this.puntosAObtener = 100;
            this.furiaAObtener = 1;
            inicializa();
        }


        public override void Update()
        {
            if (tiempoVida % 5 == 0)
            {
                momenAnimacion++;
                if (momenAnimacion == 5)
                {
                    momenAnimacion = 0;
                }
            }
            base.Update();

        }
        public override void Draw()
        {
            Game1.spriteBatch.Draw(imagenAnimada[momenAnimacion], rectangulo, Color.White);
        }

    }
}