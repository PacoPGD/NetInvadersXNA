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
    /// Este es el ataque especial de la white galeon
    /// </summary>
    public class especialCless : disparo
    {
        public especialCless(ContentManager contents, int x, int y, int jugadorNumero)
        {

            balaNormal = false;//Asi puede atravesar los enemigos
            content = contents;
            jugadorN = jugadorNumero;
            imagenAnimada[0] = content.Load<Texture2D>("especiales/Cless/5");

            this.x = x-90;
            this.y = y-750;
            daño = 40;
            vy = 0;
            inicializa();
        }

        //permanece un tiempo en pantalla quitando daño a las naves que se cruzan en su camino y al final desaparece
        public override void Update()
        {
            if (tiempoVida == 10)
            {
                paraBorrar = true;
            }
            base.Update();
        }

        public override void Draw()
        {
            base.Draw();
        }

    }
}