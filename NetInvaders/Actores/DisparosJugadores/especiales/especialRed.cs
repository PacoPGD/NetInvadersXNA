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
    public class especialRed : disparo
    {
        public especialRed(ContentManager contents, int x, int y, int jugadorNumero)
        {

            balaNormal = false;//Asi puede atravesar los enemigos
            content = contents;
            jugadorN = jugadorNumero;
            imagenAnimada = new Texture2D[10];
            cargaContenido();

            this.x = x - 90;
            this.y = y - 0;
            daño = 6;
            vy = 0;
            inicializa();
        }

        //permanece un tiempo en pantalla quitando daño a las naves que se cruzan en su camino y al final desaparece
        public override void Update()
        {
            imagenActual = tiempoVida / 4;
            if (tiempoVida == 36)
            {
                paraBorrar = true;
            }
            base.Update();
        }

        public override void Draw()
        {
            base.Draw();
        }

        public void cargaContenido()
        {
            imagenAnimada[0] = content.Load<Texture2D>("especiales/Red/cruzRafaHD1");
            imagenAnimada[1] = content.Load<Texture2D>("especiales/Red/cruzRafaHD2");
            imagenAnimada[2] = content.Load<Texture2D>("especiales/Red/cruzRafaHD3");
            imagenAnimada[3] = content.Load<Texture2D>("especiales/Red/cruzRafaHD4");
            imagenAnimada[4] = content.Load<Texture2D>("especiales/Red/cruzRafaHD5");
            imagenAnimada[5] = content.Load<Texture2D>("especiales/Red/cruzRafaHD6");
            imagenAnimada[6] = content.Load<Texture2D>("especiales/Red/cruzRafaHD7");
            imagenAnimada[7] = content.Load<Texture2D>("especiales/Red/cruzRafaHD8");
            imagenAnimada[8] = content.Load<Texture2D>("especiales/Red/cruzRafaHD9");
            imagenAnimada[9] = content.Load<Texture2D>("especiales/Red/cruzRafaHD10");
        }
    }
}