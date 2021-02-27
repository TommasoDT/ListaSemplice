using System;
using DeTommaso.Tommaso.J.listaSemplice.Models;

namespace DeTommaso.Tommaso.J.listaSemplice
{
    class MainClass
    {
        public static Nodo[] RAM = new Nodo[1000];

        public static void Main(string[] args)
        {
            Lista lista = new Lista("hello world");

            for (int i = 0; i < lista.Lunghezza; i++)
                Console.WriteLine(lista[i].ToString());

        }
    }
}
