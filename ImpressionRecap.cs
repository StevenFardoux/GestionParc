using Class;

namespace Gestion_des_cartouches_d_ancres
{
    public partial class ImpressionRecap : Form
    {
        Bitmap print;
        public ImpressionRecap()
        {
            InitializeComponent();

            setTlp(1);

            nud.ValueChanged += (s, e) => //change la page a afficher.
            {
                if (nud.Value == 1)
                {
                    setTlp(1);
                }
                else if (nud.Value == 2)
                {
                    setTlp(2);
                }
                else if (nud.Value == 3)
                {
                    setTlp(3);
                }
            };
        }

        public void setTlp(int value)
        {
            int compteur = 0;
            switch (value)
            {
                case 1:
                    compteur = 1;
                    break;
                case 2:
                    compteur = 31;

                    break;
                case 3:
                    compteur = 61;

                    break;
                default:
                    break;
            }

            tlp.Controls.Clear();
            tlp.RowCount = Program.listImprimante.Count + 1; // définis le nombre le ligne de l'affichage.
            tlp.Size = new Size(800, 33 * tlp.RowCount); // défini la taille des lignes existante.
            for (int i = compteur; i < tlp.RowCount; i++)
            {
                tlp.RowStyles.Add(new RowStyle(SizeType.Absolute, 30)); //défini la taille des nouvelles lignes.
            }


            Button btn1 = new Button();
            btn1.Size = new Size(248, 23);
            btn1.Text = "Nom imprimante";
            tlp.Controls.Add(btn1, 0, 0);

            Button btn2 = new Button();
            btn2.Size = new Size(121, 23);
            btn2.Text = "Noir";
            tlp.Controls.Add(btn2, 1, 0);

            Button btn3 = new Button();
            btn3.Size = new Size(121, 23);
            btn3.Text = "Jaune";
            tlp.Controls.Add(btn3, 2, 0);

            Button btn4 = new Button();
            btn4.Size = new Size(121, 23);
            btn4.Text = "Magenta";
            tlp.Controls.Add(btn4, 3, 0);

            Button btn5 = new Button();
            btn5.Size = new Size(121, 23);
            btn5.Text = "Cyan";
            tlp.Controls.Add(btn5, 4, 0);

            int j = 1;
            if (!(compteur >= Program.listImprimante.Count))
            {
                lblPage.Visible = false;
                foreach (Imprimante printer in Program.listImprimante)
                {
                    while (!(j >= compteur))
                    {
                        j++;
                    }

                    Label lbl2 = new Label();
                    lbl2.Size = new Size(200, 25);
                    lbl2.Text = printer.getNom();
                    tlp.Controls.Add(lbl2, 0, j);

                    foreach (Couleur color in printer.getListCouleurs())
                    {
                        Label lbl3 = new Label();
                        lbl3.Size = new Size(200, 25);
                        lbl3.Text = color.getQuantite().ToString();

                        switch (color.getCouleur())
                        {
                            case "Noir":
                                tlp.Controls.Add(lbl3, 1, j);
                                break;
                            case "Jaune":
                                tlp.Controls.Add(lbl3, 2, j);
                                break;
                            case "Magenta":
                                tlp.Controls.Add(lbl3, 3, j);
                                break;
                            case "Cyan":
                                tlp.Controls.Add(lbl3, 4, j);
                                break;
                            default:
                                break;
                        }
                    }
                    j++;
                }
            }
            else
            {
                lblPage.Visible = true;
            }
        }

        private void imprimerToolStripMenuItem_Click_1(object sender, EventArgs e) //creer un screen à imprimer.
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

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e) //imprime.
        {
            e.Graphics.DrawImage(print, 0, 0); 
        }
    }
}
