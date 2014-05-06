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
    /// De esta clase heredan todos los actores que salen en el juego, enemigos, balas, nuestra nave...
    /// </summary>

    public abstract class Actor 
    {
        public int tiempoVida=0;
        public int x;//Posicion en el eje X de pantalla
        public int y;//Posicion en el eje Y de pantalla
        //Velocidades que puede tener en el eje X e Y
        public int vx=0;
        public int vy=0;

        public Texture2D imagender;//Imagen mientras gira a la derecha
        public Texture2D imagenizq;//Imagen mientras gira a la izquierda
        public Texture2D []imagenAnimada = new Texture2D[1];//Animación mientras la nave no se mueve
        public int imagenActual = 0;
        public int momenAnimacion=-1;
       //Ancho y alto de nuestra imagen
        public int width;
        public int height;
        public Game1 juego;
        public ContentManager content;

        public Boolean paraBorrar = false;

        public Rectangle rectangulo;//Rectangulo que ocupa en pantalla nuestra imagen
        public Color[] hitColor;//Color de cada pixel para el calculo de choques
        public Matrix personTransform;


        public Actor() { }
        public Actor(ContentManager contents)
        {
        content=contents;

        }

        public virtual void inicializa()
        {
            hitColor = new Color[imagenAnimada[0].Width * imagenAnimada[0].Height];
            imagenAnimada[0].GetData(hitColor);
            width = imagenAnimada[0].Width;
            height = imagenAnimada[0].Height;
        }

        //El metodo update simplemente aplica la velocidad a la posicion actual y hace que si los cuerpos se van muy lejos de pantalla
        //se borren para no ocupar memoria tontamente
        public virtual void Update()
        {
                x = x + vx;
                y = y + vy;
                tiempoVida++;
            
                if (x < -1000 || x > Game1.width + 1000)
                {
                    paraBorrar = true;
                }
                if (y < -1000 || y > Game1.height + 1000)
                {
                    paraBorrar = true;
                }
                rectangulo = new Rectangle(x, y, width, height);
             
                personTransform= Matrix.CreateTranslation(new Vector3(new Vector2(x,y), 0.0f));
        }

        public virtual void Draw()
        {
                
                Game1.spriteBatch.Draw(imagenAnimada[imagenActual], rectangulo, Color.White);
        }

    }
}