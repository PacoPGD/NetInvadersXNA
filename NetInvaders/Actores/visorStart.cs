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
    /// Esta clase es el start que sale al principio del juego, podria haberla hecho como clase decorado, pero la realicé aparte finalmente
    /// </summary>
    public class visorStart : Actor
    {

        public visorStart(ContentManager contents)
        {
            content = contents;

            imagenAnimada[0] = content.Load<Texture2D>("flag/Start");
            width = 800;
            height = 102;
            x = 240;
            y = 264;
        }


        public override void Update() 
        {

                if (tiempoVida == 100)
                {
                    vy = 3;
                }

                base.Update();
            
        }

        public override void Draw()
        {

                base.Draw();
            
        }

    }
}