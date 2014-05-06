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
    /// Clase generica para incluir cualquier imagen que no interacciona con el entorno
    /// </summary>
    public class decorado : Actor
    {
        public decorado(ContentManager contents, int x, int y, int vx, int vy,String ruta)
        {
            content = contents;
            imagenAnimada[0] = content.Load<Texture2D>(ruta);
            width = imagenAnimada[0].Width;
            height = imagenAnimada[0].Height;
            this.x = x;
            this.y = y;
            this.vx = vx;
            this.vy = vy;
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