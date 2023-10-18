using Class;
using DataBase;
using Timer = System.Windows.Forms.Timer;

namespace Gestion_des_cartouches_d_ancres
{
    public partial class addImpriante : Form
    {
        public bool nomCartOk = true, colorOk = true, nomSalleOk = true, nomPrintOk = true, noirOK = true, jauneOk = true, magentaOk = true, cyanOk = true;
        public addImpriante()
        {
            InitializeComponent();


            this.FormClosing += (s, e) => //quand la croix pour fermer la page est cliquer.
            {
                Program.listOpen[4] = false;
            };


            foreach (string nomCart in Bd.getNomCart()) 
            {
                cbbNoir.Items.Add(nomCart);
                cbbJaune.Items.Add(nomCart);
                cbbMagenta.Items.Add(nomCart);
                cbbCyan.Items.Add(nomCart);
            }

            cbxCart.CheckedChanged += (s, e) =>
            {
                if (cbxCart.Checked == true)
                {
                gpbCart.Visible = true;
                }
                else
                {
                    gpbCart.Visible = false;
                }
            };

            cbxColor.CheckedChanged += (s, e) =>
            {
                if (cbxColor.Checked == true)
                {
                    lblJaune.Visible = true;
                    cbbJaune.Visible = true;
                    lblMagenta.Visible = true;
                    cbbMagenta.Visible = true;
                    lblCyan.Visible = true;
                    cbbCyan.Visible = true;
                }
                else
                {
                    lblJaune.Visible = false;
                    cbbJaune.Visible = false;
                    lblMagenta.Visible = false;
                    cbbMagenta.Visible = false;
                    lblCyan.Visible = false;
                    cbbCyan.Visible = false;
                }
            };

            Timer blinkTimer = new Timer();
            blinkTimer.Interval = 500; // changer la couleur toutes les 500ms
            blinkTimer.Tick += new EventHandler(BlinkTextBox);
            blinkTimer.Start();

            txtSalle.KeyPress += (s, e) =>
            {
                nomSalleOk = true;
            };

            txtPrinter.KeyPress += (s, e) =>
            {
                nomPrintOk = true;
            };

            txtNomCart.KeyPress += (s, e) =>
            {
                nomCartOk = true;
            };


            cbbNoir.MouseClick += (s, e) =>
            {
                noirOK = true;
            };

            cbbJaune.MouseClick += (s, e) =>
            {
                jauneOk = true;
            };

            cbbMagenta.MouseClick += (s, e) =>
            {
                magentaOk = true;
            };

            cbbCyan.MouseClick += (s, e) =>
            {
                cyanOk = true;
            };

            cbbCouleur.MouseClick += (s, e) =>
            {
                colorOk = true;
            };
        }

