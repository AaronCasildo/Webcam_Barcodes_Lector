namespace LectorBarcodes
{
    partial class Main
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button cmd_add;
        private System.Windows.Forms.Button cmd_exit;
        private System.Windows.Forms.Label lbl_title;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.cmd_add = new System.Windows.Forms.Button();
            this.cmd_exit = new System.Windows.Forms.Button();
            this.lbl_title = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cmd_add
            // 
            this.cmd_add.BackColor = System.Drawing.Color.White;
            this.cmd_add.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.cmd_add.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmd_add.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmd_add.Location = new System.Drawing.Point(82, 71);
            this.cmd_add.Name = "cmd_add";
            this.cmd_add.Size = new System.Drawing.Size(200, 40);
            this.cmd_add.TabIndex = 1;
            this.cmd_add.Text = "Leer Códigos de Barras";
            this.cmd_add.UseVisualStyleBackColor = false;
            this.cmd_add.Click += new System.EventHandler(this.cmd_add_Click);
            // 
            // cmd_exit
            // 
            this.cmd_exit.BackColor = System.Drawing.Color.White;
            this.cmd_exit.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.cmd_exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmd_exit.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmd_exit.Location = new System.Drawing.Point(82, 131);
            this.cmd_exit.Name = "cmd_exit";
            this.cmd_exit.Size = new System.Drawing.Size(200, 40);
            this.cmd_exit.TabIndex = 2;
            this.cmd_exit.Text = "Salir";
            this.cmd_exit.UseVisualStyleBackColor = false;
            this.cmd_exit.Click += new System.EventHandler(this.cmd_read_Click);
            // 
            // lbl_title
            // 
            this.lbl_title.AutoSize = true;
            this.lbl_title.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lbl_title.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.lbl_title.Location = new System.Drawing.Point(52, 31);
            this.lbl_title.Name = "lbl_title";
            this.lbl_title.Size = new System.Drawing.Size(261, 25);
            this.lbl_title.TabIndex = 0;
            this.lbl_title.Text = "Lector de Códigos de Barras";
            this.lbl_title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(366, 201);
            this.Controls.Add(this.lbl_title);
            this.Controls.Add(this.cmd_add);
            this.Controls.Add(this.cmd_exit);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(382, 240);
            this.MinimumSize = new System.Drawing.Size(382, 240);
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lector de Códigos de Barras";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
