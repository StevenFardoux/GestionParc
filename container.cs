
using DataBase;
using Newtonsoft.Json;
using File = System.IO.File;

namespace Gestion_des_cartouches_d_ancres
{
    public partial class container : Form
    {
        // constructeur global des autres form.
        gestionParc fr;
        Recap recap;
        gestionChangementCartouches gcc;
        gestionLivraison gl;
        addImpriante add;
        pop_upbd modif;
        gestionStock emplacement;
        empreint ge;
        // fin.

        public container()
        {
            this.WindowState = FormWindowState.Maximized;
            this.AutoScroll = false;

            InitializeComponent();

            string json = File.ReadAllText("..\\..\\..\\..\\DataBase\\bin\\Debug\\net6.0\\data.json");
            dynamic data = JsonConvert.DeserializeObject(json);
            if (data.Backup.Date != DateTime.Now.ToString("yyyy-MM-dd"))
            {
                data.Backup.Date = DateTime.Now.ToString("yyyy-MM-dd");
                string modifiedJson = JsonConvert.SerializeObject(data);
                File.WriteAllText("data.json", modifiedJson);

                Bd.backup_Db();
            }
        }

        // utilisation du menuStrip.
        private void gesetionnaireDesCartouchesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Program.listOpen[0] == false) // si la page n'est pas ouverte alors....
            {
                gestionParc gestionParc = new gestionParc();
                fr = gestionParc;
                Program.listOpen[0] = true;
                gestionParc.MdiParent = this;
                gestionParc.Show();
                position(0);
            }
        }

        private void recapitulatifToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Program.listOpen[1] == false)
            {
                Recap reca = new Recap();
                recap = reca;
                Program.listOpen[1] = true;
                recap.MdiParent = this;
                recap.Show();
                position(1);
            }
        }

        private void gestionDesSallesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Program.listOpen[2] == false)
            {
                gestionChangementCartouches gcc = new gestionChangementCartouches();
                this.gcc = gcc;
                Program.listOpen[2] = true;
                gcc.MdiParent = this;
                gcc.Show();
                position(2);
            }
        }

        private void gestionDesLivraisonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Program.listOpen[3] == false)
            {
                gestionLivraison gl = new gestionLivraison();
                this.gl = gl;
                Program.listOpen[3] = true;
                gl.MdiParent = this;
                gl.Show();
                position(3);
            }
        }
        private void emplacementDesCartouchesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Program.listOpen[4] == false)
            {
                addImpriante Cart = new addImpriante();
                add = Cart;
                Program.listOpen[4] = true;
                Cart.MdiParent = this;
                Cart.Show();
                position(4);
            }
        }

        private void modifierLesInformationDeConnexionÀLaBaseDeDonnéeToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (Program.listOpen[5] == false)
            {
                pop_upbd pop = new pop_upbd();
                modif = pop;
                Program.listOpen[5] = true;
                pop.MdiParent = this;
                pop.Show();
                position(5);
            }
        }

        private void emplacementDesCartouchesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (Program.listOpen[6] == false)
            {
                gestionStock gs = new gestionStock();
                emplacement = gs;
                Program.listOpen[6] = true;
                gs.MdiParent = this;
                gs.Show();
                position(6);
            }
        }

        private void gesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Program.listOpen[7] == false)
            {
                empreint emp = new empreint();
                ge = emp;
                Program.listOpen[7] = true;
                emp.MdiParent = this;
                emp.Show();
                position(7);
            }

        }

        private void importerLaBaseDeDonnéeToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show(Bd.setup_Db());
        }

        // definition de l'emplacement des pages lancer.
        public void position(int posi)
        {
            if (MdiChildren.Length >= 2)
            {
                int i = 0;
                bool trouve = false;
                List<bool> list = Program.listOpen;
                while (i <= list.Count && !trouve)
                {
                    if (list[i] && !trouve && i != posi)
                    {
                        switch (i)
                        {
                            case 0:
                                this.fr.Close();
                                Program.listOpen[0] = false;
                                break;
                            case 1:
                                this.recap.Close();
                                Program.listOpen[1] = false;
                                break;
                            case 2:
                                this.gcc.Close();
                                Program.listOpen[2] = false;
                                break; 
                            case 3:
                                this.gl.Close();
                                Program.listOpen[3] = false;
                                break;
                            case 4:
                                this.add.Close();
                                Program.listOpen[4] = false;
                                break;
                            case 5:
                                this.modif.Close();
                                Program.listOpen[5] = false;
                                break;
                            case 6:
                                this.emplacement.Close();
                                Program.listOpen[6] = false;
                                break;
                            case 7:
                                this.ge.Close();
                                Program.listOpen[7] = false;
                                break;
                        }
                        trouve = true;
                        position(posi);
                    }
                    i++;        
                }
            }
        }

       
    }
}
