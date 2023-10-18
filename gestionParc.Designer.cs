namespace Gestion_des_cartouches_d_ancres
{
    partial class gestionParc
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
            this.btnSuppr = new System.Windows.Forms.Button();
            this.btnModif = new System.Windows.Forms.Button();
            this.cbbEnter = new System.Windows.Forms.ComboBox();
            this.rdnCart = new System.Windows.Forms.RadioButton();
            this.rdnPrint = new System.Windows.Forms.RadioButton();
            this.rdnSalle = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tlp = new System.Windows.Forms.TableLayoutPanel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightGray;
            this.panel1.Controls.Add(this.btnSuppr);
            this.panel1.Controls.Add(this.btnModif);
            this.panel1.Controls.Add(this.cbbEnter);
            this.panel1.Controls.Add(this.rdnCart);
            this.panel1.Controls.Add(this.rdnPrint);
            this.panel1.Controls.Add(this.rdnSalle);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(161, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(457, 88);
            this.panel1.TabIndex = 0;
            // 
            // btnSuppr
            // 
            this.btnSuppr.Location = new System.Drawing.Point(342, 55);
            this.btnSuppr.Name = "btnSuppr";
            this.btnSuppr.Size = new System.Drawing.Size(75, 23);
            this.btnSuppr.TabIndex = 6;
            this.btnSuppr.Text = "Supprimer";
            this.btnSuppr.UseVisualStyleBackColor = true;
            // 
            // btnModif
            // 
            this.btnModif.Location = new System.Drawing.Point(46, 56);
            this.btnModif.Name = "btnModif";
            this.btnModif.Size = new System.Drawing.Size(75, 23);
            this.btnModif.TabIndex = 5;
            this.btnModif.Text = "Modifier";
            this.btnModif.UseVisualStyleBackColor = true;
            // 
            // cbbEnter
            // 
            this.cbbEnter.FormattingEnabled = true;
            this.cbbEnter.Location = new System.Drawing.Point(137, 55);
            this.cbbEnter.Name = "cbbEnter";
            this.cbbEnter.Size = new System.Drawing.Size(185, 23);
            this.cbbEnter.TabIndex = 4;
            // 
            // rdnCart
            // 
            this.rdnCart.AutoSize = true;
            this.rdnCart.Location = new System.Drawing.Point(295, 31);
            this.rdnCart.Name = "rdnCart";
            this.rdnCart.Size = new System.Drawing.Size(85, 19);
            this.rdnCart.TabIndex = 3;
            this.rdnCart.Text = "Cartouches";
            this.rdnCart.UseVisualStyleBackColor = true;
            // 
            // rdnPrint
            // 
            this.rdnPrint.AutoSize = true;
            this.rdnPrint.Location = new System.Drawing.Point(181, 31);
            this.rdnPrint.Name = "rdnPrint";
            this.rdnPrint.Size = new System.Drawing.Size(92, 19);
            this.rdnPrint.TabIndex = 2;
            this.rdnPrint.Text = "Imprimantes";
            this.rdnPrint.UseVisualStyleBackColor = true;
            // 
            // rdnSalle
            // 
            this.rdnSalle.AutoSize = true;
            this.rdnSalle.Checked = true;
            this.rdnSalle.Location = new System.Drawing.Point(109, 31);
            this.rdnSalle.Name = "rdnSalle";
            this.rdnSalle.Size = new System.Drawing.Size(54, 19);
            this.rdnSalle.TabIndex = 1;
            this.rdnSalle.TabStop = true;
            this.rdnSalle.Text = "Salles";
            this.rdnSalle.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(186, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Recherche par...";
            // 
            // panel2
            // 
            this.panel2.AutoScroll = true;
            this.panel2.Controls.Add(this.tlp);
            this.panel2.Location = new System.Drawing.Point(2, 122);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(782, 326);
            this.panel2.TabIndex = 1;
            // 
            // tlp
            // 
            this.tlp.BackColor = System.Drawing.Color.LightGray;
            this.tlp.ColumnCount = 4;
            this.tlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlp.Location = new System.Drawing.Point(0, 0);
            this.tlp.Name = "tlp";
            this.tlp.RowCount = 4;
            this.tlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlp.Size = new System.Drawing.Size(782, 326);
            this.tlp.TabIndex = 0;
            // 
            // gestionParc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 450);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "gestionParc";
            this.Text = "Gestion du parc";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel1;
        private RadioButton rdnCart;
        private RadioButton rdnPrint;
        private RadioButton rdnSalle;
        private Label label1;
        private Panel panel2;
        private TableLayoutPanel tlp;
        private ComboBox cbbEnter;
        private Button btnSuppr;
        private Button btnModif;
    }
}