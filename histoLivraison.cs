using Class;
using DataBase;

namespace Gestion_des_cartouches_d_ancres
{
    public partial class histoLivraison : Form
    {
        Bitmap print;

        public histoLivraison()
        {
            InitializeComponent();

            setFlp();

        }

        public void setFlp()
        {
            flp.Controls.Clear();

            string nomCartCache = "";
            foreach (Couleur color in Program.listLivraison)
            {
                string nomCart = color.getNom();
                if (nomCart != nomCartCache)
                {
                    Button btn = new Button();
                    btn.Size = new Size(250, 23);
                    btn.Text = nomCart;
                    flp.Controls.Add(btn);

                    btn.Click += (s, e) =>
                    {
                        flp.Visible = false;
                        lbTitre.Text = btn.Text;
                        lbTitre.Visible = true;
                        BtnReturn.Visible = true;
                        tlp.Visible = true;
                        setTlp(nomCart);
                    };

                    BtnReturn.Click += (s, e) =>
                    {
                        flp.Visible = true;
                        lbTitre.Visible = false;
                        BtnReturn.Visible = false;
                        tlp.Visible = false;
                    };
                    nomCartCache = nomCart;
                }
            }
        }
        public void setTlp(string nomCartouche)
        {
            int idCart = 0;
            foreach (Couleur color in Bd.getCartouche())
            {
                if (color.getNom() == nomCartouche)
                {
                    idCart = color.getId();
                }
            }


            tlp.Controls.Clear();
            tlp.RowCount = Bd.getMaxHistoLivraisonById(idCart) + 1; // définis le nombre le ligne de l'affichage.
            tlp.Size = new Size(809, 33 * tlp.RowCount); // défini la taille des lignes existante.
            for (int i = 0; i < tlp.RowCount; i++)
            {
                tlp.RowStyles.Add(new RowStyle(SizeType.Absolute, 30)); //défini la taille des nouvelles lignes.
            }

            Button btn = new Button();
            btn.Size = new Size(189, 35);
            btn.Text = "quantité commander";
            tlp.Controls.Add(btn, 0, 0);

            Button btn1 = new Button();
            btn1.Size = new Size(189, 35);
            btn1.Text = "date de commande";
            tlp.Controls.Add(btn1, 1, 0);

            Button btn2 = new Button();
            btn2.Size = new Size(189, 35);
            btn2.Text = "date de livraison";
            tlp.Controls.Add(btn2, 2, 0);

            int j = 1;
            foreach (Couleur color in Program.listLivraison)
            {
                if (nomCartouche == color.getNom())
                {
                    foreach (Livraison del in color.getListLivraison())
                    {
                        Label lbl2 = new Label();
                        lbl2.Size = new Size(200, 25);
                        lbl2.Text = del.getQuantiteCommande().ToString();
                        tlp.Controls.Add(lbl2, 0, j);

                        DateTimePicker dtp = new DateTimePicker();
                        dtp.Text = del.getDatecommande().ToString("dd-MM-yyyy");
                        tlp.Controls.Add(dtp, 1, j);
                        dtp.ValueChanged += (s, e) =>
                        {
                            dtp.Text = del.getDatecommande().ToString("dd-MM-yyyy");
                        };

                        DateTimePicker dtp2 = new DateTimePicker();
                        dtp2.Text = del.getDateLivraison().ToString("dd-MM-yyyy");
                        tlp.Controls.Add(dtp2, 2, j);
                        dtp2.ValueChanged += (s, e) =>
                        {
                            dtp2.Text = del.getDateLivraison().ToString("dd-MM-yyyy");
                        };
                    }
                    j++;
                }
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

        private void actualiserToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            setFlp();
            flp.Visible = true;
            lbTitre.Visible = false;
            BtnReturn.Visible = false;
            tlp.Visible = false;
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e) => // imprime.
            e.Graphics.DrawImage(print, 0, 0);    
    }
}
