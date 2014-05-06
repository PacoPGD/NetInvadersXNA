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
    /// Este es el proyectil de las balas genericas
    /// </summary>
    public class balaBarco : disparoEnemigo
    {
        public balaBarco(ContentManager contents, int x, int y, int velox)
        {
            content = contents;
            daño = 10; //Daño del proyectil
            imagenAnimada[0] = content.Load<Texture2D>("disparos/malos/balaBarco1"); //Imagen para el proyectil

            this.x = x;
            this.y = y;
            vx = velox;
            vy = 10- Math.Abs(vx);
            inicializa();
        }

        public override void Update()
        {
            base.Update();
        }

        public override void Draw()
        {
            base.Draw();
        }

    }
}