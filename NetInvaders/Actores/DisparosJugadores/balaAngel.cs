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
    /// Bala de la nave SuperSonic
    /// </summary>
    public class balaAngel : disparo
    {
        public balaAngel(ContentManager contents, int x, int y, int jugadorNumero)
        {
            content = contents;
            jugadorN = jugadorNumero;
            imagenAnimada[0] = content.Load<Texture2D>("disparos/buenos/disparoSonic");
   
            this.x = x;
            this.y = y;
            daño = 5;
            vy = -15;
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