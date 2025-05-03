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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddBarcodes));
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
            this.cmd_back.Location = new System.Drawing.Point(24, 490);
            this.cmd_back.Name = "cmd_back";
            this.cmd_back.Size = new System.Drawing.Size(192, 30);
            this.cmd_back.TabIndex = 1;
            this.cmd_back.Text = "Regresar";
            this.cmd_back.Click += new System.EventHandler(this.cmd_back_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(24, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(144, 19);
            this.label1.TabIndex = 10;
            this.label1.Text = "Seleccionar cámara:";
            // 
            // cbox_camera
            // 
            this.cbox_camera.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbox_camera.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cbox_camera.Location = new System.Drawing.Point(190, 18);
            this.cbox_camera.Name = "cbox_camera";
            this.cbox_camera.Size = new System.Drawing.Size(234, 23);
            this.cbox_camera.TabIndex = 9;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(24, 60);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(400, 300);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // cmd_readcode
            // 
            this.cmd_readcode.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.cmd_readcode.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.cmd_readcode.ForeColor = System.Drawing.Color.White;
            this.cmd_readcode.Location = new System.Drawing.Point(24, 375);
            this.cmd_readcode.Name = "cmd_readcode";
            this.cmd_readcode.Size = new System.Drawing.Size(400, 40);
            this.cmd_readcode.TabIndex = 7;
            this.cmd_readcode.Text = "Leer Código (C)";
            this.cmd_readcode.UseVisualStyleBackColor = false;
            this.cmd_readcode.Click += new System.EventHandler(this.cmd_readcode_Click);
            // 
            // txt_resultado
            // 
            this.txt_resultado.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txt_resultado.Location = new System.Drawing.Point(24, 425);
            this.txt_resultado.Name = "txt_resultado";
            this.txt_resultado.Size = new System.Drawing.Size(400, 25);
            this.txt_resultado.TabIndex = 6;
            // 
            // lbl_status
            // 
            this.lbl_status.AutoSize = true;
            this.lbl_status.Location = new System.Drawing.Point(24, 455);
            this.lbl_status.Name = "lbl_status";
            this.lbl_status.Size = new System.Drawing.Size(0, 15);
            this.lbl_status.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(446, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(149, 19);
            this.label2.TabIndex = 4;
            this.label2.Text = "Códigos escaneados:";
            // 
            // lbl_codehistory
            // 
            this.lbl_codehistory.AutoSize = true;
            this.lbl_codehistory.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lbl_codehistory.Location = new System.Drawing.Point(446, 90);
            this.lbl_codehistory.Name = "lbl_codehistory";
            this.lbl_codehistory.Size = new System.Drawing.Size(0, 15);
            this.lbl_codehistory.TabIndex = 3;
            // 
            // cmd_exit
            // 
            this.cmd_exit.Location = new System.Drawing.Point(232, 490);
            this.cmd_exit.Name = "cmd_exit";
            this.cmd_exit.Size = new System.Drawing.Size(192, 30);
            this.cmd_exit.TabIndex = 0;
            this.cmd_exit.Text = "Salir";
            this.cmd_exit.Click += new System.EventHandler(this.cmd_exit_Click);
            // 
            // cmd_clean
            // 
            this.cmd_clean.Location = new System.Drawing.Point(449, 490);
            this.cmd_clean.Name = "cmd_clean";
            this.cmd_clean.Size = new System.Drawing.Size(132, 30);
            this.cmd_clean.TabIndex = 2;
            this.cmd_clean.Text = "Limpiar";
            this.cmd_clean.Click += new System.EventHandler(this.button1_Click);
            // 
            // AddBarcodes
            // 
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(624, 540);
            this.ControlBox = false;
            this.Controls.Add(this.cmd_exit);
            this.Controls.Add(this.cmd_back);
            this.Controls.Add(this.cmd_clean);
            this.Controls.Add(this.lbl_codehistory);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbl_status);
            this.Controls.Add(this.txt_resultado);
            this.Controls.Add(this.cmd_readcode);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.cbox_camera);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(640, 579);
            this.MinimumSize = new System.Drawing.Size(640, 579);
            this.Name = "AddBarcodes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lector de Códigos de Barras";
            this.TopMost = true;
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