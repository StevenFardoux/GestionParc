using DataBase;
using Class;
using Timer = System.Windows.Forms.Timer;
using System.Diagnostics;
using System.Net.NetworkInformation;

namespace Gestion_des_cartouches_d_ancres
{
    public partial class empreint : Form
    {
        bool nomOK = true;
        List<Empreint> listEmpreint = new List<Empreint>();
        public empreint()
        {
            InitializeComponent();


            Timer blinkTimer = new Timer();
            blinkTimer.Interval = 500; // changer la couleur toutes les 500ms
            blinkTimer.Tick += new EventHandler(BlinkTextBox);
            blinkTimer.Start();

            this.FormClosing += (s, e) =>
            {
                Program.listOpen[7] = false;
            };

            btnAdd.Click += (s, e) =>
            {
                if (txtNom.Text.Trim() == "")
                {
                    nomOK = false;
                }
                if (nomOK)
                {
                    Bd.insertNewEmpreint(new Empreint(1, txtNom.Text, int.Parse(nudQte.Value.ToString()), DateTime.Parse(dtpEmpreint.Text), DateTime.Parse(dtpRetour.Text)));
                    setTlp();
                }
            };

            txtNom.KeyPress += (s, e) =>
            {
                if (!nomOK)
                {
                    nomOK = true;
                }
            };

            setTlp();
        }

        public void setTlp()
        {
            tlp.Controls.Clear();
            listEmpreint = Bd.getEmpreint();
            int nbRow = listEmpreint.Count + 1;
            tlp.RowCount = nbRow;   
            tlp.Size = new Size(569, 37 * nbRow);
            for (int i = 0; i < tlp.RowCount; i++)
            {
                tlp.RowStyles.Add(new RowStyle(SizeType.Absolute, 35));
            }

            Button btnEntete = new Button();
            btnEntete.Size = new Size(189, 35);
            btnEntete.Text = "nom";
            tlp.Controls.Add(btnEntete, 0, 0);

            Button btnEntete2 = new Button();
            btnEntete2.Size = new Size(189, 35);
            btnEntete2.Text = "quantité";
            tlp.Controls.Add(btnEntete2, 1, 0);

            Button btnEntete3 = new Button();
            btnEntete3.Size = new Size(189, 35);
            btnEntete3.Text = "date de l'empreint";
            tlp.Controls.Add(btnEntete3, 2, 0);

            Button btnEntete4 = new Button();
            btnEntete4.Size = new Size(189, 35);
            btnEntete4.Text = "date de retour";
            tlp.Controls.Add(btnEntete4, 3, 0);

            int j = 1;
            foreach (Empreint empreint in listEmpreint)
            {
                Label lbl1 = new Label();
                lbl1.Size = new Size(200, 25);
                lbl1.Text = empreint.getNomObject();
                tlp.Controls.Add(lbl1, 0, j);

                Label lbl2 = new Label();
                lbl2.Size = new Size(200, 25);
                lbl2.Text = empreint.getQuantite().ToString();
                tlp.Controls.Add(lbl2, 1, j);

                DateTimePicker dtp = new DateTimePicker();
                dtp.Size = new Size(200, 25);
                dtp.Text = empreint.getDateEmpreint().ToString("dd-MM-yyyy");
                dtp.ValueChanged += (s, e) =>
                {
                    dtp.Text = empreint.getDateEmpreint().ToString("dd-MM-yyyy");
                };
                tlp.Controls.Add(dtp, 2, j);

                DateTimePicker dtp2 = new DateTimePicker();
                dtp2.Size = new Size(200, 25);
                dtp2.Text = empreint.getDateRetour().ToString("dd-MM-yyyy");
                dtp2.ValueChanged += (s, e) =>
                {
                    dtp2.Text = empreint.getDateRetour().ToString("dd-MM-yyyy");
                };
                tlp.Controls.Add(dtp2, 3, j);

                Button btn = new Button();
                btn.Size = new Size(200, 25);
                btn.Text = "Supprimer";
                btn.Click += (s, e) =>
                {
                    Bd.delEmpreint(empreint.getId());
                    setTlp();
                };
                tlp.Controls.Add(btn, 4, j);
                j++;
            }
        }

        private void BlinkTextBox(object sender, EventArgs e)
        {
            if (!nomOK)
            {
                if (txtNom.BackColor == Color.White)
                {
                    txtNom.BackColor = Color.Red;
                    lblWarning.Visible = true;
                    lblWarning.ForeColor = Color.Red;
                }
                else
                {
                    txtNom.BackColor = Color.White;
                    lblWarning.ForeColor = Color.Black;
                }
            }
            else
            {
                txtNom.BackColor = Color.White;
                lblWarning.Visible = false;
                lblWarning.ForeColor = Color.Black;
            }

        }

        private void empreint_Load(object sender, EventArgs e)
        {

               

        }
    }
}
