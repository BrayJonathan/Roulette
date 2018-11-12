using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roulette
{
    class Program
    {
        static void Main(string[] args)
        {
            int stackBank = 1000000, stackPlayer=0;
            TestUtils tu = new TestUtils();
            Roulette roulette = new Roulette();
            bool isValid = false;


            Console.WriteLine("Bienvenue au Casino :");
            while(!isValid)
            {
                Console.WriteLine("Entrer la somme que vous désirez échanger en jeton (<1 000 000) :");
                stackPlayer = tu.StackPlayerTest(Console.ReadLine(), stackBank);
                if (stackPlayer != -1)
                {
                    isValid = true;
                }
                else
                {
                    Console.WriteLine("Erreur de saisie. Vous devez entrer un nombre qui soit inférieur au solde de la banque ({0})", stackBank);
                }
            }
          
            while (stackPlayer > 0 && stackBank > 0)
            {
                Console.WriteLine();
                int response = roulette.GenerateNumber();
                //Console.WriteLine("Reponse roulette = {0}", response);
                Console.WriteLine("Saisir votre nombre:(entre 0 et 36)");
                int trial = tu.TrialTest(Console.ReadLine());
                if (trial != -1)
                {
                    Console.WriteLine("Saisir votre mise:");
                    int bet = tu.BetTest(Console.ReadLine(), stackPlayer, stackBank);
                    if (bet != -1)
                    {
                        stackPlayer = stackPlayer - bet;
                        stackBank = stackBank + bet;
                        bool hasWin;
                        int result = tu.GameTest(response, trial, out hasWin);
                        if (hasWin)
                        {
                            stackPlayer = stackPlayer + result;
                            stackBank = stackBank - result;
                        }
                        Console.WriteLine("Le {0} est sortie. Vous avez {1} {2}, nouveau solde : {3}", response, hasWin ? "gagné" : "perdu", result, stackPlayer);
                    }
                    else
                    {
                        Console.WriteLine("Erreur lors de la saisie de la mise");
                    }
                }
                else
                {
                    Console.WriteLine("Erreur lors de la saisie du nombre");
                }
            }
            Console.ReadLine();
        }
    }
}
