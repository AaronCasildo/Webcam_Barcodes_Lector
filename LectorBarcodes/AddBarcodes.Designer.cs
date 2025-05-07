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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dgv_lexico = new System.Windows.Forms.DataGridView();
            this.lbl_tabladetokens = new System.Windows.Forms.Label();
            this.lbl_validación = new System.Windows.Forms.Label();
            this.dgv_sintactico = new System.Windows.Forms.DataGridView();
            this.lbl_estructura = new System.Windows.Forms.Label();
            this.lbl_elementos = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_lexico)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_sintactico)).BeginInit();
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
            this.lbl_status.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.cmd_clean.Size = new System.Drawing.Size(146, 30);
            this.cmd_clean.TabIndex = 2;
            this.cmd_clean.Text = "Limpiar";
            this.cmd_clean.Click += new System.EventHandler(this.button1_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(658, 412);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(137, 19);
            this.label5.TabIndex = 16;
            this.label5.Text = "Análisis Semántico:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(658, 214);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(132, 19);
            this.label4.TabIndex = 15;
            this.label4.Text = "Análisis Sintáctico:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(658, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 19);
            this.label3.TabIndex = 14;
            this.label3.Text = "Análisis Léxico:";
            // 
            // dgv_lexico
            // 
            this.dgv_lexico.AllowUserToAddRows = false;
            this.dgv_lexico.AllowUserToDeleteRows = false;
            this.dgv_lexico.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgv_lexico.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_lexico.Location = new System.Drawing.Point(662, 70);
            this.dgv_lexico.Name = "dgv_lexico";
            this.dgv_lexico.ReadOnly = true;
            this.dgv_lexico.RowHeadersVisible = false;
            this.dgv_lexico.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToFirstHeader;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgv_lexico.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_lexico.Size = new System.Drawing.Size(597, 72);
            this.dgv_lexico.TabIndex = 17;
            // 
            // lbl_tabladetokens
            // 
            this.lbl_tabladetokens.AutoSize = true;
            this.lbl_tabladetokens.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_tabladetokens.Location = new System.Drawing.Point(687, 50);
            this.lbl_tabladetokens.Name = "lbl_tabladetokens";
            this.lbl_tabladetokens.Size = new System.Drawing.Size(103, 17);
            this.lbl_tabladetokens.TabIndex = 18;
            this.lbl_tabladetokens.Text = "Tabla de Tokens";
            // 
            // lbl_validación
            // 
            this.lbl_validación.AutoSize = true;
            this.lbl_validación.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_validación.ForeColor = System.Drawing.Color.Blue;
            this.lbl_validación.Location = new System.Drawing.Point(687, 157);
            this.lbl_validación.Name = "lbl_validación";
            this.lbl_validación.Size = new System.Drawing.Size(240, 34);
            this.lbl_validación.TabIndex = 19;
            this.lbl_validación.Text = "Longitud válida: Sí (13 dígitos)\r\nTodos los caracteres son numéricos: ✔️";
            // 
            // dgv_sintactico
            // 
            this.dgv_sintactico.AllowUserToAddRows = false;
            this.dgv_sintactico.AllowUserToDeleteRows = false;
            this.dgv_sintactico.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgv_sintactico.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_sintactico.Location = new System.Drawing.Point(662, 249);
            this.dgv_sintactico.Name = "dgv_sintactico";
            this.dgv_sintactico.ReadOnly = true;
            this.dgv_sintactico.RowHeadersVisible = false;
            this.dgv_sintactico.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToFirstHeader;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgv_sintactico.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_sintactico.Size = new System.Drawing.Size(316, 136);
            this.dgv_sintactico.TabIndex = 20;
            // 
            // lbl_estructura
            // 
            this.lbl_estructura.AutoSize = true;
            this.lbl_estructura.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_estructura.ForeColor = System.Drawing.Color.Blue;
            this.lbl_estructura.Location = new System.Drawing.Point(687, 478);
            this.lbl_estructura.Name = "lbl_estructura";
            this.lbl_estructura.Size = new System.Drawing.Size(30, 17);
            this.lbl_estructura.TabIndex = 21;
            this.lbl_estructura.Text = "test";
            // 
            // lbl_elementos
            // 
            this.lbl_elementos.AutoSize = true;
            this.lbl_elementos.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_elementos.ForeColor = System.Drawing.Color.Blue;
            this.lbl_elementos.Location = new System.Drawing.Point(687, 451);
            this.lbl_elementos.Name = "lbl_elementos";
            this.lbl_elementos.Size = new System.Drawing.Size(30, 17);
            this.lbl_elementos.TabIndex = 22;
            this.lbl_elementos.Text = "test";
            // 
            // AddBarcodes
            // 
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1271, 540);
            this.ControlBox = false;
            this.Controls.Add(this.lbl_elementos);
            this.Controls.Add(this.lbl_estructura);
            this.Controls.Add(this.dgv_sintactico);
            this.Controls.Add(this.lbl_validación);
            this.Controls.Add(this.lbl_tabladetokens);
            this.Controls.Add(this.dgv_lexico);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
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
            this.Name = "AddBarcodes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lector de Códigos de Barras";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_lexico)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_sintactico)).EndInit();
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
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgv_lexico;
        private System.Windows.Forms.Label lbl_tabladetokens;
        private System.Windows.Forms.Label lbl_validación;
        private System.Windows.Forms.DataGridView dgv_sintactico;
        private System.Windows.Forms.Label lbl_estructura;
        private System.Windows.Forms.Label lbl_elementos;
    }
}