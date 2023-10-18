
namespace Class
{
    public class Classe
    {
        public static int nbClasse;
        private int id;
        private string nom;
        private Imprimante printer;

        public Classe(int id, string nom, Imprimante printer)
        {
            this.id = id;
            this.nom = nom;
            this.printer = printer;
            nbClasse++;
        }
        public Classe(int id, string nom)
        {
            this.id = id;
            this.nom = nom;
        }

        public int getId()
        {
            return id;
        }
        public void setId(int id)
        {
            this.id = id;
        } 

        public string getNom()
        {
            return this.nom;
        }
        public void setNOm(string nom)
        {
            this.nom = nom;
        }


        public Imprimante getImprimante()
        {
            return this.printer;
        }
        public void setImpriamante(Imprimante list)
        {
            this.printer = printer;
        }


        public static int getNbClasse()
        {
            return nbClasse;
        }

    }
}
