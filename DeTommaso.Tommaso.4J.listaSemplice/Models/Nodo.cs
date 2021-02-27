using System;
namespace DeTommaso.Tommaso.J.listaSemplice.Models
{
    public class Nodo
    {
        private int indSx; //Indirizzo elemento sinistro
        public int IndSx { get => indSx; set => indSx = value; }
        private int indDx; //Indirizzo elemento destro
        public int IndDx { get => indDx; set => indDx = value; }

        private char dato;
        public char Dato { get => dato; set => dato = value; }

        public Nodo(char _dato, int _indSx, int _indDx)
        {
            Dato = _dato;
            IndSx = _indSx;
            IndDx = _indDx;
        }

        public override string ToString()
        {
            return "[" + indSx + ", " + indDx + "] - " + Dato;
        }
    }
}
