using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicacionCursor
{
    class PanelDeEstado
    {
       
        int line = 0;
        int x;
        int y;
        int width = 25;
        int height = 20;
        PanelDeCombate panelDeCombate;
        public PanelDeEstado(PanelDeCombate panelDeCombate)
        {
           
            this.panelDeCombate = panelDeCombate;
        }

        /*public int getScore()
        {
            return score;
        }*/

        public void ejecutar()
        {
            Console.SetCursorPosition(x + panelDeCombate.getWidth(), y);
            actualizar();
            Console.SetCursorPosition(x+panelDeCombate.getWidth(),5);
            Console.Write("score: ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(panelDeCombate.score);
            Console.ForegroundColor = ConsoleColor.White;

            Console.SetCursorPosition(x + panelDeCombate.getWidth(), 7);
            Console.Write("vidas: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(panelDeCombate.yo.getNumeroDeVidas());
            Console.ForegroundColor = ConsoleColor.White;
        }

        public int getX()
        {
            return x;
        }

        public int getY()
        {
            return y;
        }

        public int getWidth()
        {
            return width;
        }

        public int getHeight()
        {
            return height;
        }

        public void setY(int y)
        {
            this.y = y;
        }

        public void setX(int x)
        {
            this.x = x;
        }

        void actualizar()
        {

            for (int i = 1; i <= height * width; i++)
            {
                
                if (i % width == 0)
                {
                   
                    
                    Console.WriteLine(" ");
                    line++;
                    Console.SetCursorPosition(x + panelDeCombate.getWidth(), 7);
                    
                }
                    
                else
                {
                    Console.Write(" ");
                }
                   
            }
        }

    }
}
