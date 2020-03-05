using System;
using System.Collections.Generic;
using System.Text;

namespace Exo_Fenêtre
{
    class Fenetre
    {
        public int Height;
        public int Width;
        public ConsoleColor Color;

        public List<string> Content;

        public string Title;
        public Fenetre(int h, int l, ConsoleColor color, string title = "")
        {
            Height = h;
            Width = l;
            Content = new List<string>();
            Color = color;
            Title = title;
        }
        
        public List<string> CreateFenetre()
        {
            string ligne;
            List<string> fenetre = new List<string>();
            for(int i = 0; i <= Height; i++)
            {
                ligne = "";
                if (i == 0)
                {
                    for(int j = 0; j <= Width - Title.Length + 1; j++ )
                    {
                        if (j == 2)
                        {
                            ligne += Title;
                        }
                        else if (j == 0)
                        {
                            ligne += "╔";
                        }
                        else if (j == Width - Title.Length + 1)
                        {
                            ligne += "╗";
                        }
                        else
                        {
                            ligne += "═";
                        }
                    }
                }
                else if (i == Height)
                {
                    for (int j = 0; j <= Width; j++)
                    {
                        if (j == 0)
                        {
                            ligne += "╚";
                        }
                        else if (j == Width)
                        {
                            ligne += "╝";
                        }
                        else
                        {
                            ligne += "═";
                        }
                    }
                }
                else
                {
                    for(int j = 0; j <= Width; j++)
                    {
                        if (j == 0 || j == Width)
                        {
                            ligne += "║";
                        }
                        else
                        {
                            ligne += " ";
                        }
                    }
                }
                fenetre.Add(ligne);
            }
            return fenetre;
        }

    }
}
