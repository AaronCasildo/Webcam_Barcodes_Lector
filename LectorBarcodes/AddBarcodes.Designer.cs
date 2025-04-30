namespace LectorBarcodes
{
    partial class AddBarcodes
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
            this.cmd_back = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cbox_camera = new System.Windows.Forms.ComboBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.cmd_readcode = new System.Windows.Forms.Button();
            this.txt_resultado = new System.Windows.Forms.TextBox();
            this.lbl_status = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbl_codehistory = new System.Windows.Forms.Label();
            this.cmd_exit = new System.Windows.Forms.Button();
            this.cmd_clean = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // cmd_back
            // 
            this.cmd_back.Location = new System.Drawing.Point(32, 499);
            this.cmd_back.Margin = new System.Windows.Forms.Padding(4);
            this.cmd_back.Name = "cmd_back";
            this.cmd_back.Size = new System.Drawing.Size(176, 28);
            this.cmd_back.TabIndex = 0;
            this.cmd_back.Text = "Regresar al menú...";
            this.cmd_back.UseVisualStyleBackColor = true;
            this.cmd_back.Click += new System.EventHandler(this.cmd_back_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(44, 31);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Seleccione Cámara:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // cbox_camera
            // 
            this.cbox_camera.FormattingEnabled = true;
            this.cbox_camera.Location = new System.Drawing.Point(219, 27);
            this.cbox_camera.Margin = new System.Windows.Forms.Padding(4);
            this.cbox_camera.Name = "cbox_camera";
            this.cbox_camera.Size = new System.Drawing.Size(216, 24);
            this.cbox_camera.TabIndex = 2;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(32, 70);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(533, 400);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // cmd_readcode
            // 
            this.cmd_readcode.Location = new System.Drawing.Point(230, 499);
            this.cmd_readcode.Margin = new System.Windows.Forms.Padding(4);
            this.cmd_readcode.Name = "cmd_readcode";
            this.cmd_readcode.Size = new System.Drawing.Size(335, 67);
            this.cmd_readcode.TabIndex = 4;
            this.cmd_readcode.Text = "Leer Código (C)";
            this.cmd_readcode.UseVisualStyleBackColor = true;
            this.cmd_readcode.Click += new System.EventHandler(this.cmd_readcode_Click);
            // 
            // txt_resultado
            // 
            this.txt_resultado.Location = new System.Drawing.Point(32, 574);
            this.txt_resultado.Margin = new System.Windows.Forms.Padding(4);
            this.txt_resultado.Name = "txt_resultado";
            this.txt_resultado.Size = new System.Drawing.Size(533, 22);
            this.txt_resultado.TabIndex = 5;
            // 
            // lbl_status
            // 
            this.lbl_status.AutoSize = true;
            this.lbl_status.Location = new System.Drawing.Point(29, 613);
            this.lbl_status.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_status.Name = "lbl_status";
            this.lbl_status.Size = new System.Drawing.Size(0, 16);
            this.lbl_status.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(645, 30);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(194, 16);
            this.label2.TabIndex = 7;
            this.label2.Text = "Códigos de barra escaneados:";
            // 
            // lbl_codehistory
            // 
            this.lbl_codehistory.AutoSize = true;
            this.lbl_codehistory.Location = new System.Drawing.Point(645, 70);
            this.lbl_codehistory.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_codehistory.Name = "lbl_codehistory";
            this.lbl_codehistory.Size = new System.Drawing.Size(0, 16);
            this.lbl_codehistory.TabIndex = 8;
            // 
            // cmd_exit
            // 
            this.cmd_exit.Location = new System.Drawing.Point(32, 538);
            this.cmd_exit.Margin = new System.Windows.Forms.Padding(4);
            this.cmd_exit.Name = "cmd_exit";
            this.cmd_exit.Size = new System.Drawing.Size(176, 28);
            this.cmd_exit.TabIndex = 9;
            this.cmd_exit.Text = "Salir...";
            this.cmd_exit.UseVisualStyleBackColor = true;
            this.cmd_exit.Click += new System.EventHandler(this.cmd_exit_Click);
            // 
            // cmd_clean
            // 
            this.cmd_clean.Location = new System.Drawing.Point(648, 607);
            this.cmd_clean.Margin = new System.Windows.Forms.Padding(4);
            this.cmd_clean.Name = "cmd_clean";
            this.cmd_clean.Size = new System.Drawing.Size(176, 28);
            this.cmd_clean.TabIndex = 10;
            this.cmd_clean.Text = "Limpiar...";
            this.cmd_clean.UseVisualStyleBackColor = true;
            this.cmd_clean.Click += new System.EventHandler(this.button1_Click);
            // 
            // AddBarcodes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(918, 652);
            this.ControlBox = false;
            this.Controls.Add(this.cmd_clean);
            this.Controls.Add(this.cmd_exit);
            this.Controls.Add(this.lbl_codehistory);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbl_status);
            this.Controls.Add(this.txt_resultado);
            this.Controls.Add(this.cmd_readcode);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.cbox_camera);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmd_back);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "AddBarcodes";
            this.Text = "AddBarcodes";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmd_back;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbox_camera;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button cmd_readcode;
        private System.Windows.Forms.TextBox txt_resultado;
        private System.Windows.Forms.Label lbl_status;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbl_codehistory;
        private System.Windows.Forms.Button cmd_exit;
        private System.Windows.Forms.Button cmd_clean;
    }
}