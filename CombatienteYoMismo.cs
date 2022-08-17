using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicacionCursor
{
    class CombatienteYoMismo : Combatiente
    {

        public CombatienteYoMismo(int x,int y,int numeroDeVidas)
        {
            this.x = x;
            this.y = y;
            this.numeroDeVidas = numeroDeVidas;

        }

        public override void moverse()
        {
            if (Program.tecla == ConsoleKey.RightArrow)
            {
                if (this.getX() < 44)
                    x += 3;
               
            }
            else if (Program.tecla == ConsoleKey.LeftArrow)
            {
                if (this.getX() > 0)
                    x -= 3;
            }
           
        }

        public void disparar(Lazer[] lazers)
        {
           


                for (int i = 0; i < 50; i++)
                {
                    if (lazers[i] == null)
                    {
                        Lazer lazer = new Lazer();
                        lazer.setX(this.x + 1);
                        lazers[i] = lazer;
                        break;
                    }
                }
         
        }

        public override void dibujarse(PanelDeCombate panelDeCombate)
        {
            if(numeroDeVidas>0)
            {
                Console.SetCursorPosition(this.getX() + panelDeCombate.getX(), this.getY() + panelDeCombate.getY());
                Console.Write(" ^ ");
                Console.SetCursorPosition(this.getX() + panelDeCombate.getX(), this.getY() + panelDeCombate.getY() + 1);
                Console.Write("<=>");
            }
            else
            {
                Console.SetCursorPosition(this.getX() + panelDeCombate.getX(), this.getY() + panelDeCombate.getY());
                Console.Write(".   . ");
                Console.SetCursorPosition(this.getX() + panelDeCombate.getX(), this.getY() + panelDeCombate.getY() + 1);
                Console.Write(".   .");
                panelDeCombate.seTerminoElJuego = true;
            }
           
        }

        public void restarUnaVida()
        {
            numeroDeVidas--;
        }

        public void restarTodasLasVidas()
        {
            numeroDeVidas = 0;
        }

        public void sumarVida()
        {
            numeroDeVidas ++;
        }

        public override void dibujarse()
        {
            throw new NotImplementedException();
        }

        public int getX()
        {
            return x;
        }

        public int getY()
        {
            return y;
        }
    }
}
