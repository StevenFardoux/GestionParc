namespace Gestion_des_cartouches_d_ancres
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblImprim = new System.Windows.Forms.Label();
            this.txtimprim = new System.Windows.Forms.TextBox();
            this.tlp = new System.Windows.Forms.TableLayoutPanel();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.vScrollBar1 = new System.Windows.Forms.VScrollBar();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tlp.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblImprim
            // 
            this.lblImprim.AutoSize = true;
            this.lblImprim.Location = new System.Drawing.Point(247, 32);
            this.lblImprim.Name = "lblImprim";
            this.lblImprim.Size = new System.Drawing.Size(127, 15);
            this.lblImprim.TabIndex = 0;
            this.lblImprim.Text = "Nom de l\'imprimante :";
            // 
            // txtimprim
            // 
            this.txtimprim.Location = new System.Drawing.Point(380, 29);
            this.txtimprim.Name = "txtimprim";
            this.txtimprim.Size = new System.Drawing.Size(135, 23);
            this.txtimprim.TabIndex = 1;
            // 
            // tlp
            // 
            this.tlp.ColumnCount = 5;
            this.tlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 36.84211F));
            this.tlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.78947F));
            this.tlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.78947F));
            this.tlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.78947F));
            this.tlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.78947F));
            this.tlp.Controls.Add(this.button5, 0, 0);
            this.tlp.Controls.Add(this.button4, 0, 0);
            this.tlp.Controls.Add(this.button3, 2, 0);
            this.tlp.Controls.Add(this.button2, 1, 0);
            this.tlp.Controls.Add(this.button1, 0, 0);
            this.tlp.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.tlp.Location = new System.Drawing.Point(64, 22);
            this.tlp.Name = "tlp";
            this.tlp.RowCount = 1;
            this.tlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlp.Size = new System.Drawing.Size(593, 250);
            this.tlp.TabIndex = 3;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(314, 3);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(84, 35);
            this.button5.TabIndex = 4;
            this.button5.Text = "Jaune";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(221, 3);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(84, 35);
            this.button4.TabIndex = 3;
            this.button4.Text = "Noir";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(500, 3);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(88, 35);
            this.button3.TabIndex = 2;
            this.button3.Text = "Cyan";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(407, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(84, 35);
            this.button2.TabIndex = 1;
            this.button2.Text = "Magenta";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(3, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(205, 35);
            this.button1.TabIndex = 0;
            this.button1.Text = "Nom Imprimante";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // vScrollBar1
            // 
            this.vScrollBar1.Location = new System.Drawing.Point(335, 29);
            this.vScrollBar1.Name = "vScrollBar1";
            this.vScrollBar1.Size = new System.Drawing.Size(8, 8);
            this.vScrollBar1.TabIndex = 5;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.tlp);
            this.panel1.Location = new System.Drawing.Point(52, 85);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(703, 300);
            this.panel1.TabIndex = 6;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 450);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.vScrollBar1);
            this.Controls.Add(this.txtimprim);
            this.Controls.Add(this.lblImprim);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "Form1";
            this.Text = "Gestion du stock des cartouches";
            this.tlp.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label lblImprim;
        private TextBox txtimprim;
        private TableLayoutPanel tlp;
        private VScrollBar vScrollBar1;
        private Panel panel1;
        private Button button3;
        private Button button2;
        private Button button1;
        private Button button5;
        private Button button4;
    }
}