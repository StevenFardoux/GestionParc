using Class;
using DataBase;
using Org.BouncyCastle.Crypto.Engines;
using System.Drawing.Printing;
using Timer = System.Windows.Forms.Timer;

namespace Gestion_des_cartouches_d_ancres
{
    public partial class modifInfo : Form
    {
        public Classe salle = null;
        public Imprimante printer = null;
        public Couleur cartouche = null;
        public bool nomOk = true, couleurOk = true, noirOk = true, jauneOk = true, magentaOk = true, cyanOk = true;
        public modifInfo()
        {
            InitializeComponent();

            this.FormClosing += (s, e) => 
            {
                gestionParc.salle = null;
                gestionParc.printer = null;
                gestionParc.cartouche = null;
                Program.listOpen[5] = false;
            };

            Timer blinkTimer = new Timer();
            blinkTimer.Interval = 500; 
            blinkTimer.Tick += new EventHandler(BlinkTextBox);
            blinkTimer.Start();

            

            if (gestionParc.salle != null)
            {

                foreach (Classe salle in Bd.getSalle())
                {
                    cbbNoir.Items.Add($"{salle.getNom()} - {salle.getImprimante().getNom()}");
                }
                this.salle = gestionParc.salle;
                btnNom.Text = salle.getNom();
                txtNom.Text = salle.getNom();
                btnSend.Visible = true;
                lblNoir.Visible = true;
                lblNoir.Text = "Imprimante :";
                cbbNoir.Text = salle.getImprimante().getNom();
                cbbNoir.Visible = true;
                btnSendColor.Visible = false;
            }
            else if (gestionParc.printer != null)
            {
                this.printer = gestionParc.printer;
                btnNom.Text = printer.getNom();
                txtNom.Text = printer.getNom();
                foreach (Couleur color in printer.getListCouleurs())
                {
                    switch (color.getCouleur())
                    {
                        case "Noir":
                            cbbNoir.Text = color.getNom();
                            break;
                        case "Jaune":
                            cbbJaune.Text = color.getNom();
                            break;
                        case "Magenta":
                            cbbMagenta.Text = color.getNom();
                            break;
                        case "Cyan":
                            cbbCyan.Text = color.getNom();
                            break;
                    }
                }
                if (printer.getListCouleurs().Count > 1)
                {
                    ckbColor.Checked = true;
                    lblJaune.Visible = true;
                    cbbJaune.Visible = true;
                    lblMagenta.Visible = true;
                    cbbMagenta.Visible = true;
                    lblCyan.Visible = true;
                    cbbCyan.Visible = true;
                }
                btnSendColor.Visible = true;
                ckbColor.Visible = true;
                lblNoir.Visible = true;
                cbbNoir.Visible = true;
            }
            else
            {
                foreach (Couleur color in Bd.getCartouche())
                {
                    cbbNoir.Items.Add(color.getNom());
                    cbbJaune.Items.Add(color.getNom());
                    cbbMagenta.Items.Add(color.getNom());
                    cbbCyan.Items.Add(color.getNom());
                }

                this.cartouche = gestionParc.cartouche;
                btnNom.Text = cartouche.getNom();
                txtNom.Text = cartouche.getNom();
                cbbColor.Text = cartouche.getCouleur();
                nudQte.Value = cartouche.getQuantite();
                lblColor.Visible = true;
                cbbColor.Visible = true;
                lblQte.Visible = true;
                nudQte.Visible = true;
                btnSendColor.Visible = true;
                btnSend.Visible = false;
                ckbColor.Visible = true;
            }

            ckbColor.CheckedChanged += (s, e) =>
            {
                if (ckbColor.Checked)
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

            btnSend.Click += (s, e) =>
            {
                if (txtNom.Text.Trim() == "")
                {
                    nomOk = false;
                }
                if (cbbNoir.Text.Trim() == "")
                {
                    noirOk = false;
                }
                else
                {
                    if (salle != null)
                    {
                        int id = 0;
                        string[] str;
                        str = cbbNoir.Text.Trim().Split(new char[] {'-'});
                        foreach (Imprimante printer in Bd.getImprimanteDist())
                        {
                           if (str.Length == 1)
                           {
                                if (printer.getNom() == str[0])
                                {
                                    id = printer.getId();
                                }
                           }
                           else
                           {
                                if (printer.getNom() == str[1])
                                {
                                    id = printer.getId();
                                }
                            }
                           
                        }
                        Bd.updateSalle(salle.getId(), txtNom.Text.ToUpper(), id);
                    }
                }
            };
            btnSendColor.Click += (s, e) =>
            {
                if (printer != null)
                {
                    if (txtNom.Text.Trim() == "")
                    {
                        nomOk = false;
                    }
                    if (cbbNoir.Text.Trim() == "")
                    {
                        noirOk = false;
                    }

                    if (ckbColor.Checked)
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

                        if (nomOk || noirOk || jauneOk || magentaOk || cyanOk)
                        {
                            List<int> list = new List<int>();

                            foreach (Couleur color in Bd.getCartouche())
                            {
                                if (color.getNom() == cbbNoir.Text || color.getNom() == cbbJaune.Text || color.getNom() == cbbMagenta.Text || color.getNom() == cbbCyan.Text)
                                {
                                    list.Add(color.getId());
                                }
                            }

                            Bd.updatePrinter(printer.getId(), txtNom.Text.ToUpper(), list);
                        }
                    }
                    else
                    {
                        if (nomOk || noirOk)
                        {
                            List<int> list = new List<int>();

                            foreach (Couleur color in Bd.getCartouche())
                            {
                                if (color.getNom() == cbbNoir.Text || color.getNom() == cbbJaune.Text || color.getNom() == cbbMagenta.Text || color.getNom() == cbbCyan.Text)
                                {
                                    list.Add(color.getId());
                                }
                            }

                            Bd.updatePrinter(printer.getId(), txtNom.Text.ToUpper(), list);
                        }
                    }

                    
                }
                else
                {
                    if (txtNom.Text.Trim() == "")
                    {
                        nomOk = false;
                    }
                    if (cbbColor.Text.Trim() == "")
                    {
                        couleurOk = false;
                    }

                    if (nomOk || couleurOk)
                    {
                        Bd.updateCartouche(cartouche.getId(), txtNom.Text.ToUpper(), cbbColor.Text, int.Parse(nudQte.Value.ToString()));
                    }
                }
            };

            txtNom.TextChanged += (s, e) =>
            {
                nomOk = true;
            };
            cbbColor.Click += (s, e) =>
            {
                couleurOk = true;
            };
        }
        private void BlinkTextBox(object sender, EventArgs e)
        {
            if (!nomOk)
            {
                if (txtNom.BackColor == Color.White)
                {
                    txtNom.BackColor = Color.Red;
                }
                else
                {
                    txtNom.BackColor = Color.White;
                }
            }
            else
            {
                txtNom.BackColor = Color.White;
            }
            if (!couleurOk)
            {
                if (cbbColor.BackColor == Color.White)
                {
                    cbbColor.BackColor = Color.Red;
                }
                else
                {
                    cbbColor.BackColor = Color.White;
                }
            }
            else
            {
                cbbColor.BackColor = Color.White;
            }

            if (!nomOk || !couleurOk)
            {
                lblWarning.Visible = true;
                if (lblWarning.ForeColor == Color.Black)
                {
                    lblWarning.ForeColor = Color.Red;
                }
                else
                {
                    lblWarning.ForeColor = Color.Black;
                }
            }
            else
            {
                lblWarning.Visible = false;
            }
        }
    }
}
