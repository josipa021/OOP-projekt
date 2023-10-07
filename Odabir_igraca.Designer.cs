namespace OTTER
{
    partial class Odabir_igraca
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Odabir_igraca));
            this.listbox_lista_igraca = new System.Windows.Forms.ListBox();
            this.spremi_odabir = new System.Windows.Forms.Button();
            this.rblevel1 = new System.Windows.Forms.RadioButton();
            this.rblevel2 = new System.Windows.Forms.RadioButton();
            this.lblporuka = new System.Windows.Forms.Label();
            this.lblnaslov = new System.Windows.Forms.Label();
            this.natrag = new System.Windows.Forms.Button();
            this.lblodabir_levela = new System.Windows.Forms.Label();
            this.lbl_prikaz_odabira = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // listbox_lista_igraca
            // 
            this.listbox_lista_igraca.BackColor = System.Drawing.Color.DarkSlateGray;
            this.listbox_lista_igraca.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.listbox_lista_igraca.ForeColor = System.Drawing.Color.Goldenrod;
            this.listbox_lista_igraca.FormattingEnabled = true;
            this.listbox_lista_igraca.ItemHeight = 24;
            this.listbox_lista_igraca.Location = new System.Drawing.Point(68, 52);
            this.listbox_lista_igraca.Margin = new System.Windows.Forms.Padding(4);
            this.listbox_lista_igraca.Name = "listbox_lista_igraca";
            this.listbox_lista_igraca.Size = new System.Drawing.Size(340, 508);
            this.listbox_lista_igraca.TabIndex = 0;
            this.listbox_lista_igraca.SelectedIndexChanged += new System.EventHandler(this.lista_igraca_SelectedIndexChanged);
            // 
            // spremi_odabir
            // 
            this.spremi_odabir.BackColor = System.Drawing.Color.Goldenrod;
            this.spremi_odabir.BackgroundImage = global::OTTER.Properties.Resources.normalno;
            this.spremi_odabir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.spremi_odabir.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spremi_odabir.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.spremi_odabir.Location = new System.Drawing.Point(503, 360);
            this.spremi_odabir.Margin = new System.Windows.Forms.Padding(4);
            this.spremi_odabir.Name = "spremi_odabir";
            this.spremi_odabir.Size = new System.Drawing.Size(188, 73);
            this.spremi_odabir.TabIndex = 1;
            this.spremi_odabir.Text = "Spremi odabir";
            this.spremi_odabir.UseVisualStyleBackColor = false;
            this.spremi_odabir.Click += new System.EventHandler(this.spremi_odabir_Click);
            this.spremi_odabir.MouseLeave += new System.EventHandler(this.spremi_odabir_MouseLeave);
            this.spremi_odabir.MouseHover += new System.EventHandler(this.spremi_odabir_MouseHover);
            // 
            // rblevel1
            // 
            this.rblevel1.AutoSize = true;
            this.rblevel1.BackColor = System.Drawing.Color.Transparent;
            this.rblevel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rblevel1.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.rblevel1.Location = new System.Drawing.Point(503, 92);
            this.rblevel1.Margin = new System.Windows.Forms.Padding(4);
            this.rblevel1.Name = "rblevel1";
            this.rblevel1.Size = new System.Drawing.Size(118, 33);
            this.rblevel1.TabIndex = 2;
            this.rblevel1.TabStop = true;
            this.rblevel1.Text = "Level 1";
            this.rblevel1.UseVisualStyleBackColor = false;
            // 
            // rblevel2
            // 
            this.rblevel2.AutoSize = true;
            this.rblevel2.BackColor = System.Drawing.Color.Transparent;
            this.rblevel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rblevel2.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.rblevel2.Location = new System.Drawing.Point(503, 134);
            this.rblevel2.Margin = new System.Windows.Forms.Padding(4);
            this.rblevel2.Name = "rblevel2";
            this.rblevel2.Size = new System.Drawing.Size(118, 33);
            this.rblevel2.TabIndex = 3;
            this.rblevel2.TabStop = true;
            this.rblevel2.Text = "Level 2";
            this.rblevel2.UseVisualStyleBackColor = false;
            // 
            // lblporuka
            // 
            this.lblporuka.AutoSize = true;
            this.lblporuka.BackColor = System.Drawing.Color.Transparent;
            this.lblporuka.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblporuka.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblporuka.ForeColor = System.Drawing.Color.Red;
            this.lblporuka.Location = new System.Drawing.Point(506, 436);
            this.lblporuka.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblporuka.Name = "lblporuka";
            this.lblporuka.Size = new System.Drawing.Size(53, 20);
            this.lblporuka.TabIndex = 4;
            this.lblporuka.Text = "label1";
            // 
            // lblnaslov
            // 
            this.lblnaslov.AutoSize = true;
            this.lblnaslov.BackColor = System.Drawing.Color.Transparent;
            this.lblnaslov.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblnaslov.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.lblnaslov.Location = new System.Drawing.Point(63, 30);
            this.lblnaslov.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblnaslov.Name = "lblnaslov";
            this.lblnaslov.Size = new System.Drawing.Size(119, 20);
            this.lblnaslov.TabIndex = 5;
            this.lblnaslov.Text = "odabir igraca";
            // 
            // natrag
            // 
            this.natrag.BackColor = System.Drawing.Color.Goldenrod;
            this.natrag.BackgroundImage = global::OTTER.Properties.Resources.normalno;
            this.natrag.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.natrag.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.natrag.Location = new System.Drawing.Point(503, 478);
            this.natrag.Margin = new System.Windows.Forms.Padding(4);
            this.natrag.Name = "natrag";
            this.natrag.Size = new System.Drawing.Size(188, 73);
            this.natrag.TabIndex = 6;
            this.natrag.Text = "Natrag na izbornik";
            this.natrag.UseVisualStyleBackColor = false;
            this.natrag.Click += new System.EventHandler(this.natrag_Click);
            this.natrag.MouseLeave += new System.EventHandler(this.natrag_MouseLeave);
            this.natrag.MouseHover += new System.EventHandler(this.natrag_MouseHover);
            // 
            // lblodabir_levela
            // 
            this.lblodabir_levela.AutoSize = true;
            this.lblodabir_levela.BackColor = System.Drawing.Color.Transparent;
            this.lblodabir_levela.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblodabir_levela.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.lblodabir_levela.Location = new System.Drawing.Point(499, 55);
            this.lblodabir_levela.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblodabir_levela.Name = "lblodabir_levela";
            this.lblodabir_levela.Size = new System.Drawing.Size(116, 20);
            this.lblodabir_levela.TabIndex = 7;
            this.lblodabir_levela.Text = "odabir levela";
            // 
            // lbl_prikaz_odabira
            // 
            this.lbl_prikaz_odabira.AutoSize = true;
            this.lbl_prikaz_odabira.BackColor = System.Drawing.Color.Transparent;
            this.lbl_prikaz_odabira.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_prikaz_odabira.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.lbl_prikaz_odabira.Location = new System.Drawing.Point(499, 225);
            this.lbl_prikaz_odabira.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_prikaz_odabira.Name = "lbl_prikaz_odabira";
            this.lbl_prikaz_odabira.Size = new System.Drawing.Size(128, 20);
            this.lbl_prikaz_odabira.TabIndex = 8;
            this.lbl_prikaz_odabira.Text = "prikaz odabira";
            // 
            // Odabir_igraca
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PowderBlue;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(939, 618);
            this.Controls.Add(this.lbl_prikaz_odabira);
            this.Controls.Add(this.lblodabir_levela);
            this.Controls.Add(this.natrag);
            this.Controls.Add(this.lblnaslov);
            this.Controls.Add(this.lblporuka);
            this.Controls.Add(this.rblevel2);
            this.Controls.Add(this.rblevel1);
            this.Controls.Add(this.spremi_odabir);
            this.Controls.Add(this.listbox_lista_igraca);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "Odabir_igraca";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Odabir igrača";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Odabir_igraca_FormClosed);
            this.Load += new System.EventHandler(this.Odabir_igraca_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listbox_lista_igraca;
        private System.Windows.Forms.Button spremi_odabir;
        private System.Windows.Forms.RadioButton rblevel1;
        private System.Windows.Forms.RadioButton rblevel2;
        private System.Windows.Forms.Label lblporuka;
        private System.Windows.Forms.Label lblnaslov;
        private System.Windows.Forms.Button natrag;
        private System.Windows.Forms.Label lblodabir_levela;
        private System.Windows.Forms.Label lbl_prikaz_odabira;
    }
}