using Class;
using DataBase;

namespace Gestion_des_cartouches_d_ancres
{
    public partial class gestionParc : Form
    {
        public bool salleOk, printOk, cartOk, trouver;
        public List<string> listSalle = new List<string>();
        public List<string> listPrint = new List<string>();
        public static Classe salle = null;
        public static Imprimante printer = null;
        public static Couleur cartouche = null;

        public gestionParc()
        {
            InitializeComponent();

            this.FormClosing += (s, e) => //quand la croix pour fermer la page est cliquer.
            {
                Program.listOpen[0] = false;
            };

            cbbEnter.Items.Clear();
            foreach (Classe salle in Bd.getSalle())
            {
                if (!listSalle.Contains(salle.getNom()))
                {
                    cbbEnter.Items.Add(salle.getNom());
                    listSalle.Add(salle.getNom());
                }
            }

            cbbEnter.TextChanged += (s, e) =>
            {
                if (cbbEnter.Text != string.Empty)
                { 
                    setTlp(cbbEnter.Text);
                }
            };

            rdnSalle.CheckedChanged += (s, e) =>
            {
                if (rdnSalle.Checked)
                {
                    cbbEnter.Items.Clear();
                    listSalle.Clear();
                    foreach (Classe salle in Bd.getSalle())
                    {
                        if (!listSalle.Contains(salle.getNom()))
                        {
                            cbbEnter.Items.Add(salle.getNom());
                            listSalle.Add(salle.getNom());
                        }
                    }

                    salleOk = true;
                    printOk = false;
                    cartOk = false;
                }
            };

            rdnPrint.CheckedChanged += (s, e) =>
            {
                if (rdnPrint.Checked)
                {
                    cbbEnter.Items.Clear();
                    foreach (Classe salle in Bd.getSalle())
                    {
                            cbbEnter.Items.Add($"{salle.getNom()} - {salle.getImprimante().getNom()}");
                    }

                    printOk = true;
                    salleOk = false;
                    cartOk = false;
                }
            };

            rdnCart.CheckedChanged += (s, e) =>
            {
                if (rdnCart.Checked)
                {
                    cbbEnter.Items.Clear();
                    foreach (Couleur color in Bd.getCartouche())
                    {
                        cbbEnter.Items.Add(color.getNom());
                    }

                    cartOk = true;
                    printOk = false;
                    salleOk = false;
                }
            };


            btnModif.Click += (s, e) =>
            {
                if (!(cbbEnter.Text.Trim() == ""))
                {
                    trouver = false;
                    foreach (Classe sall in Bd.getSalle())
                    {
                        if (sall.getNom() == cbbEnter.Text)
                        {
                            salle = sall;
                            trouver = true;
                        }
                    }

                    if (!trouver)
                    {
                        foreach (Classe salle in Bd.getSalle())
                        {
                            string[] str;
                            str = cbbEnter.Text.Split(new char[] {'-'});
                            if (salle.getNom() == str[0].Trim() && salle.getImprimante().getNom() == str[1].Trim())
                            {
                                printer = salle.getImprimante();
                                trouver = true;
                            }
                        }
                    }

                    if (!trouver)
                    {
                        foreach (Couleur color in Bd.getCartouche())
                        {
                            if (color.getNom() == cbbEnter.Text)
                            {
                                cartouche = color;
                                trouver = true;
                            }
                        }
                    }
                    modifInfo modif = new modifInfo();
                    modif.Show();
                    setTlp(cbbEnter.Text);
                }
            };
            btnSuppr.Click += (s, e) =>
            {
                if(!(cbbEnter.Text.Trim() == ""))
                {
                    trouver = false;
                    DialogResult dial = MessageBox.Show("Voulez vous vraiment supprimer l'élément ?", "Suppression", MessageBoxButtons.YesNo);
                    if (dial == DialogResult.Yes)
                    {
                        foreach (Classe salle in Bd.getSalle())
                        {
                            if (salle.getNom() == cbbEnter.Text)
                            {
                                Bd.delSalle(salle.getId());
                                trouver = true;
                            }
                        }

                        if (!trouver)
                        {
                            foreach (Imprimante printer in Bd.getImprimanteDist())
                            {
                                if (printer.getNom() == cbbEnter.Text)
                                {
                                    Bd.delPrinter(printer.getId());
                                    trouver = true;
                                }
                            }
                        }

                        if (!trouver)
                        {
                            foreach (Couleur color in Bd.getCartouche())
                            {
                                if (color.getNom() == cbbEnter.Text)
                                {
                                    Bd.delCartouche(color.getId());
                                }
                            }
                        }
                    }
                    if (salleOk)
                    {
                        cbbEnter.Items.Clear();
                        listSalle.Clear();
                        foreach (Classe salle in Bd.getSalle())
                        {
                            if (!listSalle.Contains(salle.getNom()))
                            {
                                cbbEnter.Items.Add(salle.getNom());
                                listSalle.Add(salle.getNom());
                            }
                        }
                    }
                    else if (printOk)
                    {
                        cbbEnter.Items.Clear();
                        foreach (Imprimante print in Bd.getImprimanteDist())
                        {
                            cbbEnter.Items.Add(print.getNom());
                        }
                    }
                    else
                    {
                        cbbEnter.Items.Clear();
                        foreach (Couleur color in Bd.getCartouche())
                        {
                            cbbEnter.Items.Add(color.getNom());
                        }
                    }
                    setTlp(cbbEnter.Text);
                }
            };
        }

