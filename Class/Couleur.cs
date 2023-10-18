
namespace Class
{
    public class Couleur
    {
        private int id;
        private string nom;
        private string couleur;
        private int quantite;
        private List<DateTime> histoChangement;
        private List<Livraison> histoLivraison;
        private Emplacement emplacement;

        public Couleur(int id, string nom, string couleur, int quantite)
        {
            this.id = id;
            this.nom = nom;
            this.couleur = couleur;
            this.quantite = quantite;
        }
        public Couleur(int id, string nom, string couleur, List<DateTime> histoChangement)
        {
            this.id = id;
            this.nom = nom;
            this.couleur = couleur;
            this.histoChangement = histoChangement;
        }
        public Couleur(int id, string nom, string couleur, int quantite, List<DateTime> histoChangement)
        {
            this.id = id;
            this.nom = nom;
            this.couleur = couleur;
            this.quantite = quantite;
            this.histoChangement = histoChangement;
        }
        public Couleur(int id, string nom, string couleur, int quantite, List<Livraison> list) 
        {
            this.id = id;
            this.nom = nom;
            this.couleur = couleur;
            this.quantite = quantite;
            this.histoLivraison = list; 
        }

        public Couleur(int id, string nom, string couleur, int quantite, Emplacement emplacement)
        {
            this.id = id;
            this.nom = nom;
            this.couleur = couleur;
            this.quantite = quantite;
            this.emplacement = emplacement;
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
        public void setNom(string nom)
        {
            this.nom = nom;
        }

        public string getCouleur()
        {
            return this.couleur;
        }
        public void setCouleur(string couleur)
        {
            this.couleur = couleur;
        }


        public int getQuantite()
        {
            return this.quantite;
        }
        public void setQuantite(int quant)
        {
            this.quantite = quant;
        }


        public List<DateTime> getListHisto()
        {
            return this.histoChangement;
        }
        public void setListHisto(List<DateTime> list)
        {
            this.histoChangement = list;
        }
        public void addHisto(DateTime date)
        {
            this.histoChangement.Add(date);
        }

        public List<Livraison> getListLivraison()
        {
            return this.histoLivraison;
        }
        public void setListLivraison(List<Livraison> list) 
        {
            this.histoLivraison = list;
        }
        public void addLivraison(Livraison livraison)
        {
            histoLivraison.Add(livraison);
        }

        public Emplacement getEmplacement()
        {
            return this.emplacement;
        }
        public void setEmplacement(Emplacement empl)
        {
            this.emplacement = empl;
        }

    }
}
