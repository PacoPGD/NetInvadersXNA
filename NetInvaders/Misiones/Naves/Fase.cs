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
    /// Esta es la clase que genera una fase de acción
    /// </summary>
    public abstract class Fase
    {
        //clases de visor de jugador y jugadores inicializados
        public visorStart start;
        public static eljugador jugador1;
        public static eljugador jugador2;

        //Variables para la intensidad y duración de la vibración de los controles
        public static int tiempoVibra1 = 0;
        public static int tiempoVibra2 = 0;

        //Cancion que suena durante la fase
        public Song cancion;
        public Song cancionFinal;
        //DATOS DE FORMATO DE PANTALLA
        public SpriteFont fuente;
        public Texture2D fondo;
        public int posFon = 0;
        public static int nJugadores;
        public static int velocidadFon;

        //DATOS DE INFORMACION DE PARTIDA  
        public static int momentoActual = 0;

        // public static List<T> select = new List<Actor>();
        //Estos arraylist son los que tienen a los actores por grupos
        //asi cuando tenga que tratar sus impactos e interacciones lo podre hacer
        //de manera rapida
        public static List<Actor> jugadores = new List<Actor>();
        public static List<Actor> escudos = new List<Actor>();
        public static List<Actor> balasJ = new List<Actor>();
        public static List<Actor> enemigos = new List<Actor>();
        public static List<Actor> balasE = new List<Actor>();
        public static List<Actor> cosas = new List<Actor>();
        public static List<Actor> traseras = new List<Actor>();

        public ContentManager content;

        public Charla charla;
        public decorado decorado;




        //Banderas de finalizacion
        public int finalizado = 0;



        //Metodo de update de las fases
        public virtual void Update()
        {




            //comprobamos si hay colisiones con la función
            colisiones();

            //Si el tiempo de vibración es mayor de 0 es que el mando ha de vibrar
            // durante el tiempo estipulado
            if (tiempoVibra1 > 0)
            {
                GamePad.SetVibration(PlayerIndex.One, 1, 1);
                tiempoVibra1--;
            }
            else
            {
                GamePad.SetVibration(PlayerIndex.One, 0, 0);
            }
            if (tiempoVibra2 > 0)
            {
                GamePad.SetVibration(PlayerIndex.Two, 1, 1);
                tiempoVibra2--;
            }
            else
            {
                GamePad.SetVibration(PlayerIndex.Two, 0, 0);
            }

            //momentoActual determina el momento del nivel que nos encontramos siendo el
            //inicio del nivel el momento 0 y va avanzando poco a poco
            momentoActual++;

            //Movemos el fondo para que quede todo mejor animado
            posFon = posFon + velocidadFon;
            if (posFon >= (int)Game1.height)
            {
                posFon = 0;
            }

            //Todos los grupos de actores realizan su funcion update
            for (int i = 0; i < jugadores.Count; i++)
            {
                jugadores[i].Update();
            }
            for (int i = 0; i < enemigos.Count; i++)
            {
                enemigos[i].Update();
            }
            for (int i = 0; i < cosas.Count; i++)
            {
                cosas[i].Update();
            }
            for (int i = 0; i < balasJ.Count; i++)
            {
                balasJ[i].Update();
            }
            for (int i = 0; i < balasE.Count; i++)
            {
                balasE[i].Update();
            }
            for (int i = 0; i < traseras.Count; i++)
            {
                traseras[i].Update();
            }
            for (int i = 0; i < escudos.Count; i++)
            {
                escudos[i].Update();
            }

        }

        //Metodo que se encarga de pintar en las fases
        public virtual void Draw()
        {
            Game1.spriteBatch.Begin();
            //pintamos el fondo
            Game1.spriteBatch.Draw(fondo, new Rectangle(0, posFon, (int)Game1.width, (int)Game1.height), Color.White);
            Game1.spriteBatch.Draw(fondo, new Rectangle(0, posFon - (int)Game1.height, (int)Game1.width, (int)Game1.height), Color.White);

            //con esta funcion pinto a todos los actores en este orden
            comprobarList(traseras);
            comprobarList(enemigos);
            comprobarList(escudos);
            comprobarList(jugadores);
            comprobarList(balasJ);
            comprobarList(balasE);
            comprobarList(cosas);


            Game1.spriteBatch.End();
        }


        //Funcion a la que le pasas un arraylist de actores y los pinta
        public void comprobarList(List<Actor> lista)
        {
            int i;
            for (i = 0; i < lista.Count; i++)
            {
                lista[i].Draw();


                Actor mons = (Actor)lista[i];
                if (mons.paraBorrar == true)
                {
                    lista.RemoveAt(i);
                    i--;
                }
            }
        }

        //comprobacion de colisiones de todos los elementos del juego
        public void colisiones()
        {
            int i;
            int j;
            //COLISIONES JUGADOR BALA ENEMIGA
            for (i = 0; i < jugadores.Count; i++)
            {
                eljugador jugadorin = (eljugador)jugadores[i];
                for (j = 0; j < balasE.Count; j++)
                {
                    disparoEnemigo balaEne = (disparoEnemigo)balasE[j];
                    if (jugadorin.rectangulo.Intersects(balaEne.rectangulo))
                    {
                        if (IntersectPixels(jugadorin.personTransform, jugadorin.imagenAnimada[jugadorin.imagenActual].Width, jugadorin.imagenAnimada[jugadorin.imagenActual].Height, jugadorin.hitColor, balaEne.personTransform, balaEne.imagenAnimada[balaEne.imagenActual].Width, balaEne.imagenAnimada[balaEne.imagenActual].Height, balaEne.hitColor) == true)
                        {
                            balaEne.paraBorrar = true;
                            jugadorin.shields = jugadorin.shields - balaEne.daño;

                            if (jugadorin.nJugador == 1)
                            {
                                tiempoVibra1 = 5;
                            }
                            if (jugadorin.nJugador == 2)
                            {
                                tiempoVibra2 = 5;
                            }
                        }
                    }

                }
            }

            //COLISIONES ENEMIGO BALA ALIADA
            for (i = 0; i < enemigos.Count; i++)
            {
                Enemigo malote = (Enemigo)enemigos[i];
                for (j = 0; j < balasJ.Count; j++)
                {
                    disparo balaNue = (disparo)balasJ[j];
                    if (malote.rectangulo.Intersects(balaNue.rectangulo))
                    {
                        if (IntersectPixels(balaNue.personTransform, balaNue.imagenAnimada[balaNue.imagenActual].Width, balaNue.imagenAnimada[balaNue.imagenActual].Height, balaNue.hitColor, malote.personTransform, malote.imagenAnimada[malote.imagenActual].Width, malote.imagenAnimada[malote.imagenActual].Height, malote.hitColor) == true)
                        {
                            malote.idUltimaBala = balaNue.jugadorN;
                            if (balaNue.balaNormal == true)
                            {
                                balaNue.paraBorrar = true;
                            }
                            malote.shields = malote.shields - balaNue.daño;
                        }
                    }
                }
            }

            //COLISIONES BALAENEMIGO ESCUDO
            for (i = 0; i < balasE.Count; i++)
            {
                disparoEnemigo balaE = (disparoEnemigo)balasE[i];

                for (j = 0; j < escudos.Count; j++)
                {
                    Escudo escudin = (Escudo)escudos[j];
                    if (balaE.rectangulo.Intersects(escudin.rectangulo))
                    {
                        if (IntersectPixels(balaE.personTransform, balaE.imagenAnimada[balaE.imagenActual].Width, balaE.imagenAnimada[balaE.imagenActual].Height, escudin.hitColor, escudin.personTransform, escudin.imagenAnimada[escudin.imagenActual].Width, escudin.imagenAnimada[escudin.imagenActual].Height, escudin.hitColor) == true)
                        {
                            if (balaE.escudoBorra == true)
                            {
                                balaE.paraBorrar = true;
                            }
                        }

                    }
                }
            }


            //COLISIONES ALIADO ENEMIGO
            for (i = 0; i < jugadores.Count; i++)
            {
                eljugador jugadorin = (eljugador)jugadores[i];

                for (j = 0; j < enemigos.Count; j++)
                {
                    Enemigo malote = (Enemigo)enemigos[j];

                    if (malote.rectangulo.Intersects(jugadorin.rectangulo))
                    {
                        if (IntersectPixels(jugadorin.personTransform, jugadorin.imagenAnimada[jugadorin.imagenActual].Width, jugadorin.imagenAnimada[jugadorin.imagenActual].Height, jugadorin.hitColor, malote.personTransform, malote.imagenAnimada[malote.imagenActual].Width, malote.imagenAnimada[malote.imagenActual].Height, malote.hitColor) == true)
                        {
                            if (malote.jefe == false)
                            {
                                Fase.cosas.Add(new Explosion(content, malote.x, malote.y, malote.width, malote.height));
                                malote.paraBorrar = true;
                                jugadorin.shields = jugadorin.shields - 50;
                                if (jugadorin.nJugador == 1)
                                {
                                    tiempoVibra1 = 10;
                                }
                                if (jugadorin.nJugador == 2)
                                {
                                    tiempoVibra2 = 10;
                                }
                            }
                            else
                            {
                                jugadorin.shields--;
                            }

                        }
                    }

                }
            }

        }

        //funcion que coloca la nave elegida al jugador
        public void inicializaJugador(int nJugador, int nave)
        {

            if (nJugador == 1)
            {
                switch (nave)
                {
                    case 1: jugador1 = new RedStar(content, nJugador); break;
                    case 2: jugador1 = new Cless(content, nJugador); break;
                    case 3: jugador1 = new Xavier(content, nJugador); break;
                    case 4: jugador1 = new John(content, nJugador); break;
                    case 5: jugador1 = new Angel(content, nJugador); break;
                }

                jugadores.Add(jugador1);
            }
            else
            {
                switch (nave)
                {
                    case 1: jugador2 = new RedStar(content, nJugador); break;
                    case 2: jugador2 = new Cless(content, nJugador); break;
                    case 3: jugador2 = new Xavier(content, nJugador); break;
                    case 4: jugador2 = new John(content, nJugador); break;
                    case 5: jugador2 = new Angel(content, nJugador); break;

                }
                jugadores.Add(jugador2);
            }
        }

        //Borrado de todos los elementos de pantalla
        public void eliminaTodo()
        {
            traseras.Clear();
            jugadores.Clear();
            enemigos.Clear();
            balasJ.Clear();
            balasE.Clear();
            cosas.Clear();


        }

        //Metodo avanzado de creatorsclub para detectar colisiones
        public static bool IntersectPixels(
                    Matrix transformA, int widthA, int heightA, Color[] dataA,
                    Matrix transformB, int widthB, int heightB, Color[] dataB)
        {
            // Calculate a matrix which transforms from A's local space into
            // world space and then into B's local space
            Matrix transformAToB = transformA * Matrix.Invert(transformB);

            // When a point moves in A's local space, it moves in B's local space with a
            // fixed direction and distance proportional to the movement in A.
            // This algorithm steps through A one pixel at a time along A's X and Y axes
            // Calculate the analogous steps in B:
            Vector2 stepX = Vector2.TransformNormal(Vector2.UnitX, transformAToB);
            Vector2 stepY = Vector2.TransformNormal(Vector2.UnitY, transformAToB);

            // Calculate the top left corner of A in B's local space
            // This variable will be reused to keep track of the start of each row
            Vector2 yPosInB = Vector2.Transform(Vector2.Zero, transformAToB);

            // For each row of pixels in A
            for (int yA = 0; yA < heightA; yA++)
            {
                // Start at the beginning of the row
                Vector2 posInB = yPosInB;

                // For each pixel in this row
                for (int xA = 0; xA < widthA; xA++)
                {
                    // Round to the nearest pixel
                    int xB = (int)Math.Round(posInB.X);
                    int yB = (int)Math.Round(posInB.Y);

                    // If the pixel lies within the bounds of B
                    if (0 <= xB && xB < widthB &&
                        0 <= yB && yB < heightB)
                    {
                        // Get the colors of the overlapping pixels
                        Color colorA = dataA[xA + yA * widthA];
                        Color colorB = dataB[xB + yB * widthB];

                        // If both pixels are not completely transparent,
                        if (colorA.A != 0 && colorB.A != 0)
                        {
                            // then an intersection has been found
                            return true;
                        }
                    }

                    // Move to the next pixel in the row
                    posInB += stepX;
                }

                // Move to the next row
                yPosInB += stepY;
            }

            return false;
        }


        public void comprobarTrial()
        {
            if (Guide.IsTrialMode)
            {
                MediaPlayer.Play(menu.menuSong);
                Game1.estadodeljuego = Game1.MiEstado.Menu;
                menu.estadoMenu = 0;
                Game1.estadodeljuego = Game1.MiEstado.Menu;
                Guide.ShowMarketplace(PlayerIndex.One);

            }
        }
    }



}