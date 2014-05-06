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
    /// Es la primera mision del juego, esta es mas compleja que los survival ya que conforme avanzas hay nuevos eventos
    /// </summary>
    public class Mission2 : Fase
    {
        public Random r;

        public Enemigo enemigo;
        public Enemigo jefe;
        //La carga de contenido se hace siempre de la misma manera
        public Mission2(ContentManager contents, int jugadore, int nave1, int nave2)
        {
            eliminaTodo();
            Fase.momentoActual = 0;
            nJugadores = jugadore;
            content = contents;
            fondo = content.Load<Texture2D>("fondos/luna");
            cancion = content.Load<Song>("musica/Livin On The Mystic Side");
            cancionFinal = content.Load<Song>("musica/Come Back Time");
            velocidadFon = 10;
            if (nJugadores == 2)
            {
                inicializaJugador(2, nave2);
            }

            inicializaJugador(1, nave1);

            start = new visorStart(content);
            jefe = new Barco(content, 250, -250, 0, 2);





        }

        public override void Update()
        {
            r = new Random(DateTime.Now.Millisecond + momentoActual);

            //Con el momento actual controlo el tiempo que ha pasado desde que empieza la fase, asi puedo hacer que pase cada cosa
            //en el momento adecuado

            if (finalizado == 0)
            {
                if (momentoActual == 100)
                {
                    traseras.Add(start);
                }

                if (momentoActual == 25)
                {
                    charla = new Charla(content, "Pdamon", "Bien, destruid a ese programador y acabemos con esto");
                    cosas.Add(charla);
                }

                if (momentoActual == 400)
                {
                    charla = new Charla(content, "Joaquin", "Quien osa interferir en mis dominios... ahora notareis la muerte lenta de asp");
                    cosas.Add(charla);
                }

                if (momentoActual == 400)
                {
                    for(int i=0;i<18;i++){
                    enemigo = new Bicicleta(content, (i+1)*60, -50, 4,8);
                    enemigos.Add(enemigo);
                    }
                }

                if (momentoActual == 450)
                {
                        enemigo = new NaveGenerica(content, -90, 40, 5, 0, 1);
                        enemigos.Add(enemigo);
                        enemigo = new Defensor(content,-100,70,5,0,1);
                        enemigos.Add(enemigo);
                }

                if (momentoActual == 600)
                {
                    charla = new Charla(content, "Joaquin", "Mas... mas bicicletas");
                    cosas.Add(charla);
                }

                if (momentoActual == 700)
                {
                    for (int i = 0; i < 14; i++)
                    {
                        enemigo = new Bicicleta(content,200+ (i + 1) * 60, -50, 4, 8);
                        enemigos.Add(enemigo);
                    }
                }


                if (momentoActual == 800)
                {
                    for (int i = 0; i < 14; i++)
                    {
                        enemigo = new Bicicleta(content, 200 + (i + 1) * 60, -50, 4, 8);
                        enemigos.Add(enemigo);
                    }
                }


                if (momentoActual == 900)
                {
                    for (int i = 0; i < 4; i++)
                    {
                        enemigo = new Banzai(content, (i + 1) * 200, -50, 4, 8);
                        enemigos.Add(enemigo);
                    }
                }


                if (momentoActual == 1300)
                {
                    enemigo = new NaveGenerica(content, -90, 40, 5, 0, 1);
                    enemigos.Add(enemigo);
                    enemigo = new Defensor(content, -100, 70, 5, 0, 1);
                    enemigos.Add(enemigo);
                }


                if (momentoActual == 1350)
                {
                    enemigo = new NaveGenerica(content, -90, 40, 5, 0, 1);
                    enemigos.Add(enemigo);
                    enemigo = new Defensor(content, -100, 70, 5, 0, 1);
                    enemigos.Add(enemigo);
                }

                if (momentoActual == 1400)
                {
                    enemigo = new NaveGenerica(content, -90, 40, 5, 0, 1);
                    enemigos.Add(enemigo);
                    enemigo = new Defensor(content, -100, 70, 5, 0, 1);
                    enemigos.Add(enemigo);
                }

                if (momentoActual == 1450)
                {
                    enemigo = new NaveGenerica(content, -90, 40, 5, 0, 1);
                    enemigos.Add(enemigo);
                    enemigo = new Defensor(content, -100, 70, 5, 0, 1);
                    enemigos.Add(enemigo);
                }

                if (momentoActual >= 1800 && momentoActual <= 2200 && momentoActual%50==0 )
                {
                    for (int i = 0; i < 10; i++)
                    {
                        enemigo = new Bicicleta(content, 200 + (i + 1) * 100, -50, 4, 8);
                        enemigos.Add(enemigo);
                    }
                }

                if (momentoActual == 2500)
                {
                    charla = new Charla(content, "Joaquin", "Rendios de una vez malditos");
                    cosas.Add(charla);
                }

                if (momentoActual == 2700)
                {
                    for (int i = 0; i < 10; i++)
                    {
                        enemigo = new Defensor(content, i * 200, -50, 0, 10, i);
                        enemigos.Add(enemigo);
                    }
                }


            }
            if (finalizado == 1)
            {

                if (momentoActual == 100)
                {
                    enemigos.Clear();
                    decorado = new decorado(content, -300, 200, 5, 0, "flag/Final");
                    traseras.Add(decorado);
                }
                if (momentoActual == 200)
                {
                    //Fin de partida, guardado de datos etc
                }

                if (momentoActual == 600)
                {
                    MediaPlayer.Play(menu.menuSong);
                    menu.estadoMenu = 0;
                    Game1.estadodeljuego = Game1.MiEstado.Menu;
                }
            }



            if (jugadores.Count == 0)
            {
                cosas.Remove(charla);
                Game1.mission = new GameOver(content);
                MediaPlayer.Play(Game1.mission.cancion);
                Game1.estadodeljuego = Game1.MiEstado.Mission;
            }

            //Hago el update de la clase padre
            base.Update();


        }

        //El draw se recoge de la clase padre ya que la metodogia de pintado es siempre la misma en todas las misiones
        public override void Draw()
        {
            base.Draw();
         
        }
    }
}