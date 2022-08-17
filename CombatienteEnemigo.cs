using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicacionCursor
{
    class CombatienteEnemigo : Combatiente
    {
  
        public CombatienteEnemigo(int x, int y, int numeroDeVidas)
        {
            this.x = x;
            this.y = y;
            this.numeroDeVidas = numeroDeVidas;

        }

        public override void moverse()
        {
            y += 1;
        }

        public override void dibujarse()
        {
            Console.Write("(x)");
        }

        public override void dibujarse(PanelDeCombate panelDeCombate)
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

        public void disminuirNumeroDeVidas()
        {
            numeroDeVidas -= 1;
        }

        public int getNumeroDeVidas()
        {
            return numeroDeVidas;
        }
    }
}

