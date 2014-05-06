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
    /// Clase de las bombas
    /// </summary>
    public class Bomba : disparo
    {
        public Bomba(ContentManager contents, int x, int y, int jugadorNumero,int NBomba)
        {
            content = contents;
            jugadorN = jugadorNumero;

            this.x = x;
            this.y = y;
            daño = 50;

            if (jugadorNumero == 1)
            {
                Fase.tiempoVibra1 = 10;
            }
            if (jugadorNumero == 2)
            {
                Fase.tiempoVibra2 = 10;
            }

            //Esto es la unica parte especial que tiene el codigo, al disparar la bomba se generan 8 proyectiles en
            //diferentes direcciones, eso dependera del numero de bomba que tienen rango 1-8, cada una con un dibujo y 
            //velocidad diferentes
            switch (NBomba)
            {
                case 1: vy = -16; imagenAnimada[0] = content.Load<Texture2D>("disparos/buenos/bomb/bombU"); break;
                case 2: vx = 8; vy = -8; imagenAnimada[0] = content.Load<Texture2D>("disparos/buenos/bomb/bombUR"); break;
                case 3: vx = 16; imagenAnimada[0] = content.Load<Texture2D>("disparos/buenos/bomb/bombR"); break;
                case 4: vx = 8; vy = 8; imagenAnimada[0] = content.Load<Texture2D>("disparos/buenos/bomb/bombDR"); break;
                case 5: vy = 16; imagenAnimada[0] = content.Load<Texture2D>("disparos/buenos/bomb/bombD"); break;
                case 6: vx = -8; vy = 8; imagenAnimada[0] = content.Load<Texture2D>("disparos/buenos/bomb/bombDL"); break;
                case 7: vx = -16; imagenAnimada[0] = content.Load<Texture2D>("disparos/buenos/bomb/bombL"); break;
                case 8: vx = -8; vy = -8; imagenAnimada[0] = content.Load<Texture2D>("disparos/buenos/bomb/bombUL"); break;
            }
            inicializa();
        }

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