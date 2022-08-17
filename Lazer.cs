using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicacionCursor
{
    class Lazer
    {
        int x;
        int y = 17;
        bool impacto;

        public void dibujarse()
        {
            Console.Write("*");
        }

        public void moverse()
        {
            if(y>0)
                y--;
            
        }

        public int getX()
        {
            return x;
        }

        public int getY()
        {
            return y;
        }

        public void setX(int x)
        {
            this.x = x;
        }

        public void huboImpacto()
        {
            impacto = true;
        }

        public bool getImpacto()
        {
            return impacto;
        }
    }
}
