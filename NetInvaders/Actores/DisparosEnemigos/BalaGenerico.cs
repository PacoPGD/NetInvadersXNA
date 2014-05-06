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
    public class balaGenerico : disparoEnemigo
    {
        public balaGenerico(ContentManager contents, int x, int y)
        {
            content = contents;
            daño = 10; //Daño del proyectil
            imagenAnimada[0] = content.Load<Texture2D>("disparos/malos/Bala1"); //Imagen para el proyectil
    
            this.x = x;
            this.y = y;
            vy = 10;
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