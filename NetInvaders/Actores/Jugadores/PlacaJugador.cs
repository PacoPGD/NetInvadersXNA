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
    /// Esta es la clase que pinta el estado de todas las naves, su vida, su escudo, sus puntos...
    /// La clase no tiene mucha historia, excepto en como hago el draw
    /// </summary>
    public class PlacaJugador : Actor
    {
        SpriteFont fuente;
        public int nJugador;
        public int scoreEsc;
        public int escudoEsc;
        public int maximoEsc;
        public int bombasEsc;
        public int manaEsc;
        public int furiaEsc;


        public Texture2D vida;
        public Texture2D barra;


        public PlacaJugador(ContentManager contents,int jugadorNum)
        {
            content = contents;
            nJugador = jugadorNum;
            fuente = content.Load<SpriteFont>("fuente1");
            imagenAnimada[0] = content.Load<Texture2D>("flag/placa");
            vida = content.Load<Texture2D>("vida");
            barra = content.Load<Texture2D>("barra");
            width = (int)Game1.width-100;
            height = 70;
            x = 0;
            if (nJugador == 1)
            {
                y = 600;
            }
            else
            {
                y = 650;
            }

            rectangulo = new Rectangle(x, y, width, height);
        }


        public override void Update() 
        {
            if (furiaEsc > 100)
            {
                furiaEsc = 100;
            }
                base.Update();
                
        }

        //En el draw de la placa me encargo de pintar la puntuacion y las bombas con caracteres y el escudo y la vida con barras
        //que son una imagen de una barrita puesta muchas veces "161", ademas dependiendo de si el jugador es el uno o el dos
        //tengo que pintar la placa a una altura diferente
        public override void Draw()
        {
                base.Draw();

                    Game1.spriteBatch.DrawString(fuente, ""+scoreEsc, new Vector2(x+355,y+15), Color.Red);
                    Game1.spriteBatch.DrawString(fuente, "" + bombasEsc, new Vector2(x+1040,y+15), Color.Red);
                    Game1.spriteBatch.DrawString(fuente, "" + furiaEsc, new Vector2(x + 1040, y -20), Color.Red);
                
                int VidaUno = (int)((escudoEsc / (float)maximoEsc) * 161);
                for (int i = 0; i < VidaUno; i++)
                {
                        Game1.spriteBatch.Draw(vida, new Rectangle(x+634+i, y+31, vida.Width,vida.Height), Color.White);
                }
                int ManaUno = (int)((manaEsc / (float)100) * 161);
                for (int i = 0; i < ManaUno; i++)
                {
                    Game1.spriteBatch.Draw(vida, new Rectangle(x + 634 + i, y + 41, vida.Width, vida.Height), Color.Blue);
                }

                for (int i = 0; i < furiaEsc*3.6; i++)
                {
                    Game1.spriteBatch.Draw(barra, new Rectangle(x+160, y+30,22,14), null, Color.Red, MathHelper.ToRadians(i),
                    new Vector2(0,0), SpriteEffects.None, 0f);
                }
 
        }
        
        //Con esto la placa obtiene los datos del jugador
        public void getDatos(int respuesta,int escudo,int maximo, int bombas,int mana,int furia)
        {
            scoreEsc = respuesta;
            escudoEsc = escudo;
            maximoEsc = maximo;
            bombasEsc = bombas;
            manaEsc = mana;
            furiaEsc = furia;
        }
    }
}