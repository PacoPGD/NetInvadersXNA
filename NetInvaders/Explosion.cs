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
    /// Clase simple que genera una explosion en el lugar indicado y con un tamaño determinado
    /// </summary>
    public class Explosion : Actor
    {
        public Explosion(ContentManager content,int x,int y,int ancho, int alto) 
        { 
            width=ancho;
            height=alto;
            this.x = x;
            this.y = y;
            vy = Fase.velocidadFon;
            imagenAnimada = new Texture2D[6];

            imagenAnimada[0] = content.Load<Texture2D>("Efectos/explosion1");
            imagenAnimada[1] = content.Load<Texture2D>("Efectos/explosion2");
            imagenAnimada[2] = content.Load<Texture2D>("Efectos/explosion3");
            imagenAnimada[3] = content.Load<Texture2D>("Efectos/explosion4");
            imagenAnimada[4] = content.Load<Texture2D>("Efectos/explosion5");
            imagenAnimada[5] = content.Load<Texture2D>("Efectos/explosion6");
            inicializa();
        
        }
        public override void Update()
        {
            rectangulo = new Rectangle(x, y, width, height);
            if (tiempoVida % 10 == 0)
            {
                momenAnimacion++;
                if (momenAnimacion == 6)
                {
                    momenAnimacion = 0;
                }
            }
            if (tiempoVida == 59)
            {
                paraBorrar = true;
            }
            base.Update();
        }
        public override void Draw()
        {
            Game1.spriteBatch.Draw(imagenAnimada[momenAnimacion], rectangulo, Color.White);
        }
    }
}