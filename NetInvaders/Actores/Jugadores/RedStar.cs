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
    /// Clase con la nave de Redstar, es la unica que recibira comentarios ya que las demas son iguales con alguna que otra diferencia menor
    /// </summary>
    public class RedStar : eljugador
    {

        public RedStar(ContentManager contents, int jugador)
        {

            content = contents;
            nJugador = jugador;

            placaJugador = new PlacaJugador(content, jugador); //generamos placa de datos
            Fase.cosas.Add(placaJugador);

            //generamos estadisticas de la nave
            this.PLAYER_SPEED = 5 * constanteSpeed;
            this.MAX_SHIELDS = 7 * constanteShield;
            this.clusterBombs = 0 * constanteBomb;
            this.numero = 1;
            shields = MAX_SHIELDS;
            MAX_MANA = 100;
            mana = 100;

            //cargamos las imagenes de la nave concreta
            imagenAnimada[0] = content.Load<Texture2D>("actores/personajesnaves/RedStar/nave");
            imagenizq = content.Load<Texture2D>("actores/personajesnaves/RedStar/naveIzq");
            imagender = content.Load<Texture2D>("actores/personajesnaves/RedStar/naveDer");

            //la situamos inicialmente en un punto de pantalla u otro dependiendo del jugador que la controle
            if (jugador == 1)
            {
                x = (int)Game1.width / 2 - 100;
            }
            else
            {
                x = (int)Game1.width / 2 + 100;
            }
            y = 500;
         



            inicializa();

        }

        //accion de disparo, cada nave dispara un objeto de bala diferente.
        public override void disparar()
        {
            if (tiempodisparo == 10)
            {
                disparo = new balared(content,x+15,y-this.width+15,nJugador);
                Fase.balasJ.Add(disparo);
                tiempodisparo = 0;
            }
        }
        //rincon reservado para el ataque furia de esta nave
        public override void ataqueFuria()
        {
            if (tiempodisparo == 10)
            {
                if (fury >= 100)
                {
                    fury = 0;
                    disparo = new especialRed(content, x + 3, y + 7 - this.width / 2, nJugador);
                    Fase.balasJ.Add(disparo);
                    tiempodisparo = 0;
                }
            }
        }

        //metodos update y draw recogidos de la clase eljugador
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