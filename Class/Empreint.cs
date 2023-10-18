namespace Class
{
    public class Empreint
    {
        private int id;
        private string nomObject;
        private int quantite;
        private DateTime dateEmpreint;
        private DateTime dateRetour;

        public Empreint(int id, string nomObject, int quantite, DateTime dateEmpreint, DateTime dateRetour)
        {
            this.id = id;
            this.nomObject = nomObject;
            this.quantite = quantite;
            this.dateEmpreint = dateEmpreint;
            this.dateRetour = dateRetour;
        }

        public int getId() 
        {
            return id; 
        }
        public void setID(int id)
        {
            this.id = id;
        }

        public string getNomObject()
        {
            return nomObject;
        }
        public void setNomObject(string nomObject)
        {
            this.nomObject = nomObject;
        }

        public int getQuantite()
        {
            return quantite;
        }
        public void setQuantite(int quantite)
        {
            this.quantite = quantite;
        }

        public DateTime getDateEmpreint()
        {
            return dateEmpreint;
        }
        public void setDateEmpreint(DateTime dateEmpreint)
        {
            this.dateEmpreint = dateEmpreint;
        }

        public DateTime getDateRetour()
        {
            return dateRetour;
        }
        public void setDateRetour(DateTime dateRetour)
        {
            this.dateRetour = dateRetour;
        }
    }
}
