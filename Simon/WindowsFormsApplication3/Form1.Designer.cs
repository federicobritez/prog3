namespace WindowsFormsApplication3 {
    partial class Form1 {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.buttonAz = new System.Windows.Forms.Button();
            this.buttonAm = new System.Windows.Forms.Button();
            this.buttonRo = new System.Windows.Forms.Button();
            this.buttonVe = new System.Windows.Forms.Button();
            this.buttonStart = new System.Windows.Forms.Button();
            this.buttonReset = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonAz
            // 
            this.buttonAz.BackColor = System.Drawing.Color.Navy;
            this.buttonAz.FlatAppearance.BorderSize = 0;
            this.buttonAz.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAz.Location = new System.Drawing.Point(117, 45);
            this.buttonAz.Name = "buttonAz";
            this.buttonAz.Size = new System.Drawing.Size(65, 42);
            this.buttonAz.TabIndex = 0;
            this.buttonAz.UseVisualStyleBackColor = false;
            this.buttonAz.Click += new System.EventHandler(this.buttonAz_Click);
            this.buttonAz.MouseClick += new System.Windows.Forms.MouseEventHandler(this.buttonAz_MouseClick);
            this.buttonAz.MouseUp += new System.Windows.Forms.MouseEventHandler(this.buttonAz_MouseUp);
            // 
            // buttonAm
            // 
            this.buttonAm.BackColor = System.Drawing.Color.DarkGoldenrod;
            this.buttonAm.FlatAppearance.BorderSize = 0;
            this.buttonAm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAm.Location = new System.Drawing.Point(107, 141);
            this.buttonAm.Name = "buttonAm";
            this.buttonAm.Size = new System.Drawing.Size(75, 55);
            this.buttonAm.TabIndex = 1;
            this.buttonAm.UseVisualStyleBackColor = false;
            this.buttonAm.Click += new System.EventHandler(this.buttonAm_Click);
            this.buttonAm.MouseClick += new System.Windows.Forms.MouseEventHandler(this.buttonAm_MouseClick);
            this.buttonAm.MouseUp += new System.Windows.Forms.MouseEventHandler(this.buttonAm_MouseUp);
            // 
            // buttonRo
            // 
            this.buttonRo.BackColor = System.Drawing.Color.Maroon;
            this.buttonRo.FlatAppearance.BorderSize = 0;
            this.buttonRo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRo.Location = new System.Drawing.Point(45, 83);
            this.buttonRo.Name = "buttonRo";
            this.buttonRo.Size = new System.Drawing.Size(64, 42);
            this.buttonRo.TabIndex = 2;
            this.buttonRo.UseVisualStyleBackColor = false;
            this.buttonRo.Click += new System.EventHandler(this.buttonRo_Click);
            this.buttonRo.MouseClick += new System.Windows.Forms.MouseEventHandler(this.buttonRo_MouseClick);
            this.buttonRo.MouseUp += new System.Windows.Forms.MouseEventHandler(this.buttonRo_MouseUp);
            // 
            // buttonVe
            // 
            this.buttonVe.BackColor = System.Drawing.Color.DarkGreen;
            this.buttonVe.FlatAppearance.BorderSize = 0;
            this.buttonVe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonVe.Location = new System.Drawing.Point(193, 91);
            this.buttonVe.Name = "buttonVe";
            this.buttonVe.Size = new System.Drawing.Size(75, 45);
            this.buttonVe.TabIndex = 3;
            this.buttonVe.UseVisualStyleBackColor = false;
            this.buttonVe.Click += new System.EventHandler(this.buttonVe_Click);
            this.buttonVe.MouseClick += new System.Windows.Forms.MouseEventHandler(this.buttonVe_MouseClick);
            this.buttonVe.MouseUp += new System.Windows.Forms.MouseEventHandler(this.buttonVe_MouseUp);
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(25, 210);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(75, 23);
            this.buttonStart.TabIndex = 5;
            this.buttonStart.Text = "Jugar";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // buttonReset
            // 
            this.buttonReset.BackColor = System.Drawing.Color.Silver;
            this.buttonReset.FlatAppearance.BorderSize = 0;
            this.buttonReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonReset.Font = new System.Drawing.Font("DejaVu Sans", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonReset.Location = new System.Drawing.Point(127, 102);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(40, 23);
            this.buttonReset.TabIndex = 6;
            this.buttonReset.Text = "R";
            this.buttonReset.UseVisualStyleBackColor = false;
            this.buttonReset.Click += new System.EventHandler(this.buttonReset_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("DejaVu Sans Mono", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(152, 214);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 18);
            this.label1.TabIndex = 7;
            this.label1.Text = "Puntaje:";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(107, 12);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(100, 12);
            this.progressBar1.TabIndex = 8;
            this.progressBar1.Click += new System.EventHandler(this.progressBar1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("DejaVu Sans Mono", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DarkOrange;
            this.label2.Location = new System.Drawing.Point(226, 214);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 18);
            this.label2.TabIndex = 9;
            this.label2.Text = "0";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(321, 266);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonReset);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.buttonVe);
            this.Controls.Add(this.buttonRo);
            this.Controls.Add(this.buttonAm);
            this.Controls.Add(this.buttonAz);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonAz;
        private System.Windows.Forms.Button buttonAm;
        private System.Windows.Forms.Button buttonRo;
        private System.Windows.Forms.Button buttonVe;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Button buttonReset;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label label2;
    }
}