        public void setTlp(string strEnter)
        {
            tlp.Controls.Clear();

            if (rdnSalle.Checked)
            {
                List<Classe> list = new List<Classe>();
                list = Bd.getSalle();


                int s = 0;
                foreach (Classe salle in list)
                {
                    s++;

                    foreach (Couleur color in salle.getImprimante().getListCouleurs())
                    {
                        s += 2;
                    }
                }

                tlp.RowCount = s;
                tlp.ColumnCount = 4;
                tlp.Size = new Size(782, 35 * tlp.RowCount);
                for (int j = 0; j < tlp.RowCount; j++)
                {
                    tlp.RowStyles.Add(new RowStyle(SizeType.Absolute, 50));
                    tlp.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25));
                }

                int i = 0;
                foreach (Classe salle in list)
                {
                    if (salle.getNom() == strEnter)
                    {
                        Button btn = new Button();
                        btn.Size = new Size(189, 31);
                        btn.Text = salle.getImprimante().getNom();
                        tlp.Controls.Add(btn, 0, i);
                        i++;

                        Button btn2 = new Button();
                        btn2.Size = new Size(189, 31);
                        btn2.Text = "====================>";
                        tlp.Controls.Add(btn2, 0, i);

                        foreach (Couleur color in salle.getImprimante().getListCouleurs())
                        {
                            Button btn3 = new Button();
                            btn3.Size = new Size(189, 31);
                            btn3.Text = color.getNom();
                            tlp.Controls.Add(btn3, 1, i);
                            i++;

                            Button btn4 = new Button();
                            btn4.Size = new Size(189, 31);
                            btn4.Text = "====================>";
                            tlp.Controls.Add(btn4, 1, i);

                            Button btn6 = new Button();
                            btn6.Size = new Size(189, 31);
                            btn6.Text = color.getCouleur();
                            tlp.Controls.Add(btn6, 2, i);
                            i++;

                            NumericUpDown nud = new NumericUpDown();
                            nud.Size = new Size(189, 31);
                            nud.Text = color.getQuantite().ToString();
                            tlp.Controls.Add(nud, 2, i);
                            i++;
                            nud.ValueChanged += (s, e) =>
                            {
                                Bd.UpdateQteCartById(color.getId(), int.Parse(nud.Text.ToString()));
                            };
                        }
                    }
                }
            }
            else if (rdnPrint.Checked)
            {
                List<Classe> list = new List<Classe>();
                int nbRow;
                list = Bd.getSalle();

                if (list.Count >= Bd.getCartouche().Count)
                {
                    nbRow = list.Count;
                }
                else
                {
                    nbRow = Bd.getCartouche().Count;
                }

                tlp.RowCount = nbRow + 1;
                tlp.ColumnCount = 6;
                tlp.Size = new Size(782, 35 * tlp.RowCount);
                for (int j = 0; j < tlp.RowCount; j++)
                {
                    tlp.RowStyles.Add(new RowStyle(SizeType.Absolute, 50));
                    tlp.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16));
                }

                int i = 1, s = 1;

                Button btnEntete = new Button();
                btnEntete.Size = new Size(189, 31);
                btnEntete.BackColor = Color.DarkGray;
                btnEntete.Text = "Salles";
                tlp.Controls.Add(btnEntete, 1, 0);

                Label lblEntete = new Label();
                lblEntete.Size = new Size(189, 31);
                lblEntete.Text = "                      |";
                tlp.Controls.Add(lblEntete, 2, 0);

                Button btnEntete2 = new Button();
                btnEntete2.Size = new Size(189, 31);
                btnEntete2.BackColor = Color.DarkGray;
                btnEntete2.Text = "Cartouches";
                tlp.Controls.Add(btnEntete2, 4, 0);



                listSalle.Clear();
                bool colorOk = false;
                string[] str;
                foreach (Classe salle in list)
                {
                    str = strEnter.Split(new char[] { '-' });
                    if (salle.getNom() == str[0].Trim() && salle.getImprimante().getNom() == str[1].Trim())
                    {
                        if (!listSalle.Contains(salle.getNom()))
                        {
                            listSalle.Add(salle.getNom());
                            Button btn = new Button();
                            btn.Size = new Size(189, 31);
                            btn.Text = salle.getNom();
                            tlp.Controls.Add(btn, 1, i);

                            Label lbl = new Label();
                            lbl.Size = new Size(189, 31);
                            lbl.Text = "                      |";
                            tlp.Controls.Add(lbl, 2, i);
                            i++;
                        }

                        if (!colorOk)
                        {
                            foreach (Couleur color in salle.getImprimante().getListCouleurs())
                            {
                                Button btn2 = new Button();
                                btn2.Size = new Size(189, 31);
                                btn2.Text = color.getNom();
                                tlp.Controls.Add(btn2, 3, s);

                                Button btn3 = new Button();
                                btn3.Size = new Size(189, 31);
                                btn3.Text = color.getCouleur();
                                tlp.Controls.Add(btn3, 4, s);

                                NumericUpDown nud = new NumericUpDown();
                                nud.Size = new Size(189, 31);
                                nud.Text = color.getQuantite().ToString();
                                nud.ValueChanged += (s, e) =>
                                {
                                    Bd.UpdateQteCartById(color.getId(), int.Parse(nud.Text.ToString()));
                                };
                                tlp.Controls.Add(nud, 5, s);
                                s++;
                            }
                            colorOk = true;
                        }
                    }
                }
            }
            else
            {
                List<Classe> list = new List<Classe>();
                list = Bd.getSalle();

                tlp.RowCount = list.Count + 1;
                tlp.ColumnCount = 6;
                tlp.Size = new Size(782, 50 * tlp.RowCount);
                for (int j = 0; j < tlp.RowCount; j++)
                {
                    tlp.RowStyles.Add(new RowStyle(SizeType.Absolute, 50));
                    tlp.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16));
                }

                Button btnEntete = new Button();
                btnEntete.Size = new Size(189, 31);
                btnEntete.BackColor = Color.DarkGray;
                btnEntete.Text = "Salles";
                tlp.Controls.Add(btnEntete, 0, 0);

                Label lblEntete = new Label();
                lblEntete.Size = new Size(189, 31);
                lblEntete.Text = "                      |";
                tlp.Controls.Add(lblEntete, 1, 0);

                Button btnEntete2 = new Button();
                btnEntete2.Size = new Size(189, 31);
                btnEntete2.BackColor = Color.DarkGray;
                btnEntete2.Text = "Imprimantes";
                tlp.Controls.Add(btnEntete2, 2, 0);

                Label lblEntete2 = new Label();
                lblEntete2.Size = new Size(189, 31);
                lblEntete2.Text = "                      |";
                tlp.Controls.Add(lblEntete2, 3, 0);

                Button btnEntete3 = new Button();
                btnEntete3.Size = new Size(189, 31);
                btnEntete3.BackColor = Color.DarkGray;
                btnEntete3.Text = "Couleur";
                tlp.Controls.Add(btnEntete3, 4, 0);

                Button btnEntete4 = new Button();
                btnEntete4.Size = new Size(189, 31);
                btnEntete4.BackColor = Color.DarkGray;
                btnEntete4.Text = "Quantités";
                tlp.Controls.Add(btnEntete4, 5, 0);


                listSalle.Clear();
                listPrint.Clear();

                int i = 1, k = 1;
                foreach (Classe salle in list)
                {
                    foreach (Couleur color in salle.getImprimante().getListCouleurs())
                    {
                        if (color.getNom() == strEnter)
                        {
                            if (!listSalle.Contains(salle.getNom()))
                            {
                                listSalle.Add(salle.getNom());

                                Button btn = new Button();
                                btn.Size = new Size(189, 31);
                                btn.Text = salle.getNom();
                                tlp.Controls.Add(btn, 0, i);

                                Label lbl = new Label();
                                lbl.Size = new Size(189, 31);
                                lbl.Text = "                      |";
                                tlp.Controls.Add(lbl, 1, i);
                                i++;
                            }

                            if (!listPrint.Contains(salle.getImprimante().getNom()))
                            {
                                listPrint.Add(salle.getImprimante().getNom());

                                Button btn2 = new Button();
                                btn2.Size = new Size(250, 50);
                                btn2.Text = salle.getImprimante().getNom();
                                tlp.Controls.Add(btn2, 2, k);

                                Label lbl2 = new Label();
                                lbl2.Size = new Size(189, 31);
                                lbl2.Text = "                      |";
                                tlp.Controls.Add(lbl2, 3, k);
                                k++;
                            }

                           
                        }
                    }
                }
                
                foreach (Couleur color in Bd.getCartouche())
                if (color.getNom() == strEnter)
                {
                    Button btn3 = new Button();
                    btn3.Size = new Size(189, 31);
                    btn3.Text = color.getCouleur();
                    tlp.Controls.Add(btn3, 4, 1);

                    NumericUpDown nud = new NumericUpDown();
                    nud.Size = new Size(189, 31);
                    nud.Text = color.getQuantite().ToString();
                    tlp.Controls.Add(nud, 5, 1);
                    nud.ValueChanged += (s, e) =>
                    {
                        Bd.UpdateQteCartById(color.getId(), int.Parse(nud.Text.ToString()));
                    };
                }
            }
        }
    }
}
