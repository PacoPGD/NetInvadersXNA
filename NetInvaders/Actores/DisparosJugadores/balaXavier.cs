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
    /// Bala de la nave BlueFang
    /// </summary>
    public class balaXavier : disparo
    {
        public balaXavier(ContentManager contents, int x, int y, int jugadorNumero)
        {

            content = contents;
            jugadorN = jugadorNumero;

            imagenAnimada = new Texture2D[5];
            imagenAnimada[0] = content.Load<Texture2D>("disparos/buenos/disparoXavier/Bala1");
            imagenAnimada[1] = content.Load<Texture2D>("disparos/buenos/disparoXavier/Bala2");
            imagenAnimada[2] = content.Load<Texture2D>("disparos/buenos/disparoXavier/Bala3");
            imagenAnimada[3] = content.Load<Texture2D>("disparos/buenos/disparoXavier/Bala4");
            imagenAnimada[4] = content.Load<Texture2D>("disparos/buenos/disparoXavier/Bala5");

            this.x = x;
            this.y = y;
            daño = 5;
            vy = -15;
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