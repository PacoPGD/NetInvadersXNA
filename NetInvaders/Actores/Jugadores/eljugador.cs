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
    /// Clase referida a la nave que controlamos "aunque la nave es una clase que hereda de esta y es donde se guardan todas las diferenciaciones"
    /// </summary>
    /// 
    public abstract class eljugador : Actor
    {
        GamePadState state;
        public Explosion explo;

        //Constantes de velocidad, escudos y bombas que se usan como multiplicadores para los atributos principales de las naves
        public float constanteSpeed = 2;
        public int constanteShield = 100;
        public int constanteBomb = 2;

        public PlacaJugador placaJugador; //Placa que pinta el estado de las naves

        public disparo disparo; //objeto que crea la nave al hacer la accion de disparar
        public int score;//puntos
        public int shields;//vida
        public int mana;//escudoantibalas
        public int MAX_MANA;//escudoantibalasmaximo
        public int precision;//precision de disparo
        public int nJugador;//numero de jugador
        public int tiempoBomba = 0; //tiempo para lanzar otra bomba
        public int tiempodisparo = 0; //tiempo para lanzar otro disparo
        public int vivo = 1; //indica si esta vivo o muerto
        public int fury = 100; //cantidad de furia acumulada
        public int numero; //numero identificativo de la nave, la roja es la 1, la blanca la 2...
        public float PLAYER_SPEED; //velocidad de la nave
        public int MAX_SHIELDS;// vida maxima de la nave
        public int clusterBombs;// bombas de la nave
        public int fuegoDisponible = 1;// indica si la nave puede disparar o tiene el fuego bloqueado
        public Boolean direccionActiva = true; //indica si la nave puede moverse o tiene la direccion bloqueada
        public int direccionInactivaTime = 0; //tiempo de direccion inactiva
        public int tiempoReesquivar; //tiempo para poder hacer una nueva barrida con LT o RT

        public eljugador() { }
        public eljugador(ContentManager contents,int jugador)
        {



        }


        public abstract void disparar(); //el disparo es un metodo abstracto ya que cada nave lo hace a su manera
        public abstract void ataqueFuria(); //idem con el ataque furia
        
        //si la vida pasan a ser 0 la nave es eliminada
        public override void Update()
        {
            base.Update();
            if (shields <= 0)
            {
                paraBorrar = true;
                explo = new Explosion(content, x, y, width, height);
                Fase.cosas.Add(explo);
            }

            placaJugador.getDatos(score,shields,MAX_SHIELDS,clusterBombs,mana,fury);

                //CONTROL XBOX O CONTROL PC
                //controlPC();
                controlXbox();
            //Penalizacion por movimiento
            if (vx != 0)
            {
                score--;
            }
            if (vy != 0)
            {
                score--;
            }

            //Limitacion de la nave para que no se pueda mover fuera de la pantalla
            if (x < 0)
                x = 0;
            if (x > Game1.width - width - 5)
                x = (int)(Game1.width - width - 5);
            if (y < 0)
                y = 0;
            if (y > Game1.height-height-120)
                y = (int)(Game1.height-height-120);

            //si se hace un disparo o se lanza una bomba hay que esperar un tiempo para volver a disparar
            if (tiempodisparo < 10) { tiempodisparo++; }
            if (tiempoBomba < 200) { tiempoBomba++; }
        }


        //Aqui se especifican los controles con el mando de xbox para los jugadores 1 o 2
        public void controlXbox() 
        {
            stadear();

                if (fuegoDisponible == 1)
                {
                    if (state.Buttons.Start == ButtonState.Pressed)
                    {
                        if (Game1.estadodeljuego == Game1.MiEstado.Mission)
                        {
                                Game1.estadodeljuego = Game1.MiEstado.Pausa;
                        }

                    }

                    if (state.Buttons.A == ButtonState.Pressed)
                    {
                        disparar();
                    }
                    if (state.Buttons.B == ButtonState.Pressed)
                    {
                        dispararBomba();
                    }

                    if (state.Buttons.X == ButtonState.Pressed)
                    {
                        if (mana > 0)
                        {
                            generaEscudo();
                            mana=mana-2;
                        }

                    }
                    else
                    {
                        if (mana < MAX_MANA)
                        {
                            mana++;
                        }
                    }

                    if (state.Buttons.Y == ButtonState.Pressed)
                    {
                
                            ataqueFuria();
                     
                        
                    }
                }
                if (direccionInactivaTime == 0)
                {
                    if (state.ThumbSticks.Left.Y != 0)
                    {
                        vy = (int)(-PLAYER_SPEED * state.ThumbSticks.Left.Y);
                    }
                    if (state.ThumbSticks.Left.Y == 0)
                    {
                        vy = 0;
                    }
                    if (state.ThumbSticks.Left.X != 0)
                    {
                        vx = (int)(PLAYER_SPEED * state.ThumbSticks.Left.X);
                    }

                    if (state.ThumbSticks.Left.X == 0)
                    {
                        vx = 0;
                    }

                    if (tiempoReesquivar == 0)
                    {
                        if (state.Triggers.Left > 0)
                        {
                            Esquivar(1);
                        }
                        if (state.Triggers.Right > 0)
                        {
                            Esquivar(2);
                        }
                    }
                    else
                    {
                        tiempoReesquivar--;
                    }

                }
                else
                {
                    if (direccionInactivaTime == 5)
                    {
                        vx = 0;
                    }
                    direccionInactivaTime--;
                }
            
           
            
        }

        public void controlPC()
        {
            stadear();

            if (fuegoDisponible == 1)
            {
                if (Keyboard.GetState().IsKeyDown(Keys.Enter))
                {
                    if (Game1.estadodeljuego == Game1.MiEstado.Mission)
                    {
                            Game1.estadodeljuego = Game1.MiEstado.Pausa;
                    }

                }

                if (Keyboard.GetState().IsKeyDown(Keys.Space))
                {
                    disparar();
                }
                if (Keyboard.GetState().IsKeyDown(Keys.B))
                {
                    dispararBomba();
                }

                if (Keyboard.GetState().IsKeyDown(Keys.N))
                {
                    if (mana > 0)
                    {
                        generaEscudo();
                        mana = mana - 2;
                    }

                }
                else
                {
                    if (mana < MAX_MANA)
                    {
                        mana++;
                    }
                }

                if (Keyboard.GetState().IsKeyDown(Keys.V))
                {

                    ataqueFuria();


                }
            }
            if (direccionInactivaTime == 0)
            {
                if (Keyboard.GetState().IsKeyDown(Keys.W))
                {
                    vy = (int)(-PLAYER_SPEED);
                }
                else{
                    if (Keyboard.GetState().IsKeyDown(Keys.S))
                    {
                        vy = (int)(PLAYER_SPEED);
                    }
                    else
                    {
                        vy = 0;
                    }
                }


                if (Keyboard.GetState().IsKeyDown(Keys.A))
                {
                    vx = (int)(-PLAYER_SPEED);
                }
                else
                {
                    if (Keyboard.GetState().IsKeyDown(Keys.D))
                    {
                        vx = (int)(PLAYER_SPEED);
                    }

                    else
                    {
                        vx = 0;
                    }
                }


                if (tiempoReesquivar == 0)
                {
                    if (Keyboard.GetState().IsKeyDown(Keys.M))
                    {
                        Esquivar(2);
                    }
                    if (Keyboard.GetState().IsKeyDown(Keys.C))
                    {
                        Esquivar(1);
                    }
                }
                else
                {
                    tiempoReesquivar--;
                }

            }
            else
            {
                if (direccionInactivaTime == 5)
                {
                    vx = 0;
                }
                direccionInactivaTime--;
            }



        }

        //todas las naves se pintan asi, si esta parada pintamos la imagen que va recta y si la velocidad en x es > o < de 0
        //pintamos la nave haciendo el giro correspondiente
        public override void Draw()
        {
            if (vx == 0)
            {
                Game1.spriteBatch.Draw(imagenAnimada[0], rectangulo, Color.White);
            }
            if (vx > 0)
            {
                Game1.spriteBatch.Draw(imagender, rectangulo, Color.White);
            }
            if (vx < 0)
            {
                Game1.spriteBatch.Draw(imagenizq, rectangulo, Color.White);
            }
        }

        //Crea el escudo protector de balas que es el mismo para todas las naves
        public void generaEscudo()
        {
            Escudo escudo = new Escudo(content,nJugador);
            Fase.escudos.Add(escudo);
        }
       
        //Accion para disparar una bomba, es igual para todas las naves
        public void dispararBomba()
        {
            if (tiempoBomba == 200)
            {
                if (clusterBombs > 0)
                {
                    clusterBombs--;
                    for(int i=0;i<8;i++){
                    disparo = new Bomba(content,x,y,nJugador,i+1);
                    Fase.balasJ.Add(disparo);
                    }

                    tiempoBomba = 0;
                }
            }
        }

        //accion de barrido/esquivar, es igual con todas las naves
        public void Esquivar(int direccion)
        {
            if (direccion == 1)
            {
                vx = -(int)(PLAYER_SPEED*1.5);
            }
            else
            {
                vx = (int)(PLAYER_SPEED*1.5);
            }
            direccionInactivaTime = 10;
            tiempoReesquivar = 15;
        }

        //para enviar la puntuacion a otras clases
        public int setScore()
        {
            return score;
        }

        public void stadear()
        {
            if (nJugador == 1)
            {
                state = GamePad.GetState(PlayerIndex.One);
            }
            if (nJugador == 2)
            {
                state = GamePad.GetState(PlayerIndex.Two);
            }
            if (nJugador == 3)
            {
                state = GamePad.GetState(PlayerIndex.Three);
            }
            if (nJugador == 4)
            {
                state = GamePad.GetState(PlayerIndex.Four);
            }
        }

    }


}