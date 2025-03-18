using System;
using System.Runtime.InteropServices;
using tabuleiro;
using xadrez;

namespace xadrez_console
{
    class Tela
    {

        private static ConsoleColor _fundoOriginal = ConsoleColor.Black;
        private static ConsoleColor _fundoAlterado = ConsoleColor.Green;
        public static void ImprimirTabuleiro(Tabuleiro tab)
        {
            for (int i = 0; i < tab.Linhas; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < tab.Colunas; j++)
                {
                    ImprimirPeca(tab.Peca(i, j), _fundoOriginal);
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h ");
        }

        public static void ImprimirTabuleiro(Tabuleiro tab, bool[,] posicoesPossiveis)
        { 
            for (int i = 0; i < tab.Linhas; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < tab.Colunas; j++)
                {
                    if(posicoesPossiveis[i, j])
                    {
                        ImprimirPeca(tab.Peca(i, j), _fundoAlterado);
                    }
                    else
                    {
                        ImprimirPeca(tab.Peca(i, j), _fundoOriginal);
                    }
                        
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h ");
            Console.BackgroundColor = _fundoOriginal;
        }

        public static void ImprimirPeca(Peca peca, ConsoleColor backgroundColor)
        {

            if (peca == null)
            {
                Console.BackgroundColor=backgroundColor;
                Console.Write("-");
                Console.BackgroundColor = _fundoOriginal;
                Console.Write(" ");


            }
            else
            { 
                if (peca.Cor == Cor.Branca)
                {
                    Console.Write(peca);
                }
                else
                {
                    ConsoleColor aux = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(peca);
                    Console.ForegroundColor = aux;
                }
                Console.Write(" ");
            }
        }

        public static PosicaoXadrez LerPosicaoXadrez()
        {
            string s = Console.ReadLine();
            char coluna = s[0];
            int linha = int.Parse(s[1] + "");

            return new PosicaoXadrez(coluna, linha);
        }
    }
}
