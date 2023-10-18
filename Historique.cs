using Class;
using DataBase;


namespace Gestion_des_cartouches_d_ancres
{
    public partial class Historique : Form
    {
        Bitmap print;

        public Historique()
        {
            InitializeComponent();

            setFlp();
        }

        public void setFlp()
        {
            flp.Controls.Clear();

            foreach (Classe salle in Program.listResultatSalle)
            {
                string nomSalle = salle.getNom();
                if (nomSalle != "")
                {
                    Button btn = new Button();
                    btn.Size = new Size(250, 23);
                    btn.Text = $"{nomSalle} - {salle.getImprimante().getNom()}";
                    flp.Controls.Add(btn);

                    btn.Click += (s, e) =>
                    {
                        flp.Visible = false;
                        lbTitre.Text = btn.Text;
                        lbTitre.Visible = true;
                        BtnReturn.Visible = true;
                        tlp.Visible = true;
                        setTlp(nomSalle);
                    };

                    BtnReturn.Click += (s, e) =>
                    {
                        flp.Visible = true;
                        lbTitre.Visible = false;
                        BtnReturn.Visible = false;
                        tlp.Visible = false;
                    };
                }
            }
        }
        public void setTlp(string nomSalle)
        {
            int idPrint = 0;
            foreach (Classe salle in Program.listResultatSalle)
            {
                if (salle.getNom() == nomSalle)
                {
                    idPrint = salle.getImprimante().getId();
                }
            }
            tlp.Controls.Clear();
            tlp.RowCount =  Bd.getMaxHsitoByIdPrint(idPrint) + 2; // définis le nombre le ligne de l'affichage.
            tlp.Size = new Size(809, 33 * tlp.RowCount); // défini la taille des lignes existante.
            for (int i = 0; i < tlp.RowCount; i++)
            {
                tlp.RowStyles.Add(new RowStyle(SizeType.Absolute, 30)); //défini la taille des nouvelles lignes.
            }

            Button btn = new Button();
            btn.Size = new Size(189, 35);
            btn.Text = "Noir";
            tlp.Controls.Add(btn, 0, 0);

            Button btn1 = new Button();
            btn1.Size = new Size(189, 35);
            btn1.Text = "Jaune";
            tlp.Controls.Add(btn1, 1, 0);

            Button btn2 = new Button();
            btn2.Size = new Size(189, 35);
            btn2.Text = "Magenta";
            tlp.Controls.Add(btn2, 2, 0);

            Button btn3 = new Button();
            btn3.Size = new Size(189, 35);
            btn3.Text = "Cyan";
            tlp.Controls.Add(btn3, 3, 0);

            int j = 1;
            foreach (Classe salle in Program.listResultatSalle)
            {
                if (nomSalle == salle.getNom())
                {
                    foreach (Couleur color in salle.getImprimante().getListCouleurs())
                    {
                        int moyenne = Bd.getstatCartoucheById(salle.getImprimante().getId(), color.getId());
                        Label lbl = new Label();
                        lbl.Size = new Size(250, 35);
                        lbl.Text = (moyenne != 0) ? $"La cartouche est à changer environ tous les {moyenne} mois" : "La cartouche est trop récente pour donnée ces informations";
                        switch (color.getCouleur())
                        {
                            case "Noir":
                                tlp.Controls.Add(lbl, 0, j);
                                break;
                            case "Jaune":
                                tlp.Controls.Add(lbl, 1, j);
                                break;
                            case "Magenta":
                                tlp.Controls.Add(lbl, 2, j);
                                break;
                            case "Cyan":
                                tlp.Controls.Add(lbl, 3, j);
                                break;
                            default:
                                break;
                        }
                        j++;
                        foreach (DateTime date in color.getListHisto())
                        {
                            DateTimePicker dtp = new DateTimePicker();
                            dtp.Text = date.ToString("dd-MM-yyyy");
                            dtp.ValueChanged += (s, e) =>
                            {
                                dtp.Text = date.ToString("dd-MM-yyyy");
                            };
                            switch (color.getCouleur())
                            {
                                case "Noir":
                                     tlp.Controls.Add(dtp, 0, j);
                                    break;
                                case "Jaune":
                                    tlp.Controls.Add(dtp, 1, j);
                                    break;
                                case "Magenta":
                                    tlp.Controls.Add(dtp, 2, j);
                                    break;
                                case "Cyan":
                                    tlp.Controls.Add(dtp, 3, j);
                                    break;
                                default:
                                    break;
                            }
                            j++;
                        }
                        j = 1;
                    }
                }
            }
        }

        private void imprimerToolStripMenuItem_Click(object sender, EventArgs e) //creer un screen à imprimer.
        {
            Graphics gps = this.CreateGraphics();
            Size s = this.Size;
            print = new Bitmap(s.Width, s.Height, gps);
            Graphics screen = Graphics.FromImage(print);
            screen.CopyFromScreen(this.Location.X, this.Location.Y, -10, 10, s);
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
            printDialog1.Document = printDocument1;

        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e) => //imprime.
            e.Graphics.DrawImage(print, 0, 0);

        private void actualiserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setFlp();
            flp.Visible = true;
            lbTitre.Visible = false;
            BtnReturn.Visible = false;
            tlp.Visible = false;
        }
    }
}