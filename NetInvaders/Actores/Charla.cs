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
//using Microsoft.Xna.Framework.Net;
using Microsoft.Xna.Framework.Storage;


namespace NetInvaders
{
    /// <summary>
    /// Esta clase es la que pinta la chapa de charla con la que hago que los personajes hablen en las secuencias,
    /// simplemente tengo varias string "texto a pintar" y otro para ir añadiendo letras y asi no salgan todas a la vez
    /// </summary>
    public class Charla : Actor
    {
        private int caracteresPorLinea = 80;

        Random r = new Random();
        public String escribe;
        public String []mostrando = new String[4];
        public String[] prueba = new String[4];
        public int caracter = 0;
        public int tiempoRetardo = 2; //tiempo entre linea y linea
        public int interlineado = 15; //espacio entre linea y linea
        public int letras = 0;
        public static SpriteFont fuente;
        public Texture2D foto; //imagen del personaje que habla
        public String nombreCara; //nombre del personaje que habla en ese momento

        public int vozveces=2;
        SoundEffect []voz = new SoundEffect[5]; //la voz son 5 sonidos cortos, la emision de estos sonidos a mucha velocidad son los que simulan el habla

        int tiempoVisual = 50;


        public Charla(ContentManager contents,String cara,String Texto)
        {
            escribe = Texto;
            content = contents;
            imagenAnimada[0] = content.Load<Texture2D>("cajaCharla");
            fuente = content.Load<SpriteFont>("charlafuente");
            foto = content.Load<Texture2D>("caras/"+cara);
            nombreCara = cara;

            for (int i = 0; i < 5; i++)
            {
                voz[i] = content.Load<SoundEffect>("voces/" + cara + "" + (i + 1));
            }

            for (int i = 0; i < 4; i++)
            {
                mostrando[i] = "";
            }
            width = (int)Game1.width - 40;
            height = 140;
            x = 30;
            y = 580;

        }

        //El update en este caso es el que va pintando letra por letra
        public override void Update()
        {
            if (tiempoVida % tiempoRetardo == 0)
            {
                if (caracter < escribe.Length)
                {

                    for (int i = 0; i < 4; i++)
                    {
                        if (letras >= caracteresPorLinea * i && letras < caracteresPorLinea * (i + 1))
                        {
                            mostrando[i] = mostrando[i] + escribe[caracter];
                            if (vozveces == 2)
                            {
                                diLetra(escribe[caracter]);
                                vozveces = 0;
                            }
                            else
                            {
                                vozveces++;
                            }
                        }
                    }


                    letras++;

                }
                else
                {
                    tiempoVisual--;
                }
                caracter++;
            }

            if (tiempoVida % 4 == 0)
            {
                prueba[0] = get01Aleatorios(15);
                prueba[1] = get01Aleatorios(15);
                prueba[2] = get01Aleatorios(15);
                prueba[3] = get01Aleatorios(15);
            }

            if (tiempoVisual == 0)
            {
                paraBorrar = true;
            }
          
            base.Update();

        }

       //Dependiendo de la linea que tengamos qeu pintar la pondra en una u otra posicion ademas de si el jugador es el 1 o el 2
        public override void Draw()
        {
            base.Draw();

            Game1.spriteBatch.Draw(foto, new Rectangle(x+70,y+18,110,114), Color.White);
            Game1.spriteBatch.DrawString(fuente, nombreCara, new Vector2(x + 240, y + 17), Color.White);

            for (int i = 0; i < 4; i++)
            {
                Game1.spriteBatch.DrawString(fuente, mostrando[i], new Vector2(x + 205, y + 50 + interlineado * i), Color.White);
                Game1.spriteBatch.DrawString(fuente, prueba[i], new Vector2(x + 1025, y + 60 + interlineado * i), Color.White);
            }

        }

        //Funcion que devuelve un 1 o un 0 aleatoriamente
        public String get01Aleatorios(int numeroCaracteres)
        {
            String cadena = "";

            for (int i = 0; i < numeroCaracteres; i++)
            {
             
                if (r.NextDouble() < 0.5)
                {
                    cadena = cadena + "1";
                }
                else
                {
                    cadena = cadena + "0";
                }
            }
            return cadena;
        }

        //Funcion que emite unos de los 5 sonidos aleatorios dependiendo de la letra que está siendo impresa
        public void diLetra(char c)
        {
            if ((c >= 'a' && c <= 'z' || (c >= 0 || c <= 9) || (c >= 'A' && c <= 'Z')))
            { //if( c!=' ')
                voz[(int)(c % 5)].Play();
            }
        }
    }
}