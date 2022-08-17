using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicacionCursor
{

    abstract class Combatiente
    {
        protected int x;
        protected int y;
        protected int numeroDeVidas;

        public abstract void moverse();
        public abstract void dibujarse(PanelDeCombate panelDeCombate);
        public abstract void dibujarse();

        public int getX()
        {
            return x;
        }

        public int getY()
        {
            return y;
        }

        public int getNumeroDeVidas()
        {
            return numeroDeVidas;
        }

    }
}


