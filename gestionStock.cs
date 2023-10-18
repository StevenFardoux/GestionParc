using Class;
using DataBase; 

namespace Gestion_des_cartouches_d_ancres
{
    public partial class gestionStock : Form
    {
        List<Couleur> listColor = new List<Couleur>();
        public gestionStock()
        {
            InitializeComponent();

            this.FormClosing += (s, e) =>
            {
                Program.listOpen[6] = false;
            };

            listColor = Bd.getCartoucheWithEmpl();
            foreach (Couleur color in listColor)
            {
                cbbNom.Items.Add(color.getNom());
            }

            cbbNom.TextChanged += (s, e) =>
            {
                if (cbbNom.Text.Trim() != "")
                {
                    setTlpByName(cbbNom.Text.Trim());
                }
            };

            setTlp();
        }

        public void setTlp()
        {
            tlp.Controls.Clear();

            tlp.RowCount = listColor.Count + 1;
            tlp.Size = new Size(760, 53 * tlp.RowCount);

            for (int i = 0; i < tlp.RowCount; i++)
            {
                tlp.RowStyles.Add(new RowStyle(SizeType.Absolute, 35));
            }


            Button btnEntete = new Button();
            btnEntete.Size = new Size(189, 31);
            btnEntete.Text = "Nom de la cartouche";
            tlp.Controls.Add(btnEntete, 0, 0);

            Button btnEntete2 = new Button();
            btnEntete2.Size = new Size(189, 31);
            btnEntete2.Text = "Etagère";
            tlp.Controls.Add(btnEntete2, 1, 0);

            Button btnEntete3 = new Button();
            btnEntete3.Size = new Size(189, 31);
            btnEntete3.Text = "Numéro";
            tlp.Controls.Add(btnEntete3, 2, 0);

            int j = 1;
            foreach (Couleur color in listColor)
            {
                Button btn = new Button();
                btn.Size = new Size(189, 31);
                btn.Text = color.getNom();
                tlp.Controls.Add(btn, 0, j);

                Button btn2 = new Button();
                btn2.Size = new Size(189, 31);
                btn2.Text = color.getEmplacement().getEtagere();
                tlp.Controls.Add(btn2, 1, j);

                Button btn3 = new Button();
                btn3.Size = new Size(189, 31);
                btn3.Text = color.getEmplacement().getNumero().ToString();
                tlp.Controls.Add(btn3, 2, j);
                j++;
            }
        }

        public void setTlpByName(string nom)
        {
            tlp.Controls.Clear();

            tlp.RowCount = listColor.Count + 1;
            tlp.Size = new Size(760, 71);

            for (int i = 0; i <tlp.RowCount; i++)
            {
                tlp.RowStyles.Add(new RowStyle(SizeType.Absolute, 35));
            }


            Button btnEntete = new Button();
            btnEntete.Size = new Size(189, 31);
            btnEntete.Text = "Nom de la cartouche";
            tlp.Controls.Add(btnEntete, 0, 0);

            Button btnEntete2 = new Button();
            btnEntete2.Size = new Size(189, 31);
            btnEntete2.Text = "Etagère";
            tlp.Controls.Add(btnEntete2, 1, 0);

            Button btnEntete3 = new Button();
            btnEntete3.Size = new Size(189, 31);
            btnEntete3.Text = "Numéro";
            tlp.Controls.Add(btnEntete3, 2, 0);

            int j = 1;
            foreach (Couleur color in listColor)
            {
                if (color.getNom() == nom)
                {
                    Button btn = new Button();
                    btn.Size = new Size(189, 31);
                    btn.Text = color.getNom();
                    tlp.Controls.Add(btn, 0, j);

                    Button btn2 = new Button();
                    btn2.Size = new Size(189, 31);
                    btn2.Text = color.getEmplacement().getEtagere();
                    tlp.Controls.Add(btn2, 1, j);

                    Button btn3 = new Button();
                    btn3.Size = new Size(189, 31);
                    btn3.Text = color.getEmplacement().getNumero().ToString();
                    tlp.Controls.Add(btn3, 2, j);
                    j++;
                }
            }
        }
    }
}
