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
    /// Clase con la nave enemiga generica, es la unica que recibira la descripcion detallada, los demas enemigos solo tienen cambios puntuales
    /// </summary>
    public class Defensor : Enemigo
    {

        public Defensor(ContentManager contents, int x, int y, int vx, int vy, int nEnemigo)
        {
            content = contents;
            imagenAnimada[0] = content.Load<Texture2D>("actores/enemigosnaves/defensor");
            //ancho y alto del enemigo

            this.x = x;
            this.y = y;
            this.vx = vx;
            this.vy = vy;
            numEnemigo = nEnemigo;
            this.shields = 100;//su vida
            this.puntosAObtener = 5000;//puntos que otorga
            this.furiaAObtener = 10;//furia que otorga

            inicializa();
        }





        //Los updates de los enemigos son los que contienen su comportamiento una vez estan en juego
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