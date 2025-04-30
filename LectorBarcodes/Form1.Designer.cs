namespace LectorBarcodes
{
    partial class Main
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
            this.cmd_add = new System.Windows.Forms.Button();
            this.cmd_read = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmd_add
            // 
            this.cmd_add.Location = new System.Drawing.Point(163, 289);
            this.cmd_add.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmd_add.Name = "cmd_add";
            this.cmd_add.Size = new System.Drawing.Size(264, 28);
            this.cmd_add.TabIndex = 0;
            this.cmd_add.Text = "Agregar Códigos de Barras";
            this.cmd_add.UseVisualStyleBackColor = true;
            this.cmd_add.Click += new System.EventHandler(this.cmd_add_Click);
            // 
            // cmd_read
            // 
            this.cmd_read.Location = new System.Drawing.Point(163, 374);
            this.cmd_read.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmd_read.Name = "cmd_read";
            this.cmd_read.Size = new System.Drawing.Size(264, 28);
            this.cmd_read.TabIndex = 1;
            this.cmd_read.Text = "Salir...";
            this.cmd_read.UseVisualStyleBackColor = true;
            this.cmd_read.Click += new System.EventHandler(this.cmd_read_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(593, 635);
            this.Controls.Add(this.cmd_read);
            this.Controls.Add(this.cmd_add);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Main";
            this.Text = "Lector de Códigos de Barras";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cmd_add;
        private System.Windows.Forms.Button cmd_read;
    }
}

