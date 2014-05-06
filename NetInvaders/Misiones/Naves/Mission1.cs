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
    public class Mission1 : Fase
    {
        public Random r;

        public Enemigo enemigo;
        public Enemigo jefe;
        //La carga de contenido se hace siempre de la misma manera
        public Mission1(ContentManager contents, int jugadore, int nave1, int nave2)
        {
            eliminaTodo();
            Fase.momentoActual = 0;
            nJugadores = jugadore;
            content = contents;
            fondo = content.Load<Texture2D>("fondos/cielo");
            cancion = content.Load<Song>("musica/Across the Blue Skys");
            cancionFinal = content.Load<Song>("musica/Come Back Time");
            velocidadFon = 2;
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
                    charla = new Charla(content, "Pdamon", "Acaba con todos esos programadores .net ¡tenemos que proteger nuestro planeta!");
                    cosas.Add(charla);
                }

                if (momentoActual == 200)
                {
                    switch (jugador1.numero)
                    {
                        case 1: charla = new Charla(content, "RedStar", "Por supuesto, no pienso dejar que los programadores .net vuelvan a hacer de las suyas"); break;
                        case 2: charla = new Charla(content, "Cless", "Entendido, acabaré con todos estos programadores, ¡será divertido!"); break;
                        case 3: charla = new Charla(content, "Xavier", "Claro, esto es cosa mia, me encargaré de ellos"); break;
                        case 4: charla = new Charla(content, "John", "Claro que si... esto esta tirado"); break;
                        case 5: charla = new Charla(content, "Angel", "Acabaré esta misión antes de que te des cuenta"); break;
                    }

                    cosas.Add(charla);
                }


                if (momentoActual > 250 && momentoActual < 500 && momentoActual % 50 == 0)
                {
                    enemigo = new NaveGenerica(content, 3, -50, r.Next(1, 10), 1, 0);
                    enemigos.Add(enemigo);
                    enemigo = new NaveGenerica(content, (int)Game1.width - 3, -50, r.Next(1, 10), 1, 1);
                    enemigos.Add(enemigo);
                }
                if (momentoActual >= 300 && momentoActual <= 500 && momentoActual % 100 == 0)
                {
                    enemigo = new Banzai(content, (int)Game1.width / 2, -50, 5, 5);
                    enemigos.Add(enemigo);
                }

                if (momentoActual > 800 && momentoActual < 1100 && momentoActual % 50 == 0)
                {
                    enemigo = new NaveGenerica(content, 3, -50, r.Next(1, 10), 1, 0);
                    enemigos.Add(enemigo);
                    enemigo = new NaveGenerica(content, (int)Game1.width - 3, -50, r.Next(1, 10), 1, 1);
                    enemigos.Add(enemigo);
                }
                if (momentoActual >= 800 && momentoActual <= 1100 && momentoActual % 100 == 0)
                {
                    enemigo = new TiradorPreciso(content, (int)Game1.width / 2, -50, 5, 5);
                    enemigos.Add(enemigo);
                }



                if (momentoActual > 1400 && momentoActual < 1700 && momentoActual % 50 == 0)
                {
                    enemigo = new NaveGenerica(content, 3, -50, r.Next(1, 10), 3, 0);
                    enemigos.Add(enemigo);
                    enemigo = new NaveGenerica(content, (int)Game1.width - 3, -50, r.Next(1, 10), 3, 1);
                    enemigos.Add(enemigo);
                }

                if (momentoActual >= 1400 && momentoActual <= 1700 && momentoActual % 100 == 0)
                {
                    enemigo = new Banzai(content, (int)Game1.width / 4, -50, 5, 5);
                    enemigos.Add(enemigo);
                    enemigo = new Banzai(content, 3 * (int)Game1.width / 4, -50, 5, 5);
                    enemigos.Add(enemigo);
                }

                if (momentoActual == 1900)
                {
                    charla = new Charla(content, "Pdamon", "¡Echate pa'lante! los programadores .net se aproximan por la retaguardia");
                    cosas.Add(charla);
                }


                if (momentoActual == 2100)
                {
                    switch (jugador1.numero)
                    {
                        case 1: charla = new Charla(content, "RedStar", "Gracias por el aviso"); break;
                        case 2: charla = new Charla(content, "Cless", "Vale, se veran sorprendidos por mi tecnica"); break;
                        case 3: charla = new Charla(content, "Xavier", "Si, se las verán conmigo..."); break;
                    }

                    cosas.Add(charla);
                }


                if (momentoActual >= 2100 && momentoActual <= 2400 && momentoActual % 100 == 0)
                {
                    enemigo = new Banzai(content, (int)Game1.width / 4, (int)Game1.height + 50, 5, 5);
                    enemigos.Add(enemigo);
                    enemigo = new Banzai(content, 3 * (int)Game1.width / 4, (int)Game1.height + 50, 5, 5);
                    enemigos.Add(enemigo);
                }

                if (momentoActual == 2700)
                {
                    charla = new Charla(content, "Salva", "Malditoh programadoreh java sus la vais a ver con el DJ number guan de la siti");
                    cosas.Add(charla);
                }

                if (momentoActual == 2900)
                {
                    switch (jugador1.numero)
                    {
                        case 2: charla = new Charla(content, "Cless", "¿Eres salvador? ¿que me estas contando?"); break;
                        case 3: charla = new Charla(content, "Xavier", "¿Eres tu?"); break;
                        case 5: charla = new Charla(content, "Angel", "Salvador... tu decidiste no seguir la senda de las redes de area local..."); break;
                    }

                    cosas.Add(charla);
                }

                if (momentoActual == 3100)
                {
                    charla = new Charla(content, "Salva", "Ahora tengo mi propia discoteca donde pinchar mis temas gracias a la programación .net");
                    cosas.Add(charla);
                }

                if (momentoActual == 3300)
                {
                    switch (jugador1.numero)
                    {
                        case 2: charla = new Charla(content, "Cless", "Eres un vendido"); break;
                        case 3: charla = new Charla(content, "Xavier", "Noooooooooooooooo"); break;
                        case 5: charla = new Charla(content, "Angel", "Entonces recibiras mi castigo..."); break;
                    }

                    cosas.Add(charla);
                }

                if (momentoActual >= 3500 && momentoActual <= 4000 && momentoActual % 50 == 0)
                {
                    enemigo = new NaveGenerica(content, 3, -50, r.Next(1, 10), 3, 0);
                    enemigos.Add(enemigo);
                    enemigo = new NaveGenerica(content, (int)Game1.width - 3, -50, r.Next(1, 10), 3, 1);
                    enemigos.Add(enemigo);
                    enemigo = new NaveGenerica(content, 3, -50, r.Next(1, 10), 3, 2);
                    enemigos.Add(enemigo);
                    enemigo = new NaveGenerica(content, (int)Game1.width - 3, -50, r.Next(1, 10), 3, 3);
                    enemigos.Add(enemigo);
                    enemigo = new NaveGenerica(content, 3, -50, r.Next(1, 10), 3, 4);
                    enemigos.Add(enemigo);
                    enemigo = new NaveGenerica(content, (int)Game1.width - 3, -50, r.Next(1, 10), 3, 5);
                    enemigos.Add(enemigo);
                }

                if (momentoActual >= 3500 && momentoActual <= 4000 && momentoActual % 100 == 0)
                {
                    enemigo = new Banzai(content, (int)Game1.width / 4, -50, 5, 5);
                    enemigos.Add(enemigo);
                    enemigo = new Banzai(content, 3 * (int)Game1.width / 4, -50, 5, 5);
                    enemigos.Add(enemigo);
                }


                if (momentoActual == 4400)
                {
                    switch (jugador1.numero)
                    {
                        case 1: charla = new Charla(content, "RedStar", "Vaya, si que están desesperados..."); break;
                        case 2: charla = new Charla(content, "Cless", "Uff, por un momento pensé que la palmaba, ha sido muy hardcore"); break;
                        case 4: charla = new Charla(content, "John", "!!!!!!!!!!!!"); break;
                        case 7: charla = new Charla(content, "Adam", "AAAAAiiiiaiaiaiaiaiaaaaaaa"); break;
                    }

                    cosas.Add(charla);
                }




                if (momentoActual >= 4600 && momentoActual <= 5000 && momentoActual % 100 == 0)
                {
                    enemigo = new Banzai(content, (int)Game1.width / 4, -50, 5, 5);
                    enemigos.Add(enemigo);
                    enemigo = new Banzai(content, 3 * (int)Game1.width / 4, -50, 5, 5);
                    enemigos.Add(enemigo);
                }


                if (momentoActual == 5100)
                {
                    MediaPlayer.Stop();
                }

                if (momentoActual == 5200)
                {
                    MediaPlayer.Play(Game1.mission.cancionFinal);
                }

                if (momentoActual == 5500)
                {
                    enemigos.Add(jefe);
                }

                if (momentoActual == 5625)
                {
                    jefe.vy = 0;
                    jefe.vx = 5;
                }

                if (momentoActual >= 5625 && momentoActual % 200 == 0)
                {
                    enemigo = new NaveGenerica(content, 3, -50, r.Next(1, 10), 1, 0, 0);
                    enemigos.Add(enemigo);
                    enemigo = new NaveGenerica(content, (int)Game1.width - 3, -50, r.Next(1, 10), 1, 1, 0);
                    enemigos.Add(enemigo);
                }

                if (jefe.paraBorrar == true)
                {
                    finalizado = 1;
                    momentoActual = 0;
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