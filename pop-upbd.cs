using System.ComponentModel;
using Timer = System.Windows.Forms.Timer;
using Newtonsoft.Json;

namespace Gestion_des_cartouches_d_ancres
{
    public partial class pop_upbd : Form
    {
        public bool serverOK = true, bdOk = true, userOk = true, mdpOk = true;

        private void pop_upbd_Load(object sender, EventArgs e)
        {
        }

        public pop_upbd()
        {
            InitializeComponent();

            Timer blinkTimer = new Timer();
            blinkTimer.Interval = 500;
            blinkTimer.Tick += new EventHandler(BlinkTextBox);
            blinkTimer.Start();

            this.FormClosing += (s, e) =>
            {
                Program.listOpen[5] = false;
            };

            txtServ.TextChanged += (s, e) =>
            {
                serverOK = true;
                txtServ.BackColor = Color.White;
            };
            txtBd.TextChanged += (s, e) =>
            {
                bdOk = true;
                txtBd.BackColor = Color.White;
            };
            txtUser.TextChanged += (s, e) =>
            {
                userOk = true;
                txtUser.BackColor = Color.White;
            };
            txtMdp.TextChanged += (s, e) =>
            {
                mdpOk = true;
                txtMdp.BackColor = Color.White;
            };
        }

        private void btnMod_Click(object sender, EventArgs e)
        {
            if (txtServ.Text.Trim() == "")
            {
                serverOK = false;
            }
            if (txtBd.Text.Trim() == "")
            {
                bdOk = false;
            }
            if (txtUser.Text.Trim() == "")
            {
                userOk = false;
            }
            if (txtMdp.Text.Trim() == "")
            {
                mdpOk = false;
            }

            if (serverOK && bdOk && userOk && mdpOk)
            {
                //change connexion

                // Lire le fichier JSON
                string json = File.ReadAllText("..\\..\\..\\..\\DataBase\\bin\\Debug\\net6.0\\data.json");

                dynamic data = JsonConvert.DeserializeObject(json);

                // Modifier les informations de connexion                
                data.connection.Server = txtServ.Text.Trim();
                data.connection.DataBase = txtBd.Text.Trim();
                data.connection.user = txtUser.Text.Trim();
                data.connection.password = txtMdp.Text.Trim();

                // Serialize C# object to JSON
                string modifiedJson = JsonConvert.SerializeObject(data);

                //MessageBox.Show(modifiedJson);

                //Écrire le fichier JSON modifié
                File.WriteAllText("..\\..\\..\\..\\DataBase\\bin\\Debug\\net6.0\\data.json", modifiedJson);

                hightlightBtn(btnMod);
            }
        }

        private void BlinkTextBox(object sender, EventArgs e)
        {
            if (!serverOK)
            {
                if (txtServ.BackColor == Color.White)
                {
                    txtServ.BackColor = Color.Red;
                }
                else
                {
                    txtServ.BackColor = Color.White;
                }
            }
            if (!bdOk)
            {
                if (txtBd.BackColor == Color.White)
                {
                    txtBd.BackColor = Color.Red;
                }
                else
                {
                    txtBd.BackColor = Color.White;
                }
            }
            if (!userOk)
            {
                if (txtUser.BackColor == Color.White)
                {
                    txtUser.BackColor = Color.Red;
                }
                else
                {
                    txtUser.BackColor = Color.White;
                }
            }
            if (!mdpOk)
            {
                if (txtMdp.BackColor == Color.White)
                {
                    txtMdp.BackColor = Color.Red;
                }
                else
                {
                    txtMdp.BackColor = Color.White;
                }
            }

            if (!serverOK || !bdOk || !userOk || !mdpOk)
            {
                lblWarning.Visible = true;
                if (lblWarning.ForeColor == Color.Black)
                {
                    lblWarning.ForeColor = Color.Red;
                }
                else lblWarning.ForeColor = Color.Black;
            }
            else
            {
                lblWarning.Visible = false;
            }
        }

        private void hightlightBtn(Button btn)
        {
            var worker = new BackgroundWorker();

            worker.DoWork += (s, e) =>
            {
                this.Invoke((MethodInvoker)delegate
                {
                    btn.BackColor = Color.Lime;
                });

                Thread.Sleep(500);

                btn.BackColor = Color.LightGray;
            };

            worker.RunWorkerAsync();
        }
    }
}