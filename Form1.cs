using Class;
using DataBase;

namespace Gestion_des_cartouches_d_ancres
{
    public partial class Form1 : Form
    {
        // declaration des variables globales.
        public string nomImprimante = String.Empty;
        // fin déclaration

        public Form1()
        {
            InitializeComponent();

            this.FormClosing += (s, e) => //quand la croix pour fermer la page est cliquer.
            {
                Program.listOpen[0] = false;
            };

            // déclaration des variable et liste.
            List<string> listeCorrespondante = new List<string>();



            // s'éxecute quand une touche est appuyer.
            txtimprim.KeyUp += (s, e) =>
            {
                if (txtimprim.Text != string.Empty)
                {
                    if (e.KeyValue == (char)Keys.Enter)
                    {
                        tlp.Controls.Clear(); //Supprime tous ce qui est afficher.
                        listeCorrespondante.Clear();
                        nomImprimante = txtimprim.Text.ToUpper(); //récupère le nom de l'imprimante entrer.
                        imprimanteCorrespondante(nomImprimante);
                    }
                }
            };
        }

        public void imprimanteCorrespondante(string nomImprimante)
        {
            // déclaration et initialisation des variables et listes.
            List<string> listeResultatImprimante = new List<string>();
            List<string> listeResultatNoir = new List<string>();
            List<string> listeResultatJaune = new List<string>();
            List<string> listeResultatMagenta = new List<string>();
            List<string> listeResultatCyan = new List<string>();

            List<Imprimante> listResultat = new List<Imprimante>();

            int nbLettre = nomImprimante.Length;
            string cache = "";
            // fin déclaration et initialisation.

            listeResultatImprimante.Add(""); //entete du .csv.
            listeResultatNoir.Add("");
            listeResultatJaune.Add("");
            listeResultatMagenta.Add("");
            listeResultatCyan.Add("");

            // cherche toutes les imprimantes du .csv correspondant au nom entrer.


            foreach (Imprimante printer in Bd.getImprimanteDist())
            {
                string nomPrinter = printer.getNom();
                if (nbLettre < nomPrinter.Length + 1)
                {
                    cache = nomPrinter.Substring(0, nbLettre);
                }
                if (cache == nomImprimante.ToUpper())
                {
                    List<Couleur> colors = new List<Couleur>();
                    foreach (Couleur color in printer.getListCouleurs())
                    {
                        colors.Add(color);
                    }
                    listResultat.Add(new Imprimante(printer.getId(), printer.getNom(), colors));
                }
            }
            setTlpTest(listResultat);
        }


        public void setTlpTest(List<Imprimante> listResultat)
        {
            tlp.RowCount = listResultat.Count +1;
            tlp.Size = new Size(593, 53 * tlp.RowCount);
            for (int i = 0; i < tlp.RowCount; i++)
            {
                tlp.RowStyles.Add(new RowStyle(SizeType.Absolute, 50));
            }

            Button btn = new Button();
            btn.Size = new Size(205, 35);
            btn.Text = "Nom imprimante";
            tlp.Controls.Add(btn, 0, 0);
            Button btn2 = new Button();
            btn2.Size = new Size(189, 35);
            btn2.Text = "Noir";
            tlp.Controls.Add(btn2, 1, 0);
            Button btn3 = new Button();
            btn3.Size = new Size(189, 35);
            btn3.Text = "Jaune";
            tlp.Controls.Add(btn3, 2, 0);
            Button btn4 = new Button();
            btn4.Size = new Size(189, 35);
            btn4.Text = "Magenta";
            tlp.Controls.Add(btn4, 3, 0);
            Button btn5 = new Button();
            btn5.Size = new Size(189, 35);
            btn5.Text = "Cyan";
            tlp.Controls.Add(btn5, 4, 0);

            int j = 1;
            foreach (Imprimante printer in listResultat)
            {
                string nomPrinter = printer.getNom();
                if (nomPrinter != "")
                {
                    Label lbl = new Label();
                    lbl.Size = new Size(200, 25);
                    lbl.Text = nomPrinter;
                    tlp.Controls.Add(lbl, 0, j);


                    foreach (Couleur color in printer.getListCouleurs())
                    {
                        switch (color.getCouleur())
                        {
                            case "Noir":
                                NumericUpDown nud1 = new NumericUpDown();//création de l'affichage des cartouches jaune.
                                nud1.Text = color.getQuantite().ToString();
                                tlp.Controls.Add(nud1, 1, j);
                                int idColor = color.getId();
                                nud1.ValueChanged += (s, e) =>//s'éxectute si la valeur d'une cartouche jaune est changer.
                                {
                                    Bd.UpdateQteCartById(color.getId(), int.Parse(nud1.Value.ToString()));
                                    //setNewStock(nud1, listResultat, numLigne, numTotal, newNbCartouche, 2);
                                };
                                break;
                            case "Jaune":
                                NumericUpDown nud2 = new NumericUpDown();//création de l'affichage des cartouches jaune.
                                nud2.Text = color.getQuantite().ToString();
                                tlp.Controls.Add(nud2, 2, j);
                                int idColor2 = color.getId();
                                nud2.ValueChanged += (s, e) =>//s'éxectute si la valeur d'une cartouche jaune est changer.
                                {
                                    Bd.UpdateQteCartById(color.getId(), int.Parse(nud2.Value.ToString()));
                                    //setNewStock(nud2, listResultat, numLigne, numTotal, newNbCartouche, 2);
                                };
                                break;
                            case "Magenta":
                                NumericUpDown nud3 = new NumericUpDown();//création de l'affichage des cartouches jaune.
                                nud3.Text = color.getQuantite().ToString();
                                tlp.Controls.Add(nud3, 3, j);
                                int idColor3 = color.getId();
                                nud3.ValueChanged += (s, e) =>//s'éxectute si la valeur d'une cartouche jaune est changer.
                                {
                                    Bd.UpdateQteCartById(color.getId(), int.Parse(nud3.Value.ToString()));
                                    //setNewStock(nud3, listResultat, numLigne, numTotal, newNbCartouche, 2);
                                };
                                break;
                            case "Cyan":
                                NumericUpDown nud4 = new NumericUpDown();//création de l'affichage des cartouches jaune.
                                nud4.Text = color.getQuantite().ToString();
                                tlp.Controls.Add(nud4, 4, j);
                                int idColor4 = color.getId();
                                nud4.ValueChanged += (s, e) =>//s'éxectute si la valeur d'une cartouche jaune est changer.
                                {
                                    Bd.UpdateQteCartById(color.getId(), int.Parse(nud4.Value.ToString()));
                                    //setNewStock(nud4, listResultat, numLigne, numTotal, newNbCartouche, 2);
                                };
                                break;
                            default:
                                break;
                        }
                    }
                    j++;
                }
            }
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}