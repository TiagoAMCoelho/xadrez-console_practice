using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using tabuleiro;
using xadrez;

namespace xadrez_console
{
    class Tela
    {

        private static ConsoleColor _fundoOriginal = ConsoleColor.Black;
        private static ConsoleColor _fundoAlterado = ConsoleColor.Green;

        public static void ImprimirPartida(PartidaDeXadrez partida)
        {
            ImprimirTabuleiro(partida.Tab);
            Console.WriteLine();
            ImprimirPecasCapturadas(partida);
            Console.WriteLine();
            Console.WriteLine("Turno: " + partida.Turno);
            if (!partida.Terminada)
            {
                Console.WriteLine("Aguarda jogada: " + partida.JogadorAtual);
                if (partida.xeque)
                {
                    Console.WriteLine("XEQUE!");
                }
            }
            else
            {
                Console.WriteLine("XEQUEMATE!");
                Console.WriteLine("Vencedor: " + partida.JogadorAtual);
            }
        }

        private static void ImprimirPecasCapturadas(PartidaDeXadrez partida)
        {
            Console.WriteLine("Peças capturadas:");
            Console.Write("Brancas: ");
            ImprimirConjunto(partida.PecasCapturadas(Cor.Branca));
            Console.WriteLine();
            Console.Write("Pretas: ");
            ConsoleColor aux = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            ImprimirConjunto(partida.PecasCapturadas(Cor.Preta));
            Console.ForegroundColor = aux;
        }

        private static void ImprimirConjunto(HashSet<Peca> pecas)
        {
            Console.Write("[");
            foreach (Peca peca in pecas)
            {
                Console.Write(peca + " ");
            }
            Console.Write("]");
        }

        public static void ImprimirTabuleiro(Tabuleiro tab)
        {
            ConsoleColor foregroundColor = Console.ForegroundColor;
            for (int i = 0; i < tab.Linhas; i++)
            {
                
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Write(8 - i + " ");
                Console.BackgroundColor = _fundoOriginal;
                Console.ForegroundColor = foregroundColor;
                for (int j = 0; j < tab.Colunas; j++)
                {
                    ImprimirPeca(tab.Peca(i, j), _fundoOriginal);
                }
                Console.WriteLine();
            }

            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("  a b c d e f g h ");
            Console.BackgroundColor = _fundoOriginal;
            Console.ForegroundColor = foregroundColor;
        }

        public static void ImprimirTabuleiro(Tabuleiro tab, bool[,] posicoesPossiveis)
        {
            ConsoleColor foregroundColor = Console.ForegroundColor;
            for (int i = 0; i < tab.Linhas; i++)
            {
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Write(8 - i + " ");
                Console.BackgroundColor = _fundoOriginal;
                Console.ForegroundColor = foregroundColor;
                for (int j = 0; j < tab.Colunas; j++)
                {
                    if (posicoesPossiveis[i, j])
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
            foregroundColor = Console.ForegroundColor;
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("  a b c d e f g h ");
            Console.BackgroundColor = _fundoOriginal;
            Console.ForegroundColor = foregroundColor;
        }

        public static void ImprimirPeca(Peca peca, ConsoleColor backgroundColor)
        {

            if (peca == null)
            {
                Console.BackgroundColor = backgroundColor;
                Console.Write("-");
                Console.BackgroundColor = _fundoOriginal;
                Console.Write(" ");
            }
            else
            {
                if (peca.Cor == Cor.Branca)
                {
                    Console.BackgroundColor = backgroundColor;
                    Console.Write(peca);
                    Console.BackgroundColor = _fundoOriginal;
                }
                else
                {
                    ConsoleColor aux = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.BackgroundColor = backgroundColor;
                    Console.Write(peca);
                    Console.BackgroundColor = _fundoOriginal;
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
