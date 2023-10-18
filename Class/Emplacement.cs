using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class
{
    public class Emplacement
    {
        private int id;
        private string etagere;
        private int numero;

        public Emplacement(int id, string etagere, int numero)
        {
            this.id = id;
            this.etagere = etagere;
            this.numero = numero;
        }

        public int getId()
        {
            return id;
        }
        public void setId(int id)
        {
            this.id = id;
        }

        public string getEtagere()
        {
            return etagere;
        }
        public void setEtagere(string etagere)
        {
            this.etagere = etagere;
        }

        public int getNumero()
        {
            return numero;
        }
        public void setNumero(int numero)
        {
            this.numero = numero;
        }
    }
}
