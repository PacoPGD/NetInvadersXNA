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
    /// De esta clase heredan todos los proyectiles enemigos
    /// </summary>
    public abstract class disparoEnemigo : Actor
    {

        public int daño;
        public Boolean escudoBorra = true;
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