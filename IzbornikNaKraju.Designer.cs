namespace OTTER
{
    partial class IzbornikNaKraju
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IzbornikNaKraju));
            this.label1 = new System.Windows.Forms.Label();
            this.btn_novi_level = new System.Windows.Forms.Button();
            this.Povratak_na_menu = new System.Windows.Forms.Button();
            this.Pokusaj_ponovno = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label1.Location = new System.Drawing.Point(74, 51);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            // 
            // btn_novi_level
            // 
            this.btn_novi_level.BackColor = System.Drawing.Color.Goldenrod;
            this.btn_novi_level.BackgroundImage = global::OTTER.Properties.Resources.normalno;
            this.btn_novi_level.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_novi_level.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.btn_novi_level.Location = new System.Drawing.Point(67, 415);
            this.btn_novi_level.Margin = new System.Windows.Forms.Padding(4);
            this.btn_novi_level.Name = "btn_novi_level";
            this.btn_novi_level.Size = new System.Drawing.Size(172, 68);
            this.btn_novi_level.TabIndex = 3;
            this.btn_novi_level.Text = "Novi level";
            this.btn_novi_level.UseVisualStyleBackColor = false;
            this.btn_novi_level.Click += new System.EventHandler(this.btn_novi_level_Click);
            this.btn_novi_level.MouseLeave += new System.EventHandler(this.btn_novi_level_MouseLeave);
            this.btn_novi_level.MouseHover += new System.EventHandler(this.btn_novi_level_MouseHover);
            // 
            // Povratak_na_menu
            // 
            this.Povratak_na_menu.BackColor = System.Drawing.Color.Goldenrod;
            this.Povratak_na_menu.BackgroundImage = global::OTTER.Properties.Resources.normalno;
            this.Povratak_na_menu.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Povratak_na_menu.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.Povratak_na_menu.Location = new System.Drawing.Point(67, 202);
            this.Povratak_na_menu.Margin = new System.Windows.Forms.Padding(4);
            this.Povratak_na_menu.Name = "Povratak_na_menu";
            this.Povratak_na_menu.Size = new System.Drawing.Size(172, 68);
            this.Povratak_na_menu.TabIndex = 2;
            this.Povratak_na_menu.Text = "Povratak na izbornik";
            this.Povratak_na_menu.UseVisualStyleBackColor = false;
            this.Povratak_na_menu.Click += new System.EventHandler(this.Povratak_na_menu_Click);
            this.Povratak_na_menu.MouseLeave += new System.EventHandler(this.Povratak_na_menu_MouseLeave);
            this.Povratak_na_menu.MouseHover += new System.EventHandler(this.Povratak_na_menu_MouseHover);
            // 
            // Pokusaj_ponovno
            // 
            this.Pokusaj_ponovno.BackColor = System.Drawing.Color.Goldenrod;
            this.Pokusaj_ponovno.BackgroundImage = global::OTTER.Properties.Resources.normalno;
            this.Pokusaj_ponovno.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Pokusaj_ponovno.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.Pokusaj_ponovno.Location = new System.Drawing.Point(67, 310);
            this.Pokusaj_ponovno.Margin = new System.Windows.Forms.Padding(4);
            this.Pokusaj_ponovno.Name = "Pokusaj_ponovno";
            this.Pokusaj_ponovno.Size = new System.Drawing.Size(172, 68);
            this.Pokusaj_ponovno.TabIndex = 1;
            this.Pokusaj_ponovno.Text = "Pokušaj ponovno";
            this.Pokusaj_ponovno.UseVisualStyleBackColor = false;
            this.Pokusaj_ponovno.Click += new System.EventHandler(this.Pokusaj_ponovno_Click);
            this.Pokusaj_ponovno.MouseLeave += new System.EventHandler(this.Pokusaj_ponovno_MouseLeave);
            this.Pokusaj_ponovno.MouseHover += new System.EventHandler(this.Pokusaj_ponovno_MouseHover);
            // 
            // IzbornikNaKraju
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PowderBlue;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(939, 599);
            this.Controls.Add(this.btn_novi_level);
            this.Controls.Add(this.Povratak_na_menu);
            this.Controls.Add(this.Pokusaj_ponovno);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "IzbornikNaKraju";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kraj";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.IzbornikNaKraju_FormClosed);
            this.Load += new System.EventHandler(this.IzbornikNaKraju_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Pokusaj_ponovno;
        private System.Windows.Forms.Button Povratak_na_menu;
        private System.Windows.Forms.Button btn_novi_level;
    }
}