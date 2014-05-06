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
    /// Clase del escudo anti proyectiles
    /// </summary>
    public class Escudo : Actor
    {
        int numJugador;
        int vida = 1;

        //El constructor es como en todos los actores, le asigno una imagen o imagenes y tambien el numero de jugador
        //para saber en que posicion aparecer
        public Escudo(ContentManager contents, int nJugador)
        {
            content = contents;

            imagenAnimada = new Texture2D[5];


            imagenAnimada[0] = content.Load<Texture2D>("especiales/burbuja/1");
            imagenAnimada[1] = content.Load<Texture2D>("especiales/burbuja/2");
            imagenAnimada[2] = content.Load<Texture2D>("especiales/burbuja/3");
            imagenAnimada[3] = content.Load<Texture2D>("especiales/burbuja/4");
            imagenAnimada[4] = content.Load<Texture2D>("especiales/burbuja/5");
          
            numJugador = nJugador;


            inicializa();
        }

        //Lo unico que hago es cambiar el momento de animacion poco a poco para que el escudo no sea una imagen estatica
        public override void Update()
        {
            if (tiempoVida % 5 == 0)
            {
                momenAnimacion++;
                if (momenAnimacion == 5)
                {
                    momenAnimacion = 0;
                }
            }

            if (tiempoVida >= vida)
            {
                paraBorrar = true;
            }
            if (numJugador == 1)
            {
                x = Fase.jugador1.x - width/3;
                y = Fase.jugador1.y - height/4;
            }
            else
            {
                x = Fase.jugador2.x - width/3;
                y = Fase.jugador2.y - height/4;
            }


            base.Update();
        }
        
        //Pinto el momento de la animación adecuado
        public override void Draw()
        {
            Game1.spriteBatch.Draw(imagenAnimada[momenAnimacion], rectangulo, Color.White);
  
        }


    }
}