using System;
using System.Collections.Generic;

namespace Exo_Fenêtre
{
    enum MenuAction
    {
        NONE,
        AJOUTER_MEMO,
        SUPPRIMER_MEMO,
        QUITTER
    }

    class Program
    {
        static int GenereRandom()
        {
            Random rng = new Random();
            return rng.Next(0, 15);
        }
        static MenuAction Menu(Fenetre menu, Fenetre contenant, Fenetre input, Fenetre offput)
        {
            int i = 3;
            MenuAction saisie;
            Console.ForegroundColor = menu.Color;

            foreach (string item in menu.Content)
            {
                Console.SetCursorPosition(i, Console.WindowHeight - 3);
                Console.WriteLine(item);
                i += item.Length + 28;
            }
            try
            {
                Console.SetCursorPosition(4, Console.WindowHeight - 5);
                Console.Write("Choix : ");
                saisie = (MenuAction)Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception)
            {
                saisie = MenuAction.NONE;
            }


            switch (saisie)
            {
                case MenuAction.AJOUTER_MEMO:
                    AjouterMemo(contenant, input);
                    break;
                case MenuAction.SUPPRIMER_MEMO:
                    SupprimerMemo(contenant, offput);
                    break;
                case MenuAction.QUITTER:
                    break;
                default:
                    break;
            }

            return saisie;

        }

        static void DessineFenetre(Fenetre maFenetre)
        {
            List<string> temp = maFenetre.CreateFenetre();
            foreach (string item in temp)
            {
                Console.ForegroundColor = maFenetre.Color;
                Console.WriteLine(item);
            }
        }

        static void Popup(Fenetre popup)
        {
            int i = (Console.WindowHeight - popup.Height) / 2;
            List<string> temp = popup.CreateFenetre();
            foreach (string item in temp)
            {
                Console.ForegroundColor = popup.Color;
                Console.SetCursorPosition((Console.WindowWidth - item.Length) / 2, i);
                Console.WriteLine(item);
                i++;
            }
        }

        static void ContenuMemo(Fenetre maFenetre)
        {
            int j = 0;
            ConsoleColor[] colors = (ConsoleColor[])ConsoleColor.GetValues(typeof(ConsoleColor));
            if (maFenetre.Content.Count > 0)
            {
                foreach (string text in maFenetre.Content)
                {
                    Console.ForegroundColor = colors[GenereRandom()];
                    Console.SetCursorPosition(1, j + 1);
                    Console.WriteLine("═╡ n° " + j + " ║ " + text);
                    j++;
                }
            }
        }

        static void AjouterMemo(Fenetre contenant, Fenetre input)
        {
            string ajoutLigneContenu;

            Popup(input);

            Console.SetCursorPosition(33, Console.WindowHeight / 2);
            ajoutLigneContenu = Console.ReadLine();
            contenant.Content.Add(ajoutLigneContenu);
        }

        static void SupprimerMemo(Fenetre contenant, Fenetre offput)
        {
            int numeroMemo = 0;
            int position;
            int choix;

            Popup(offput);

            /*
            int position = (contenant.Content.Count > 0) ? (Console.WindowWidth / 2) - (offput.Width / (4 * contenant.Content.Count)) : Console.WindowWidth / 2;
            */

            if (contenant.Content.Count > 0)
            {
                position = (Console.WindowWidth / 2 - offput.Width / 2) + (offput.Width / (2 * contenant.Content.Count) - 4);
                foreach (string item in contenant.Content)
                {
                    Console.SetCursorPosition(position, Console.WindowHeight / 2);
                    Console.Write(" [ " + numeroMemo + " ] ");
                    numeroMemo++;
                    position += offput.Width / contenant.Content.Count;
                }

                try
                {
                    Console.SetCursorPosition(0, 0);
                    choix = Int16.Parse(Console.ReadLine());
                    contenant.Content.RemoveAt(choix);
                }
                catch (Exception)
                {
                    Console.SetCursorPosition(Console.WindowWidth / 2, Console.WindowHeight / 2);
                    Console.WriteLine("Ce n'est pas un numéro de mémo");
                }

            }
        }
        static void Main(string[] args)
        {
            MenuAction saisie;

            List<Fenetre> affichage = new List<Fenetre>();

            Fenetre maFenetre = new Fenetre(Console.WindowHeight - 9, Console.WindowWidth - 1, ConsoleColor.DarkYellow, "╡ Memo ╞");
            Fenetre menu = new Fenetre(6, Console.WindowWidth - 1, ConsoleColor.Red, "╡ Menu ╞");
            Fenetre input = new Fenetre(4, 60, ConsoleColor.Green, "╡ Ajouter Memo ╞");
            Fenetre offput = new Fenetre(4, 60, ConsoleColor.DarkRed, "╡ Supprimer Memo ╞");

            affichage.Add(maFenetre);
            affichage.Add(menu);

            menu.Content.Add(" [ 1 ] Ajouter Memo");
            menu.Content.Add(" [ 2 ] Supprimer Memo");
            menu.Content.Add(" [ 3 ] Quitter");

            do
            {
                foreach (Fenetre item in affichage)
                {
                    DessineFenetre(item);
                }

                ContenuMemo(maFenetre);

                saisie = Menu(menu, maFenetre, input, offput);

                Console.Clear();

            } while (saisie != MenuAction.QUITTER);

        }
    }
}
