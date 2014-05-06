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
using System.Text;
using System.IO;
using System.Xml.Serialization;
using System.Globalization;


//http://msdn.microsoft.com/es-es/aa937791.aspx

namespace NetInvaders
{
    /// <summary>
    /// Bien, nuestra clase main lo unico que hace es lanzar esta clase, que es la clase que maneja todo principalmente
    /// dede aqui controlamos el ancho y alto de la pantalla, el numero de jugadores seleccionados actualmente,
    /// o la pantalla que permanece activa
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        // Realmente cada variable tiene un nombre descriptivo que no da lugar a dudas de que significan
        public static float width;
        public static float height;
        public static int numeroJugadores=1;
        public static int missionSeleccionada=1;
        public static int naveSeleccionada1=1;
        public static int naveSeleccionada2=2;

        //El GraphicsDeviceManager es el encargado de pintar las cosas en determinado orden en la pantalla, darle un tamaño
        //es una clase que nos incluye xna y que gracias a diversas instrucciones haremos que pinte lo que queramos
        public GraphicsDeviceManager graphics;

        //El spriteBatch es el encargado de guardar todas las imagenes que despues mostraremos
        public static SpriteBatch spriteBatch;

        menu menuP;

        //INICIAR FASES
        public static creditos creditosP;
        public static Fase mission;

        pausa pausar;


        GamerServicesComponent componente;
  
        //Creo una serie de estados de juego "estar en el menu" "jugar una mision" "tener el juego en pausa"
        public enum MiEstado
        {
            Menu,
            Mission,
            Pausa
        };

        public static MiEstado estadodeljuego = MiEstado.Menu;


        public String nombre1 = "Jugador 1";
        public String nombre2 = "Jugador 2";


        public static Gamer gamer1;
        public static Gamer gamer2;
        public static GamerProfile gamerProfile1;
        public static GamerProfile gamerProfile2;
        public static Texture2D picture1;
        public static Texture2D picture2;
        public static int login1;
        public static int login2;

       

        public Game1()
        {

    
            //El gamerservicescomponent es el encargado de hacer que nuestra aplicación se pueda conectar al live
            //componente = new GamerServicesComponent(this);
           // Components.Add(componente);

            Guide.SimulateTrialMode = true;

            //Inicializamos graphics
            graphics = new GraphicsDeviceManager(this);
            //Le damos un tamaño a la pantalla
            this.graphics.PreferredBackBufferWidth = 1280;
            this.graphics.PreferredBackBufferHeight = 720;
            Content.RootDirectory = "Content";

            Textos.Culture = CultureInfo.CurrentCulture;

        }
        


        /// <summary>
        /// Este metodo es el encargado de inicializar la clase "ejecuta una serie de ordenes cuando la clase es creada"
        /// </summary>
        protected override void Initialize()
        {
            
            menuP = new menu(this, Content);
            creditosP = new creditos(Content);
            pausar = new pausa(this, Content);
            //opcion comentada por si queremos poner el juego a pantalla completa
            //graphics.IsFullScreen = true;

           

            base.Initialize();
        }


        protected override void LoadContent()
        {
            // Con el spritebatch ya inicializado podemos empezar a pintar texturas
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // Recogemos los datos de graphics que contienen el tamaño
            width = graphics.GraphicsDevice.Viewport.Width;
            height = graphics.GraphicsDevice.Viewport.Height;

            //reproducimos una canción inicial
            MediaPlayer.Play(menu.menuSong);
            
        }

        //Metodo para eliminar el contenido cargado, en un principio no lo he usado ya que el proyecto no es tan
        //ambicioso
        protected override void UnloadContent()
        {

        }


        /// <summary>
        /// Este es nuestro metodo de update, cada vez que pase algo este metodo se encargara de realizar los cambios pertinentes
        /// choques de naves, pulsar el boton del controlador, abrir distintos menus para cambiar el estado de pantalla...
        /// </summary>
        protected override void Update(GameTime gameTime)
        {
            //PARA USAR XBOX LIVE USERS Y TAL
            //GamerServicesDispatcher.Update();
            //componente.Update(gameTime);

            graphics.ApplyChanges();
            


            //if (Guide.IsVisible==false)
           // {

                //Si pulsamos el boton back del mando cierro la aplicación, asi cuando hago pruebas lo hago mucho mas rapido
                if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                {
                    MediaPlayer.Stop();
                    this.Exit();
                }
                //dependiendo del estado del juego cargaremos un metodo u otro "que estan en las clases determinadas"
                if (estadodeljuego == MiEstado.Menu)
                {
                    menuP.Update();
                }
                else
                {
                    if (estadodeljuego == MiEstado.Mission)
                    {
                        mission.Update();
                    }
                    else
                    {
                        if (estadodeljuego == MiEstado.Pausa)
                        {
                            pausar.Update();
                        }
                    }

                }

                base.Update(gameTime);
          //  }
            
        }


        /// <summary>
        /// El metodo draw es el encargado de pintar, en este caso pintará algo dependiendo de la clase activa 
        /// que tengamos "si es un menu, una mission, etc"
        /// </summary>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            if (estadodeljuego == MiEstado.Menu)
            {
                menuP.Draw();
            }

            else
            {
                if (estadodeljuego == MiEstado.Mission)
                {
                    mission.Draw();
                }
                else
                {
                    if (estadodeljuego == MiEstado.Pausa)
                    {
                        pausar.Update();
                    }
                }

            }

            base.Draw(gameTime);
        }


        /// <summary>
        /// Funcion para salir del juego
        /// </summary>
        public void salir()
        {
            this.Exit();
        }


        T LoadLocalizedAsset<T>(string assetName)
        {
            string[] cultureNames =
            {
                CultureInfo.CurrentCulture.Name,                        // eg. "en-US"
                CultureInfo.CurrentCulture.TwoLetterISOLanguageName     // eg. "en"
            };

            // Look first for a specialized language-country version of the asset,
            // then if that fails, loop back around to see if we can find one that
            // specifies just the language without the country part.
            foreach (string cultureName in cultureNames)
            {
                string localizedAssetName = assetName + '.' + cultureName;

                try
                {
                    return Content.Load<T>(localizedAssetName);
                }
                catch (ContentLoadException) { }
            }

            // If we didn't find any localized asset, fall back to the default name.
            return Content.Load<T>(assetName);
        }


    }
}
