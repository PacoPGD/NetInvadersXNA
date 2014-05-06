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
    /// Clase general de todos los disparos de los jugadores
    /// </summary>
    public abstract class disparo : Actor
    {
        //No tenemos nada especial, solo el numero del jugador que lo disparo y el daño que realiza
        //Lo de bala normal nos indica si esta a true que tiene que desaparecer al impactar con algun enemigo
        public int jugadorN;
        public int daño;
        public Boolean balaNormal = true;
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