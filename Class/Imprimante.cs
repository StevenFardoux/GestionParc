
namespace Class
{
    public class Imprimante
    {
        private static int nbImprimante;
        private int id;
        private string nom;
        private List<Couleur> listCouleurs;

        public Imprimante(int id, string nom)
        {
            this.id = id;
            this.nom = nom;
            nbImprimante++;
        }
        public Imprimante(int id, string nom, List<Couleur> listCouleurs)
        {
            this.id = id;
            this.nom = nom;
            this.listCouleurs = listCouleurs;
            nbImprimante++;
        }

        public string getNom()
        {
            return this.nom;
        }
        public void setNom(string nom)
        {
            this.nom = nom;
        }


        public int getId()
        {
            return this.id;
        }
        public void setId(int id)
        {
            this.id = id;
        }


        public List<Couleur> getListCouleurs()
        {
            return this.listCouleurs;
        }
        public void setListCouleurs(List<Couleur> list)
        {
            this.listCouleurs = list;
        }


        public void addToList(Couleur couleur)
        {
            this.listCouleurs.Add(couleur);
        } 


        public static int getNbImprimante()
        {
            return nbImprimante;
        }
    }
}