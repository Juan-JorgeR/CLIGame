using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace AplicacionCursor
{
    class Program
    {
        public static int posInicial = Console.CursorTop;
        static CombatienteEnemigo[] combatientesEnemigos = new CombatienteEnemigo[5];
        static Lazer[] lazers=new Lazer[50];
        static CombatienteYoMismo yo = new CombatienteYoMismo(0, 18, 1);
        public static ConsoleKey tecla;
        


        static void Main(string[] args)
        {

            PanelDeCombate panelDeCombate = new PanelDeCombate(combatientesEnemigos, lazers, yo);
            PanelDeEstado panelDeEstado = new PanelDeEstado(panelDeCombate);
            PanelPrincipal panelPrincipal = new PanelPrincipal(0,posInicial,panelDeCombate,panelDeEstado);

            ThreadStart ts = new ThreadStart(panelPrincipal.procesoMethod);
            ThreadStart tsTeclado = new ThreadStart(panelPrincipal.capturarTeclado);
            Thread proceso = new Thread(ts);
            Thread procesoTeclado = new Thread(tsTeclado);

            proceso.Start();
            procesoTeclado.Start();
            
        }
    }
}
