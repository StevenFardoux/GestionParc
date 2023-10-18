
namespace Class
{
    public class Livraison
    {
        private int idLivr;
        private string nomCart;
        private int quantiteCommande;
        private DateTime dateCommande;
        private DateTime dateLivraison;

        public Livraison(int idLivr, string nomCart, int quantite, DateTime dateCommande, DateTime dateLivraison)
        {
            this.idLivr = idLivr;
            this.nomCart = nomCart;
            this.quantiteCommande = quantite;
            this.dateCommande = dateCommande;
            this.dateLivraison = dateLivraison;
        }

        public int getIdLivr()
        {
            return this.idLivr;
        }
        public void setIdLivr(int idLivr)
        {
            this.idLivr = idLivr;
        }

        public string getNomCart()
        {
            return this.nomCart;
        }
        public void setNOmCart(string nom)
        {
            this.nomCart = nom;
        }

        public int getQuantiteCommande()
        {
            return this.quantiteCommande;
        }
        public void setQuantiteCommande(int quantite)
        {
            this.quantiteCommande = quantite;
        }

        public DateTime getDatecommande()
        {
            return this.dateCommande;
        }
        public void setDateCommande(DateTime date)
        {
            this.dateCommande = date;
        }

        public DateTime getDateLivraison()
        {
            return this.dateLivraison;
        }
        public void setDateLivraison(DateTime date)
        {
            this.dateLivraison = date;
        }
    }
}
