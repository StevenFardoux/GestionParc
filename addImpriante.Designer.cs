namespace Gestion_des_cartouches_d_ancres
{
    partial class addImpriante
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblWarnig = new System.Windows.Forms.Label();
            this.gpbCart = new System.Windows.Forms.GroupBox();
            this.btnAddCart = new System.Windows.Forms.Button();
            this.nudQte = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.cbbCouleur = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtNomCart = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnAddPrint = new System.Windows.Forms.Button();
            this.cbxCart = new System.Windows.Forms.CheckBox();
            this.cbbCyan = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lblCyan = new System.Windows.Forms.Label();
            this.cbbMagenta = new System.Windows.Forms.ComboBox();
            this.lblMagenta = new System.Windows.Forms.Label();
            this.cbbJaune = new System.Windows.Forms.ComboBox();
            this.lblJaune = new System.Windows.Forms.Label();
            this.cbxColor = new System.Windows.Forms.CheckBox();
            this.cbbNoir = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtPrinter = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtSalle = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.gpbCart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudQte)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.panel1.Controls.Add(this.lblWarnig);
            this.panel1.Controls.Add(this.gpbCart);
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.ForeColor = System.Drawing.Color.Black;
            this.panel1.Location = new System.Drawing.Point(12, 26);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(900, 412);
            this.panel1.TabIndex = 0;
            // 
            // lblWarnig
            // 
            this.lblWarnig.AutoSize = true;
            this.lblWarnig.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblWarnig.Location = new System.Drawing.Point(390, 15);
            this.lblWarnig.Name = "lblWarnig";
            this.lblWarnig.Size = new System.Drawing.Size(143, 20);
            this.lblWarnig.TabIndex = 6;
            this.lblWarnig.Text = "Champ Manquant !";
            this.lblWarnig.Visible = false;
            // 
            // gpbCart
            // 
            this.gpbCart.BackColor = System.Drawing.Color.LightGray;
            this.gpbCart.Controls.Add(this.btnAddCart);
            this.gpbCart.Controls.Add(this.nudQte);
            this.gpbCart.Controls.Add(this.label7);
            this.gpbCart.Controls.Add(this.cbbCouleur);
            this.gpbCart.Controls.Add(this.label6);
            this.gpbCart.Controls.Add(this.txtNomCart);
            this.gpbCart.Controls.Add(this.label5);
            this.gpbCart.Location = new System.Drawing.Point(589, 135);
            this.gpbCart.Name = "gpbCart";
            this.gpbCart.Size = new System.Drawing.Size(308, 172);
            this.gpbCart.TabIndex = 5;
            this.gpbCart.TabStop = false;
            this.gpbCart.Text = "Ajouter une cartouche";
            this.gpbCart.Visible = false;
            // 
            // btnAddCart
            // 
            this.btnAddCart.Location = new System.Drawing.Point(107, 128);
            this.btnAddCart.Name = "btnAddCart";
            this.btnAddCart.Size = new System.Drawing.Size(126, 30);
            this.btnAddCart.TabIndex = 6;
            this.btnAddCart.Text = "Ajouter la cartouche";
            this.btnAddCart.UseVisualStyleBackColor = true;
            this.btnAddCart.Click += new System.EventHandler(this.btnAddCart_Click);
            // 
            // nudQte
            // 
            this.nudQte.Location = new System.Drawing.Point(180, 89);
            this.nudQte.Name = "nudQte";
            this.nudQte.Size = new System.Drawing.Size(97, 23);
            this.nudQte.TabIndex = 10;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(55, 91);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(106, 15);
            this.label7.TabIndex = 9;
            this.label7.Text = "Quantité en stock :";
            // 
            // cbbCouleur
            // 
            this.cbbCouleur.FormattingEnabled = true;
            this.cbbCouleur.Items.AddRange(new object[] {
            "Noir",
            "Jaune",
            "Magenta",
            "Cyan"});
            this.cbbCouleur.Location = new System.Drawing.Point(180, 57);
            this.cbbCouleur.Name = "cbbCouleur";
            this.cbbCouleur.Size = new System.Drawing.Size(121, 23);
            this.cbbCouleur.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(22, 60);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(139, 15);
            this.label6.TabIndex = 8;
            this.label6.Text = "Couleur de la cartouche :";
            // 
            // txtNomCart
            // 
            this.txtNomCart.Location = new System.Drawing.Point(180, 23);
            this.txtNomCart.Name = "txtNomCart";
            this.txtNomCart.Size = new System.Drawing.Size(97, 23);
            this.txtNomCart.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(37, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(124, 15);
            this.label5.TabIndex = 6;
            this.label5.Text = "Nom de la cartouche :";
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.LightGray;
            this.groupBox3.Controls.Add(this.btnAddPrint);
            this.groupBox3.Controls.Add(this.cbxCart);
            this.groupBox3.Controls.Add(this.cbbCyan);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.lblCyan);
            this.groupBox3.Controls.Add(this.cbbMagenta);
            this.groupBox3.Controls.Add(this.lblMagenta);
            this.groupBox3.Controls.Add(this.cbbJaune);
            this.groupBox3.Controls.Add(this.lblJaune);
            this.groupBox3.Controls.Add(this.cbxColor);
            this.groupBox3.Controls.Add(this.cbbNoir);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.ForeColor = System.Drawing.Color.Black;
            this.groupBox3.Location = new System.Drawing.Point(307, 49);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(276, 316);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Cartouche d\'encre";
            this.groupBox3.Enter += new System.EventHandler(this.groupBox3_Enter);
            // 
            // btnAddPrint
            // 
            this.btnAddPrint.Location = new System.Drawing.Point(71, 280);
            this.btnAddPrint.Name = "btnAddPrint";
            this.btnAddPrint.Size = new System.Drawing.Size(135, 30);
            this.btnAddPrint.TabIndex = 11;
            this.btnAddPrint.Text = "Ajouter l\'imprimante";
            this.btnAddPrint.UseVisualStyleBackColor = true;
            this.btnAddPrint.Click += new System.EventHandler(this.btnAddPrint_Click);
            // 
            // cbxCart
            // 
            this.cbxCart.AutoSize = true;
            this.cbxCart.Location = new System.Drawing.Point(212, 246);
            this.cbxCart.Name = "cbxCart";
            this.cbxCart.Size = new System.Drawing.Size(43, 19);
            this.cbxCart.TabIndex = 7;
            this.cbxCart.Text = "oui";
            this.cbxCart.UseVisualStyleBackColor = true;
            // 
            // cbbCyan
            // 
            this.cbbCyan.FormattingEnabled = true;
            this.cbbCyan.Location = new System.Drawing.Point(135, 209);
            this.cbbCyan.Name = "cbbCyan";
            this.cbbCyan.Size = new System.Drawing.Size(121, 23);
            this.cbbCyan.TabIndex = 18;
            this.cbbCyan.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(15, 246);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(191, 15);
            this.label4.TabIndex = 6;
            this.label4.Text = "La cartouche n\'est pas référencer ? ";
            // 
            // lblCyan
            // 
            this.lblCyan.AutoSize = true;
            this.lblCyan.ForeColor = System.Drawing.Color.Black;
            this.lblCyan.Location = new System.Drawing.Point(23, 191);
            this.lblCyan.Name = "lblCyan";
            this.lblCyan.Size = new System.Drawing.Size(152, 15);
            this.lblCyan.TabIndex = 19;
            this.lblCyan.Text = "Nom de la cartouche cyan :";
            this.lblCyan.Visible = false;
            // 
            // cbbMagenta
            // 
            this.cbbMagenta.FormattingEnabled = true;
            this.cbbMagenta.Location = new System.Drawing.Point(135, 165);
            this.cbbMagenta.Name = "cbbMagenta";
            this.cbbMagenta.Size = new System.Drawing.Size(121, 23);
            this.cbbMagenta.TabIndex = 16;
            this.cbbMagenta.Visible = false;
            // 
            // lblMagenta
            // 
            this.lblMagenta.AutoSize = true;
            this.lblMagenta.ForeColor = System.Drawing.Color.Black;
            this.lblMagenta.Location = new System.Drawing.Point(23, 147);
            this.lblMagenta.Name = "lblMagenta";
            this.lblMagenta.Size = new System.Drawing.Size(174, 15);
            this.lblMagenta.TabIndex = 17;
            this.lblMagenta.Text = "Nom de la cartouche magenta :";
            this.lblMagenta.Visible = false;
            // 
            // cbbJaune
            // 
            this.cbbJaune.FormattingEnabled = true;
            this.cbbJaune.Location = new System.Drawing.Point(135, 121);
            this.cbbJaune.Name = "cbbJaune";
            this.cbbJaune.Size = new System.Drawing.Size(121, 23);
            this.cbbJaune.TabIndex = 14;
            this.cbbJaune.Visible = false;
            // 
            // lblJaune
            // 
            this.lblJaune.AutoSize = true;
            this.lblJaune.ForeColor = System.Drawing.Color.Black;
            this.lblJaune.Location = new System.Drawing.Point(23, 103);
            this.lblJaune.Name = "lblJaune";
            this.lblJaune.Size = new System.Drawing.Size(156, 15);
            this.lblJaune.TabIndex = 15;
            this.lblJaune.Text = "Nom de la cartouche jaune :";
            this.lblJaune.Visible = false;
            // 
            // cbxColor
            // 
            this.cbxColor.AutoSize = true;
            this.cbxColor.Location = new System.Drawing.Point(163, 22);
            this.cbxColor.Name = "cbxColor";
            this.cbxColor.Size = new System.Drawing.Size(43, 19);
            this.cbxColor.TabIndex = 13;
            this.cbxColor.Text = "oui";
            this.cbxColor.UseVisualStyleBackColor = true;
            // 
            // cbbNoir
            // 
            this.cbbNoir.FormattingEnabled = true;
            this.cbbNoir.Location = new System.Drawing.Point(135, 77);
            this.cbbNoir.Name = "cbbNoir";
            this.cbbNoir.Size = new System.Drawing.Size(121, 23);
            this.cbbNoir.TabIndex = 5;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(30, 22);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(120, 15);
            this.label8.TabIndex = 12;
            this.label8.Text = "Imprimante couleur ?";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(23, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(148, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "Nom de la cartouche noir :";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.LightGray;
            this.groupBox2.Controls.Add(this.txtPrinter);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.ForeColor = System.Drawing.Color.Black;
            this.groupBox2.Location = new System.Drawing.Point(3, 212);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(298, 72);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Information de l\'imprimante";
            // 
            // txtPrinter
            // 
            this.txtPrinter.Location = new System.Drawing.Point(156, 33);
            this.txtPrinter.Name = "txtPrinter";
            this.txtPrinter.Size = new System.Drawing.Size(100, 23);
            this.txtPrinter.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(23, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Nom de l\'imprimante :";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.LightGray;
            this.groupBox1.Controls.Add(this.txtSalle);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(3, 142);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(298, 64);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Salle de l\'imprimante";
            // 
            // txtSalle
            // 
            this.txtSalle.Location = new System.Drawing.Point(156, 29);
            this.txtSalle.Name = "txtSalle";
            this.txtSalle.Size = new System.Drawing.Size(100, 23);
            this.txtSalle.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(23, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "Nom de la salle :";
            // 
            // addImpriante
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(924, 450);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "addImpriante";
            this.Text = "ajouter une imprimante";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.gpbCart.ResumeLayout(false);
            this.gpbCart.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudQte)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel1;
        private GroupBox groupBox1;
        private GroupBox gpbCart;
        private ComboBox cbbCouleur;
        private Label label6;
        private TextBox txtNomCart;
        private Label label5;
        private GroupBox groupBox3;
        private CheckBox cbxCart;
        private Label label4;
        private ComboBox cbbNoir;
        private Label label3;
        private GroupBox groupBox2;
        private TextBox txtPrinter;
        private Label label1;
        private TextBox txtSalle;
        private Label label2;
        private NumericUpDown nudQte;
        private Label label7;
        private Button btnAddCart;
        private Button btnAddPrint;
        private ComboBox cbbMagenta;
        private Label lblMagenta;
        private ComboBox cbbJaune;
        private Label lblJaune;
        private CheckBox cbxColor;
        private Label label8;
        private ComboBox cbbCyan;
        private Label lblCyan;
        private Label lblWarnig;
    }
}