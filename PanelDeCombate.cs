using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
                                                  
namespace AplicacionCursor
{
    class PanelDeCombate
    {
        int x;
        int y;
        int width=50;
        int height=20;
        CombatienteEnemigo[] combatientesEnemigos = new CombatienteEnemigo[5];
        Lazer[] lazers;
        public bool seTerminoElJuego;
        public CombatienteYoMismo yo;
        public int score = 0;
        public int contadorEnemigosDestruidos = 0;

        public PanelDeCombate(CombatienteEnemigo[] combatientesEnemigos,Lazer[] lazers,CombatienteYoMismo yo)
        {
            this.combatientesEnemigos = combatientesEnemigos;
            this.lazers = lazers;
            this.yo = yo;
        }

        private void crearCombatienteEnemigo()
        {
            int contador = 0;
            for(int i=0;i<5;i++)
            {
                if (combatientesEnemigos[i] == null)
                    contador++;
            }

            
            Random random = new Random();
            int agregarCombatienteEnemigo = random.Next(5);

            if (contador == 5)
            {
                int x = random.Next(15) * 3;
                combatientesEnemigos[0] = new CombatienteEnemigo(x, 0, 1);
            }

            else
            {
                if (agregarCombatienteEnemigo == 1)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        if (combatientesEnemigos[i] == null)
                        {


                            int x;
                            int y = 0;
                            bool xExiste = false;

                            do
                            {
                                xExiste = false;
                                x = random.Next(15) * 3;
                                foreach (CombatienteEnemigo a in combatientesEnemigos)
                                {
                                    if(a!=null)
                                    {
                                        if (x == a.getX())
                                        {
                                            xExiste = true;
                                            break;
                                        }
                                    }
                                   




                                }

                                if (xExiste == false)
                                {
                                    combatientesEnemigos[i] = new CombatienteEnemigo(x, y, 1);

                                }

                            } while (xExiste);


                            break;

                        }
                    }
                }
            }
                

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

       
        public void ejecutar(ref int navesPasadas)
        {
            Console.CursorVisible = true;
            Console.SetCursorPosition(x,y);
            actualizar();

            yo.moverse();

            
            yo.dibujarse(this);
           

            crearCombatienteEnemigo();

            if (Program.tecla==ConsoleKey.X)
            {
                yo.disparar(lazers);
              
                
            }
            if(Program.tecla==ConsoleKey.X || Program.tecla==ConsoleKey.RightArrow || Program.tecla == ConsoleKey.LeftArrow)
               Program.tecla = ConsoleKey.L;


            determinarSiHayImpactoDelLazer();
            determinarSiHayImpactoConMigo();


            for (int i = 0; i < 5; i++)
            {
                
                if (combatientesEnemigos[i] != null)
                {
                                       
                    
                    if (combatientesEnemigos[i].getNumeroDeVidas() > 0)
                    {
                        Console.SetCursorPosition(x + combatientesEnemigos[i].getX(), y + combatientesEnemigos[i].getY());
                        combatientesEnemigos[i].dibujarse();

                        if (combatientesEnemigos[i].getY() + y < (height + y) - 1)
                            combatientesEnemigos[i].moverse();
                        else
                        {
                            combatientesEnemigos[i] = null;
                            navesPasadas++;
                            if(navesPasadas==2)
                            {
                                yo.restarUnaVida();
                                navesPasadas=0;
                            }
                            //yo.restarUnaVida();
                        }
                            
                    }

                    else
                    {
                        Console.SetCursorPosition(x + combatientesEnemigos[i].getX(), y + combatientesEnemigos[i].getY()-1);
                        
                        Console.Write(". .");
                        Console.SetCursorPosition(x + combatientesEnemigos[i].getX(), y + combatientesEnemigos[i].getY());
                        Console.Write(". .");
                        
                        combatientesEnemigos[i] = null;
                    }
                        

                }              
               
            }
           
            for(int i=0;i<50;i++)
            {
                if (lazers[i] != null)
                {
                    lazers[i].moverse();

                    if (lazers[i].getY()>0)
                    {
                        Console.SetCursorPosition(lazers[i].getX() + x, lazers[i].getY() + y);
                        lazers[i].dibujarse();
                    }
                    else
                    {
                        lazers[i] = null;
                    }
                    
                }
            }
         
        }

        void actualizar()
        {
           
            for (int i = 1; i <= height*width; i++)
            {
                if (i % width == 0)
                    Console.WriteLine(" ");
                else
                    Console.Write(" ");
            }
        }

        void determinarSiHayImpactoDelLazer()
        {
            for (int i = 0; i < 5; i++)
            {
                if (combatientesEnemigos[i] != null)
                {
                    for (int j = 0; j < 50; j++)
                    {
                        if (lazers[j] != null)
                        {


                            if (lazers[j].getX() == combatientesEnemigos[i].getX() + 1 && (lazers[j].getY() == combatientesEnemigos[i].getY() || lazers[j].getY() == combatientesEnemigos[i].getY()-1))
                            {

                                lazers[j] = null;
                                combatientesEnemigos[i].disminuirNumeroDeVidas();
                                if(contadorEnemigosDestruidos<2)
                                {
                                    contadorEnemigosDestruidos++;
                                }
                                else
                                {
                                    contadorEnemigosDestruidos = 0;
                                    if(yo.getNumeroDeVidas()<3)
                                        yo.sumarVida();
                                }
                                
                                score++;
                                break;
                            }                        

                        }
                    }
                }
                   
            }
            
        }

        void determinarSiHayImpactoConMigo()
        {
            for (int i = 0; i < 5; i++)
            {
                if (combatientesEnemigos[i] != null)
                {
                    for (int j = 0; j < 50; j++)
                    {
                       


                            if ((yo.getX() == combatientesEnemigos[i].getX() || yo.getX() == combatientesEnemigos[i].getX() + 1 || yo.getX() == combatientesEnemigos[i].getX() + 2) && yo.getY()==combatientesEnemigos[i].getY())
                            {


                                yo.restarTodasLasVidas();
                                break;
                            }

                        
                    }
                }

            }

        }

    }
}
