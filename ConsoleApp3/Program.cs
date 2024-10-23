using System;
using System.Collections.Generic;

namespace Jogo_da_Memoria
{
    class Program
    {
        static List<string> cartas;
        static List<string> tabuleiro;
        static int parEncontrado;
        static Random rdn = new Random();
        static void Main()
        {
            cartas = new List<string> { "A", "B", "C", "D", "E", "F", "G", "H", "A", "B", "C", "D", "E", "F", "G", "H" };
            tabuleiro = new List<string> { "*", "*", "*", "*", "*", "*", "*", "*", "*", "*", "*", "*", "*", "*", "*", "*" };
            EmbaralharCartas();
            Jogar();
        }
        static void EmbaralharCartas()
        {
            for (int i = 0; i < cartas.Count; i++)
            {
                int j = rdn.Next(i, cartas.Count);
                string temp = cartas[i];
                cartas[i] = cartas[j];
                cartas[j] = temp;
            }
        }
        static void ExibirTabuleiro()
        {
            Console.Clear();
            Console.WriteLine($"|{tabuleiro[0]}|{tabuleiro[1]}|{tabuleiro[2]}|{tabuleiro[3]}|         Pontos: {parEncontrado}\n" +
            $"|{tabuleiro[4]}|{tabuleiro[5]}|{tabuleiro[6]}|{tabuleiro[7]}|\n" +
            $"|{tabuleiro[8]}|{tabuleiro[9]}|{tabuleiro[10]}|{tabuleiro[11]}|\n" +
            $"|{tabuleiro[12]}|{tabuleiro[13]}|{tabuleiro[14]}|{tabuleiro[15]}|");
        }
        static void VirarCarta(int i)
        {
            tabuleiro[i] = cartas[i];
            ExibirTabuleiro();
        }
        static int EscolherCarta()
        {
            while (true)
            {
                Console.Write("Escolha um valor de 1 a 16: ");
                if (int.TryParse(Console.ReadLine(), out int casa) && casa > 0 && casa <= cartas.Count && tabuleiro[casa - 1] == "*")
                    return casa - 1;
                Console.WriteLine("Digite outro valor.");
            }
        }

        static void Jogar()
        {
            while (parEncontrado < cartas.Count / 2)
            {
                ExibirTabuleiro();

                int escolha1 = EscolherCarta();
                VirarCarta(escolha1);

                int escolha2 = EscolherCarta();
                VirarCarta(escolha2);

                if (cartas[escolha1] == cartas[escolha2])
                {
                    Console.Write("Você marcou um ponto.");
                    parEncontrado++;
                }
                else
                {
                    Console.Write("Os pares não são iguais.");
                    tabuleiro[escolha1] = "*";
                    tabuleiro[escolha2] = "*";
                }
                Console.ReadKey();
            }
            Console.Write("Deseja reiniciar? (s/n): ");
            if (Console.ReadLine().ToLower() == "s")
            {
                parEncontrado = 0;
                Main();
            }
            Console.Write("Obrigado por jogar.");
            Console.Read();
        }
    }
}