        private void btnAddCart_Click(object sender, EventArgs e)
        {
           
            if (txtNomCart.Text.Trim() == "")
            {
                nomCartOk = false;
                
            }
            if (cbbCouleur.Text.Trim() == "")
            {
                colorOk = false;
            }

            if (nomCartOk && colorOk)
            {
                //ajoute la couleur à la bd.
                Bd.insertNewCartouche(txtNomCart.Text.ToUpper(), cbbCouleur.Text, int.Parse(nudQte.Value.ToString()));

                cbbNoir.Items.Clear();
                cbbJaune.Items.Clear();
                cbbMagenta.Items.Clear();
                cbbCyan.Items.Clear();

                foreach (string nomCart in Bd.getNomCart())
                {
                    cbbNoir.Items.Add(nomCart);
                    cbbJaune.Items.Add(nomCart);
                    cbbMagenta.Items.Add(nomCart);
                    cbbCyan.Items.Add(nomCart);
                }
            }
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void btnAddPrint_Click(object sender, EventArgs e)
        {
            if (txtSalle.Text.Trim() == "")
            {
                nomSalleOk = false;

            }
            if (txtPrinter.Text.Trim() == "")
            {
                nomPrintOk = false;

            }
            if (cbbNoir.Text.Trim() == "")
            {
                noirOK = false;
            }

            if (nomSalleOk && nomPrintOk && noirOK)
            {
                if (cbxColor.Checked == true)
                {
                    if (cbbJaune.Text.Trim() == "")
                    {
                        jauneOk = false;
                    }
                    if (cbbMagenta.Text.Trim() == "")
                    {
                        magentaOk = false;
                    }
                    if (cbbCyan.Text.Trim() == "")
                    {
                        cyanOk = false;
                    }

                    if (jauneOk && magentaOk && cyanOk)
                    {
                        List<Couleur> list = new List<Couleur>
                        {
                            Bd.getCartoucheByNom(cbbNoir.Text),
                            Bd.getCartoucheByNom(cbbJaune.Text),
                            Bd.getCartoucheByNom(cbbMagenta.Text),
                            Bd.getCartoucheByNom(cbbCyan.Text),
                        };
                        Bd.insertNewPrinter(new Classe(0, txtSalle.Text.ToUpper(), new Imprimante(0, txtPrinter.Text.ToUpper(), list)));
                    }
                    
                }
                else
                {
                    List<Couleur> list = new List<Couleur>
                {
                    Bd.getCartoucheByNom(cbbNoir.Text)
                };
                    Bd.insertNewPrinter(new Classe(0, txtSalle.Text.ToUpper(), new Imprimante(0, txtPrinter.Text.ToUpper(), list)));
                }
            }       
        }

        private void BlinkTextBox(object sender, EventArgs e)
        {
            if (!nomCartOk)
            {
                if (txtNomCart.BackColor == Color.Red)
                {
                    txtNomCart.BackColor = Color.White;
                }
                else
                {
                    txtNomCart.BackColor = Color.Red;
                }
            }
            else
            {
                txtNomCart.BackColor = Color.White;

            }

            if (!colorOk)
            {
                if (cbbCouleur.BackColor == Color.Red)
                {
                    cbbCouleur.BackColor = Color.White;
                }
                else
                {
                    cbbCouleur.BackColor = Color.Red;
                }
            }
            else
            {
                cbbCouleur.BackColor = Color.White;

            }

            if (!nomSalleOk)
            {
                if (txtSalle.BackColor == Color.Red)
                {
                    txtSalle.BackColor = Color.White;
                }
                else
                {
                    txtSalle.BackColor = Color.Red;
                }
            }
            else
            {
                txtSalle.BackColor = Color.White;

            }

            if (!nomPrintOk)
            {
                if (txtPrinter.BackColor == Color.Red)
                {
                    txtPrinter.BackColor = Color.White;
                }
                else
                {
                    txtPrinter.BackColor = Color.Red;
                }
            }
            else
            {
                txtPrinter.BackColor = Color.White;

            }

            if (!noirOK)
            {
                if (cbbNoir.BackColor == Color.Red)
                {
                    cbbNoir.BackColor = Color.White;
                }
                else
                {
                    cbbNoir.BackColor = Color.Red;
                }
            }
            else
            {
                cbbNoir.BackColor = Color.White;

            }

            if (!jauneOk)
            {
                if (cbbJaune.BackColor == Color.Red)
                {
                    cbbJaune.BackColor = Color.White;
                }
                else
                {
                    cbbJaune.BackColor = Color.Red;
                }
            }
            else
            {
                cbbJaune.BackColor = Color.White;

            }

            if (!magentaOk)
            {
                if (cbbMagenta.BackColor == Color.Red)
                {
                    cbbMagenta.BackColor = Color.White;
                }
                else
                {
                    cbbMagenta.BackColor = Color.Red;
                }
            }
            else
            {
                cbbMagenta.BackColor = Color.White;

            }

            if (!cyanOk)
            {
                if (cbbCyan.BackColor == Color.Red)
                {
                    cbbCyan.BackColor = Color.White;
                }
                else
                {
                    cbbCyan.BackColor = Color.Red;
                }
            }
            else
            {
                cbbCyan.BackColor = Color.White;

            }


            if (!nomCartOk || !nomSalleOk || !nomPrintOk || !colorOk || !noirOK || !jauneOk || !magentaOk || !cyanOk)
            {
                lblWarnig.Visible = true;
                if (lblWarnig.ForeColor == Color.Red)
                {
                    lblWarnig.ForeColor = Color.Black;
                }
                else
                {
                    lblWarnig.ForeColor = Color.Red;
                }
            }
            else
            {
                lblWarnig.Visible = false;
            }
        }
    }
}
