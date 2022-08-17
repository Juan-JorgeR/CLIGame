using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace AplicacionCursor
{
    class PanelPrincipal
    {
        int x;
        int y;
        int width = 70;
        int height = 35;
        PanelDeCombate panelDeCombate;
        PanelDeEstado panelDeEstado;
        int navesPasadas = 0;

        public PanelPrincipal(int x,int y,PanelDeCombate panelDeCombate,PanelDeEstado panelDeEstado)
        {
            this.x = x;
            this.y = y;
            this.panelDeCombate = panelDeCombate;
            this.panelDeEstado = panelDeEstado;

            this.panelDeCombate.setY(y);
            this.panelDeCombate.setX(x);
            this.panelDeEstado.setX(x);
            this.panelDeEstado.setY(y);
        }

        public void procesoMethod()
        {
            
            while(Program.tecla!=ConsoleKey.Escape && !panelDeCombate.seTerminoElJuego)
            {
                
                panelDeCombate.ejecutar(ref navesPasadas);
                panelDeEstado.ejecutar();
                Thread.Sleep(161);
            }
            Console.CursorVisible = true;
        }

        public void capturarTeclado()
        {
            do
            {
                Program.tecla = Console.ReadKey(true).Key;

            }
            while (Program.tecla != ConsoleKey.Escape);
        }
        

       

    }
}
