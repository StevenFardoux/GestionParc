using Class;
using DataBase;

namespace Gestion_des_cartouches_d_ancres
{
    public partial class gestionChangementCartouches : Form
    {
        // déclaration et initialisation des listes et variables globales.
        public List<string> listeCorrespondante = new List<string>();
        public string nomSalle = "";
        // fin.

        public gestionChangementCartouches()
        {
            InitializeComponent();

            this.FormClosing += (s, e) => //quand la croix pour fermer la page est cliquer.
            {
                Program.listOpen[2] = false;
            };

            txtSalle.KeyUp += (s, e) => // quand une touche est appuyer.
            {
                if (txtSalle.Text != string.Empty)
                {
                    if (e.KeyValue == (char)Keys.Enter) //si la touche et la touche entrer alors...
                    {
                        tlp.Controls.Clear(); //Supprime tous ce qui est afficher.
                        listeCorrespondante.Clear();
                        nomSalle = txtSalle.Text.ToUpper(); //récupère le nom de l'imprimante entrer.
                        salleCorrespondante(nomSalle);
                    }
                }
            };
        }

        public void salleCorrespondante(string nomSalle)
        {
            // déclaration et initialisation des variables et listes.
            int nbLettre = nomSalle.Length;
            string cache = "";
            // fin déclaration et initialisation.

            Program.listResultatSalle.Clear();

            Program.listResultatSalle.Add(new Classe(0, "")); //entete du .csv.



            foreach (Classe salle in Bd.getSalle())
            { 
                string nameSalle = salle.getNom();
                if (nbLettre < nameSalle.Length + 1)
                {
                    cache = nameSalle.Substring(0, nbLettre);
                }
                if (cache == nomSalle)
                {
                    Program.listResultatSalle.Add(salle);
                }
            }
            setTlp();
        }

        public void setTlp()
        {
            tlp.RowCount = Program.listResultatSalle.Count + 1; // définis le nombre le ligne de l'affichage.
            tlp.Size = new Size(819, 53 * tlp.RowCount); // défini la taille des lignes existante.
            for (int i = 0; i < tlp.RowCount; i++)
            {
                tlp.RowStyles.Add(new RowStyle(SizeType.Absolute, 50)); //défini la taille des nouvelles lignes.
            }

            // création de l'entete du tableau.
            Button btn = new Button();
            btn.Size = new Size(205, 35);
            btn.Text = "Salle";
            tlp.Controls.Add(btn, 0, 0);

            Button btn1 = new Button();
            btn1.Size = new Size(205, 35);
            btn1.Text = "Nom imprimante";
            tlp.Controls.Add(btn1, 1, 0);

            Button btn2 = new Button();
            btn2.Size = new Size(189, 35);
            btn2.Text = "Noir";
            tlp.Controls.Add(btn2, 2, 0);

            Button btn3 = new Button();
            btn3.Size = new Size(189, 35);
            btn3.Text = "Jaune";
            tlp.Controls.Add(btn3, 3, 0);

            Button btn4 = new Button();
            btn4.Size = new Size(189, 35);
            btn4.Text = "Magenta";
            tlp.Controls.Add(btn4, 4, 0);

            Button btn5 = new Button();
            btn5.Size = new Size(189, 35);
            btn5.Text = "Cyan";
            tlp.Controls.Add(btn5, 5, 0);

            int j = 0;
            foreach (Classe salle in Program.listResultatSalle)
            {
                string nomSalle = salle.getNom();
                if (nomSalle != "")
                {
                    Label lbl = new Label();
                    lbl.Size = new Size(200, 25);
                    lbl.Text = nomSalle;
                    tlp.Controls.Add(lbl, 0, j);

                    Label lbl1 = new Label();
                    lbl1.Size = new Size(200, 25);
                    lbl1.Text = salle.getImprimante().getNom();
                    tlp.Controls.Add(lbl1, 1, j);


                    foreach (Couleur color in salle.getImprimante().getListCouleurs())
                    {

                        DateTimePicker dtp = new DateTimePicker();
                        dtp.Text = color.getListHisto()[color.getListHisto().Count - 1].ToString("dd-MM-yyyy");

                        switch (color.getCouleur())
                        {
                            case "Noir":
                                tlp.Controls.Add(dtp, 2, j);
                                break;
                            case "Jaune":
                                tlp.Controls.Add(dtp, 3, j);
                                break;
                            case "Magenta":
                                tlp.Controls.Add(dtp, 4, j);
                                break;
                            case "Cyan":
                                tlp.Controls.Add(dtp, 5, j);
                                break;
                            default:
                                break;
                        }
                        dtp.ValueChanged += (s, e) =>
                        {
                            Bd.insertNewdateChangement(salle.getImprimante().getId(), color.getId(), dtp.Value);
                        };
                    }
                }
                j++;
            }

        }
        private void btnPrint_Click_1(object sender, EventArgs e)
        {
            ImpressionSalle impS = new ImpressionSalle();
            impS.Show(); //affiche la page impressionSalle.
            
        }

        private void btnhisto_Click(object sender, EventArgs e)
        {
            Historique histo = new Historique();
            histo.Show(); //affiche la page historique.
        }
    }
}
