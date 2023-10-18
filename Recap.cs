using Class;
using DataBase;

namespace Gestion_des_cartouches_d_ancres
{
    public partial class Recap : Form
    {
        public Recap()
        {
            InitializeComponent();

            setAll();

            this.FormClosing += (s, e) =>
            {
                Program.listOpen[1] = false;
            };
        }

        public void setAll()
        {
            Program.listImprimante = Bd.getImprimanteDist();
            tlp.RowCount = Program.listImprimante.Count + 1;
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
            foreach (Imprimante printer in Bd.getImprimanteDist())
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
                        int qteCart = color.getQuantite();
                        Color colorCart = new Color();

                        if (qteCart == 0)
                        {
                            colorCart = Color.Red;
                        }
                        else if (qteCart <= 3)
                        {
                            colorCart = Color.Orange;
                        }
                        else
                        {
                            colorCart = Color.YellowGreen;
                        }

                        TextBox txt = new TextBox();
                        txt.BackColor = colorCart;
                        txt.Text = qteCart.ToString();
                        txt.Size = new Size(200, 25);
                        txt.Enabled = false;

                        switch (color.getCouleur())
                        {
                            case "Noir":
                                tlp.Controls.Add(txt, 1, j);
                                break;
                            case "Jaune":
                                tlp.Controls.Add(txt, 2, j);
                                break;
                            case "Magenta":
                                tlp.Controls.Add(txt, 3, j);
                                break;
                            case "Cyan":
                                tlp.Controls.Add(txt, 4, j);
                                break;
                            default:
                                break;
                        }
                    }
                    j++;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ImpressionRecap tmp = new ImpressionRecap();
            tmp.Show(); //affiche la page ImpressionBase.
        }
    }
}
