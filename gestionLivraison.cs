using Class;
using DataBase;
using Timer = System.Windows.Forms.Timer;

namespace Gestion_des_cartouches_d_ancres
{
    public partial class gestionLivraison : Form
    {
        private bool nomOk = true;
        public gestionLivraison()
        {
            InitializeComponent();

            Timer blinkTimer = new Timer();
            blinkTimer.Interval = 500; // changer la couleur toutes les 500ms
            blinkTimer.Tick += new EventHandler(BlinkTextBox);
            blinkTimer.Start();

            this.FormClosing += (s, e) => //quand la croix pour fermer la page est cliquer.
            {
                Program.listOpen[3] = false;
            };

            foreach (string nomCart in Bd.getNomCart())
            {
                cbbCart.Items.Add(nomCart);
            }

            cbbCart.Click += (s, e) =>
            {
                nomOk = true;
            };

            setTlp();
        }

        public void setTlp()
        {
            tlp.Controls.Clear();
            Program.listLivraison = Bd.getLivraison();
            tlp.RowCount = Program.listLivraison.Count + 1; // définis le nombre le ligne de l'affichage.
            tlp.Size = new Size(697, 53 * tlp.RowCount);// défini la taille des lignes existante.
            for (int i = 0; i < tlp.RowCount; i++)
            {
                tlp.RowStyles.Add(new RowStyle(SizeType.Absolute, 50)); //défini la taille des nouvelles lignes.
            }

            // création de l'entete du tableau.
            Button btn = new Button();
            btn.Size = new Size(205, 35);
            btn.Text = "Nom Cartouche";
            tlp.Controls.Add(btn, 0, 0);

            Button btn1 = new Button();
            btn1.Size = new Size(205, 35);
            btn1.Text = "quantité Commander";
            tlp.Controls.Add(btn1, 1, 0);

            Button btn2 = new Button();
            btn2.Size = new Size(189, 35);
            btn2.Text = "date Commande";
            tlp.Controls.Add(btn2, 2, 0);

            Button btn3 = new Button();
            btn3.Size = new Size(189, 35);
            btn3.Text = "date Livraison";
            tlp.Controls.Add(btn3, 3, 0);

            int j = 1;
            string nomCart = "";
            foreach (Couleur color in Program.listLivraison)
            {
                if (nomCart != color.getNom())
                {
                    Label lbl = new Label();
                    lbl.Size = new Size(200, 25);
                    lbl.Text = color.getNom();
                    tlp.Controls.Add(lbl, 0, j);

                    foreach (Livraison del in color.getListLivraison())
                    {
                        Label lbl2 = new Label();
                        lbl2.Size = new Size(200, 25);
                        lbl2.Text = del.getQuantiteCommande().ToString();
                        tlp.Controls.Add(lbl2, 1, j);

                        DateTimePicker dtp = new DateTimePicker();
                        dtp.Text = del.getDatecommande().ToString("dd-MM-yyyy");
                        tlp.Controls.Add(dtp, 2, j);
                        dtp.ValueChanged += (s, e) =>
                        {
                            dtp.Text = del.getDatecommande().ToString("dd-MM-yyyy");
                        };

                        DateTimePicker dtp2 = new DateTimePicker();
                        dtp2.Text = del.getDateLivraison().ToString("dd-MM-yyyy");
                        tlp.Controls.Add(dtp2, 3, j);
                        dtp2.ValueChanged += (s, e) =>
                        {
                            dtp2.Text = del.getDateLivraison().ToString("dd-MM-yyyy");
                        };
                    }
                    nomCart = color.getNom();
                    j++;
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (cbbCart.Text.Trim() == "")
            {
                nomOk = false;
            }

            if (nomOk)
            {
                Bd.insertNewLivraison(cbbCart.Text, int.Parse(nudQte.Value.ToString()), dtpCommande.Value, dtpLivraison.Value);
                setTlp();
            }
        }

        private void btnHisto_Click(object sender, EventArgs e)
        {
            histoLivraison histo = new histoLivraison();
            histo.Show();
        }

        private void BlinkTextBox(object sender, EventArgs e)
        {
            if (!nomOk)
            {
                if (cbbCart.BackColor == Color.White)
                {
                    cbbCart.BackColor = Color.Red;
                    lblWarning.Visible = true;
                    lblWarning.ForeColor = Color.Red;
                }
                else
                {
                    cbbCart.BackColor = Color.White;
                    lblWarning.ForeColor = Color.Black;
                }
            }
            else
            {
                cbbCart.BackColor = Color.White;
                lblWarning.Visible = false;
                lblWarning.ForeColor = Color.Black;
            }

        }
    }
}
