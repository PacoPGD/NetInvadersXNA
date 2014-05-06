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
    /// Esta es una de las secuencias de juego, todas heredan de fase y simplemente en los updates indico las charlas y cosas que pasarán
    /// </summary>
    public class SecuenciaIntro : Fase
    {

        public SecuenciaIntro(ContentManager contents)
        {
            eliminaTodo();
            Fase.momentoActual = 0;
            content = contents;
            fondo = content.Load<Texture2D>("fondos/bg1");
 
            cancion = content.Load<Song>("musica/Oblivion");
            velocidadFon = 1;

        }

        public override void Update()
        {
            if (momentoActual == 100)
            {
                charla = new Charla(content, "Adamuz", String.Format(Textos.String1, Textos.Culture));
                cosas.Add(charla); 
            }
            if (momentoActual == 500)
            {
                charla = new Charla(content, "Adamuz", String.Format(Textos.String2, Textos.Culture));
                cosas.Add(charla);
            }
            if (momentoActual == 750)
            {
                charla = new Charla(content, "Adamuz", String.Format(Textos.String3, Textos.Culture));
                cosas.Add(charla);
            }
            if (momentoActual == 1000)
            {
                charla = new Charla(content, "Adamuz", String.Format(Textos.String4, Textos.Culture));
                cosas.Add(charla);
            }
            if (momentoActual == 1200)
            {
                charla = new Charla(content, "Adamuz", String.Format(Textos.String5, Textos.Culture));
                cosas.Add(charla);
            }
            if (momentoActual == 1600)
            {
                charla = new Charla(content, "Adamuz", String.Format(Textos.String6, Textos.Culture));
                cosas.Add(charla);
            }
            if (momentoActual == 2000)
            {
                charla = new Charla(content, "Adamuz", String.Format(Textos.String7, Textos.Culture));
                cosas.Add(charla);
            }

            if (momentoActual == 2400)
            {
                charla = new Charla(content, "Net2", String.Format(Textos.String8, Textos.Culture));
                cosas.Add(charla);
            }
            if (momentoActual == 2700)
            {
                charla = new Charla(content, "Net", String.Format(Textos.String9, Textos.Culture));
                cosas.Add(charla);
            }

            if (momentoActual == 3200)
            {
                decorado = new decorado(content,400,-500,0,4,"Jefes/MoralInyector");
                cosas.Add(decorado);
            }
            if (momentoActual == 3100)
            {
                charla = new Charla(content, "Net2", String.Format(Textos.String10, Textos.Culture));
                cosas.Add(charla);
            }
            if (momentoActual == 3350)
            {
                decorado.vy = 0;
            }
            if (momentoActual == 3400)
            {
                charla = new Charla(content, "Net", String.Format(Textos.String11, Textos.Culture));
                cosas.Add(charla);
            }
            if (momentoActual == 3600)
            {
                charla = new Charla(content, "Net", String.Format(Textos.String12, Textos.Culture));
                cosas.Add(charla);
            }
            if (momentoActual == 4000)
            {
                charla = new Charla(content, "Net2", String.Format(Textos.String13, Textos.Culture));
                cosas.Add(charla);
            }
            if (momentoActual == 4200 || GamePad.GetState(PlayerIndex.One).Buttons.B == ButtonState.Pressed || (Keyboard.GetState().IsKeyDown(Keys.B)) )
            {
                cosas.Remove(charla);
                Game1.mission = new Secuencia1(content);
                MediaPlayer.Play(Game1.mission.cancion);
                Game1.estadodeljuego = Game1.MiEstado.Mission;
            }

            base.Update();

        }
        public override void Draw()
        {
            base.Draw();
        }
    }
}