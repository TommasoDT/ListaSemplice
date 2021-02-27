using System;
namespace DeTommaso.Tommaso.J.listaSemplice.Models
{
    public class Lista
    {
        private int indFirst;

        public int Lunghezza
        {
            get
            {
                Nodo nodo = MainClass.RAM[indFirst];
                int lunghezza = 1;
                while (nodo.IndDx != -1)
                {
                    nodo = MainClass.RAM[nodo.IndDx];
                    lunghezza++;
                }
                return lunghezza;
            }
        }

        public Lista(string testo)
        {
            int indPrimoNodo = FindPosInRAM();
            indFirst = indPrimoNodo;
            int indSecondoNodo = FindPosInRAM();
            MainClass.RAM[indFirst] = new Nodo(testo[0], -1, indSecondoNodo);
            MainClass.RAM[indSecondoNodo] = new Nodo(testo[1], indFirst, -1);
            for (int i = 2; i < testo.Length; i++)
                InserisciNodoInCoda(testo[i]);
        }

        public ref Nodo this[int pos]
        {
            get
            {
                int indDxNodo = this[0].IndDx;
                for (int i = 0; i < pos; i++)
                    indDxNodo = this[indDxNodo].IndDx;
                return ref this[indDxNodo];
            }
        }

        public int GetIndNodo(int posNodo)
        {
            for (int i = 0; i < Lunghezza; i++)
                if (i + 1 == posNodo)
                    return this[i].IndDx;
            return -1;
        }

        public int FindPosInRAM()
        {
            int tentativi = 0;

            Random random = new Random();
            int indNuovoNodo;

            do
            {
                indNuovoNodo = random.Next(1, MainClass.RAM.Length);
                tentativi++;
            }
            while (MainClass.RAM[indNuovoNodo] != null || tentativi > MainClass.RAM.Length);

            return indNuovoNodo;
        }

        public void InserisciNodoInTesta(char dato)
        {
            int indNuovoNodo = FindPosInRAM();

            MainClass.RAM[indNuovoNodo] = new Nodo(dato, GetIndNodo(0), -1); //Il puntatore destra del nuovo nodo punta al primo nodo
            this[indFirst].IndSx = indNuovoNodo; //Il puntatore sinistra del primo nodo punta al nuovo nodo
            this.indFirst = indNuovoNodo; //Il puntatore della lista al primo nodo ora punta al nuovo primo nodo
        }

        public void InserisciNodoInCoda(char dato)
        {
            int indNuovoNodo = FindPosInRAM();

            MainClass.RAM[indNuovoNodo] = new Nodo(dato, GetIndNodo(Lunghezza - 1), -1); //Il puntatore sinistra del nuovo nodo punta all'ultimo nodo
            this[Lunghezza - 1].IndDx = indNuovoNodo; //Il puntatore destra dell'ultimo nodo punta al nuovo nodo
        }

        public void InserisciNodoAllaPosizione(char _dato, int pos)
        {
            int indNuovoNodo = FindPosInRAM();

            MainClass.RAM[indNuovoNodo] = new Nodo(_dato, GetIndNodo(pos - 1), GetIndNodo(pos)); //Il puntatore sinistra del nuovo nodo punta all'indirizzo del nodo precedente alla posizione richiesta e il puntatore destra punta all'indirizzo del nodo alla posizione richiesta 
            this[pos].IndSx = indNuovoNodo; //Il puntatore sinistra del nodo alla posizione richiesta punta al nuovo nodo
            this[pos - 1].IndDx = indNuovoNodo; //Il puntatore destra del nodo precedente punta al nuovo nodo
        }

        public void CancellaNodoAllaPosizione(int pos)
        {
            int indNodoDaCancellare = GetIndNodo(pos); //Salvo la posizione in ram del nodo da cancellare
            this[pos - 1].IndDx = GetIndNodo(pos + 1); //Avendo puntato il puntatore destra del nodo precedente di quello da eliminare a quello successivo
            this[pos].IndSx = GetIndNodo(pos - 1); //il nodo successivo è diventato quello da eliminare, quindi il puntatore sinistra del nodo alla posizione di quello da eliminare punta al nodo precedente 
            MainClass.RAM[indNodoDaCancellare] = null; //Cancello il nodo, ora scollegato dalla lista, con la posizione salvata precedentemente
        }
    }
}
